using Application.Common.Response;
using Application.Core.Exceptions;
using Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Commands;
using Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Queries;
using Application.DTOs.Administrativeprocesses;
using Application.Interfaces.AdministrativeProcesses;
using Application.Interfaces.Rol;
using Application.Interfaces.User;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Domain.Models.AdministrativeProcesses;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.AdministrativeProcesses
{
    public class DisciplinaryProcessService : IDisciplinaryProcessService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IHostingEnvironment _hostingEnvironment;
        private ICurrentUserService _currentUserService;
        private Guid _userId;
        private string _createdByName;
        private IRolService _rolService;
        private readonly ITypeOfFaultService _typeOfFaultService;
        private readonly IProcessHistoryChangeService _processHistoryChangeService;

        private readonly IUserRolService _userRolService;
        private readonly IUserService _userService;

        public DisciplinaryProcessService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<DisciplinaryProcess> logger,
            IProcessHistoryChangeService processHistoryChangeService, IHostingEnvironment hostingEnvironment, ICurrentUserService currentUserService
            , IRolService rolService, ITypeOfFaultService typeOfFaultService, IUserRolService userRolService, IUserService userService)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _processHistoryChangeService = processHistoryChangeService;
            _hostingEnvironment = hostingEnvironment;
            _currentUserService = currentUserService;
            _rolService = rolService;
            _typeOfFaultService = typeOfFaultService;
            _createdByName = _currentUserService.GetUserInfo().Name;
            _userId = (Guid)_currentUserService.GetUserInfo().Id;

            _userRolService = userRolService;
            _userService = userService;

        }

        public async Task<ApiResponse<DisciplinaryProcessDto>> PostDisciplinary(PostDisciplinaryProcessCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<DisciplinaryProcessDto>();
            EmailBodyDto EmailBody = new EmailBodyDto();
            List<ProcessSupport> archivos = new List<ProcessSupport>();

            try
            {
                request.StatusDate = DateTime.Now;

                //Traer por Rol y Nofiticar                 
                var rolId = new Guid("21508540-660E-4790-9764-24E56C3FF71F");
                var UserRols = await _unitOfWork.UserRolRepository.Get().Where(x => x.RolId == rolId).ToListAsync();

                List<Domain.Models.User.User> destino = new List<Domain.Models.User.User>();

                foreach (var item in UserRols)
                {
                    destino.Add(await _unitOfWork.UserRepository.Get().Where(x => x.Id == item.UserId && x.CampaignName == request.CampaignName).FirstOrDefaultAsync());
                }

                EmailBody.UserRol = destino;

                var source = _mapper.Map<DisciplinaryProcessDto>(await _unitOfWork.DisciplinaryProcessRepository.Add(_mapper.Map<DisciplinaryProcess>(request)));
                var GetId = source.Id;
                

                //envio de Email            
                if (request.Email != null || EmailBody.UserRol.Count > 0)
                {
                    var Fault = await _typeOfFaultService.GetTypesById(request.TypeOfFaultId);

                    EmailBody.Fault = Fault.NameOfFault;
                    EmailBody.DescriptionOfTheFault = request.DescriptionOfTheFault;
                    EmailBody.NameAplicant = _createdByName;
                    EmailBody.NameUser = request.Names;
                    EmailBody.url = "http://172.16.5.155:9001/login";
                    EmailBody.Subject = "Notificación Solicitud de Proceso - Uno27 S.A.S";
                    EmailBody.StatusDate = request.StatusDate;
                    EmailBody.Body = "Se ha generado una solicitud de proceso disciplinario por parte de ";

                    var sendEmail = await SendEmailDisciplinaryprocess(EmailBody);
                    if (!sendEmail) throw new NotFoundException(" No se pudo enviar el Email");
                }

                var results = response.Data;

                //Crea registro
                ProcessChangeHistory processChangeHistory = new ProcessChangeHistory();
                processChangeHistory.CreatedAt = DateTime.Now;
                processChangeHistory.DisciplinaryProcessId = GetId;
                processChangeHistory.StatusDate = DateTime.Now;
                processChangeHistory.StatusStart = source.ProcessStatusId;
                processChangeHistory.ProcessPerformedById = _userId;
                processChangeHistory.CreatedBy = _userId;
                processChangeHistory.StatusNext = 0;

                await _unitOfWork.ProcessChangeHistoryRepository.Add(processChangeHistory);

                if (request.filePdf != null)
                {
                    if (request.filePdf.Count > 0)
                    {
                        //var GetId = 0;

                        //var processId = await getIdProcess();
                        //if (processId > 0)
                        //{
                            //GetId = getIdProcess().Result + 1;
                            var prefix = "_SOLPRO_";
                            var ruta = await SavePdfCopy(request.filePdf, prefix, GetId.ToString());
                            request.SupportDocument = GetId.ToString() + prefix;
                            _logger.LogInformation("prueba");
                            //save in DB
                            foreach (var item in request.filePdf)
                            {
                                ProcessSupport archivo = new ProcessSupport();
                                _logger.LogInformation("prueba");
                                archivo.DisciplinaryProcessId = GetId;
                                archivo.Type = GetId.ToString() + prefix;
                                archivo.NameFile = Path.GetFileName(item.FileName);
                                archivos.Add(archivo);
                            }
                            var ee = await _unitOfWork.ProcessSupportRepository.AddRange(archivos);
                            _logger.LogInformation("prueba");
                        //}
                    }
                }
                response.Data = source;
                response.Result = true;
                response.Message = "OK";

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, disciplinaryProcess en el método PostDisciplinary, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al crear el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task<ApiResponse<DisciplinaryProcessDto>> PutProcess(PutDisciplinaryProcessCommand request, CancellationToken cancellationToken)
        {

            var response = new ApiResponse<DisciplinaryProcessDto>();
            ProcessChangeHistory processChangeHistory = new ProcessChangeHistory();
            EmailBodyDto EmailBody = new EmailBodyDto();

            var codigo = request.Id;

            var ssss = await GetByIdProcess(codigo);
            var process = await GetByIdProcess(request.Id) ?? throw new NotFoundException("The Disciplinary process is not found");

            try
            {
                //update historico
                processChangeHistory.StatusStart = ssss.ProcessStatusId;
                processChangeHistory.CreatedAt = DateTime.Now;
                processChangeHistory.CreatedBy = _userId;
                processChangeHistory.CreatedByName = _createdByName;
                processChangeHistory.DisciplinaryProcessId = ssss.Id;
                processChangeHistory.StatusDate = DateTime.Now;
                processChangeHistory.StatusNext = request.ProcessStatusId;
                processChangeHistory.ProcessPerformedById = _userId;

                await _unitOfWork.ProcessChangeHistoryRepository.Add(processChangeHistory);

                var source = _mapper.Map<PutDisciplinaryProcessCommand, DisciplinaryProcess>(request, process);
                source.StatusDate = DateTime.Now;

                if (request.ProcessStatusId == 7 || request.ProcessStatusId == 8)
                {
                    var emailUser = await _unitOfWork.UserRepository.GetById(source.userProcessApprovingId.Value);
                    EmailBody.Email = emailUser.Email;
                }

                if (request.ProcessStatusId == 2)
                {
                    // traer por rol y nofiticar                 
                    var rolId = new Guid("CF9AC03B-DC6F-4A8A-A5DE-EA644E1A9228");
                    var UserRols = await _unitOfWork.UserRolRepository.Get().Where(x => x.RolId == rolId).ToListAsync();

                    List<Domain.Models.User.User> destino = new List<Domain.Models.User.User>();

                    foreach (var item in UserRols)
                    {
                        destino.Add(await _unitOfWork.UserRepository.Get().Where(x => x.Id == item.UserId).FirstOrDefaultAsync());
                    }

                    EmailBody.UserRol = destino;

                }

                //envio de Email            
                if (request.Email != null || EmailBody.UserRol != null)
                {
                    var Fault = await _typeOfFaultService.GetTypesById(source.TypeOfFaultId);
                    EmailBody.Fault = Fault.NameOfFault;
                    EmailBody.DescriptionOfTheFault = source.DescriptionOfTheFault;
                    EmailBody.NameAplicant = _createdByName;
                    EmailBody.NameUser = source.Names;
                    EmailBody.url = "http://172.16.5.155:9001/login";
                    EmailBody.Subject = "Notificación Solicitud de Proceso - Uno27 S.A.S";
                    EmailBody.StatusDate = request.StatusDate;

                    if (request.ProcessStatusId == 2)
                    {
                        EmailBody.Body = "Se ha Autorizado una solicitud de proceso # " + request.Id + " por parte de: ";
                    }

                    if (request.ProcessStatusId == 7 || request.ProcessStatusId == 8)
                        EmailBody.Body = "Se ha Sancionado la  solicitud de proceso # " + request.Id + " por parte de: ";

                    var sendEmail = await SendEmailDisciplinaryprocess(EmailBody);

                    if (!sendEmail) throw new NotFoundException(" No se pudo enviar el Email");
                }

                response.Data = _mapper.Map<DisciplinaryProcessDto>(await _unitOfWork.DisciplinaryProcessRepository.Put(source));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el registro, DisciplinaryProcessService en el método PutProcess, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;

        }

        public async Task<ApiResponse<DisciplinaryProcessDto>> PutProcessResponse(PutResponseDisciplinaryProcessCommand request, CancellationToken cancellationToken)
        {

            var response = new ApiResponse<DisciplinaryProcessDto>();
            ProcessChangeHistory processChangeHistory = new ProcessChangeHistory();

            var codigo = request.Id;

            var ssss = await GetByIdProcess(codigo);
            var process = await GetByIdProcess(request.Id) ?? throw new NotFoundException("The Disciplinary process is not found");

            try
            {
                //update historico
                processChangeHistory.StatusStart = ssss.ProcessStatusId;
                processChangeHistory.CreatedAt = DateTime.Now;
                processChangeHistory.CreatedBy = _userId;
                processChangeHistory.DisciplinaryProcessId = ssss.Id;
                processChangeHistory.StatusDate = DateTime.Now;
                processChangeHistory.StatusNext = request.ProcessStatusId;
                processChangeHistory.ProcessPerformedById = _userId;

                await _unitOfWork.ProcessChangeHistoryRepository.Add(processChangeHistory);

                var source = _mapper.Map<PutResponseDisciplinaryProcessCommand, DisciplinaryProcess>(request, process);
                source.StatusDate = DateTime.Now;
                List<ProcessSupport> archivos = new List<ProcessSupport>();


                if (request.filePdf != null)
                {
                    if (request.filePdf.Count > 0)
                    {

                        var prefix = "_LEGPRO_";
                        //var ruta = SavePdf(request.filePdf, prefix, request.Id.ToString());
                        var ruta = SavePdfCopy(request.filePdf, prefix, request.Id.ToString());
                        request.LegalSupportDocument =  request.Id.ToString() + prefix;
                       
                       
                  
                        //save in DB
                        foreach (var item in request.filePdf)
                        {
                            ProcessSupport archivo = new ProcessSupport();

                            archivo.DisciplinaryProcessId = request.Id;
                            archivo.Type = request.Id.ToString() + prefix;
                            archivo.NameFile = Path.GetFileName(item.FileName);
                            archivos.Add(archivo);
                        }
                        await _unitOfWork.ProcessSupportRepository.AddRange(archivos);

                    }
                }


                var emailUser = await _unitOfWork.UserRepository.GetById(source.userProcessAuthorizingId.Value);
                request.Email = emailUser.Email;

                //envio de Email            
                if (request.Email != null)
                {
                    if (request.Email.Length > 10)
                    {
                        var Fault = await _typeOfFaultService.GetTypesById(source.TypeOfFaultId);

                        EmailBodyDto EmailBody = new EmailBodyDto();

                        EmailBody.Fault = Fault.NameOfFault;
                        EmailBody.DescriptionOfTheFault = source.DescriptionOfTheFault;
                        EmailBody.Email = request.Email;

                        EmailBody.NameAplicant = _createdByName;
                        EmailBody.NameUser = source.Names;
                        EmailBody.url = "http://172.16.5.155:9001/login";
                        EmailBody.Subject = "Notificación Solicitud de Proceso - Uno27 S.A.S";
                        EmailBody.StatusDate = request.StatusDate;
                        EmailBody.Body = "Se ha generado una respuesta de la solictud de proceso # " + source.Id + " por parte del Abodago: ";


                        if (request.EmailCopy != null)
                            EmailBody.EmailCopy = request.EmailCopy;

                        var sendEmail = await SendEmailDisciplinaryprocess(EmailBody);

                        if (!sendEmail) throw new NotFoundException(" No se pudo enviar el Email");
                        response.Url = sendEmail.ToString();
                    }
                }

                response.Data = _mapper.Map<DisciplinaryProcessDto>(await _unitOfWork.DisciplinaryProcessRepository.Put(source));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el registro, DisciplinaryProcessService en el método PutProcess, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;

        }

        public async Task<DisciplinaryProcess> GetByIdProcess(int Id)
        {

            return await _unitOfWork.DisciplinaryProcessRepository
                                        .Get()
                                        .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<ApiResponse<List<DisciplinaryProcessDto>>> GetByStatus(GetByStatusDisciplinaryProcessQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<DisciplinaryProcessDto>>();
            var time = new DateTime();

            try
            {
                var source = new List<DisciplinaryProcessDto>();
                if (request.StartDate.Date != time && request.EndDate.Date != time)
                {
                    source = _mapper.Map<List<DisciplinaryProcessDto>>(await _unitOfWork.DisciplinaryProcessRepository.Get()
                                                    .Where(x => x.ProcessStatusId == request.ProcessStatusId && x.CreatedAt.Value.Date >= request.StartDate.Date && x.CreatedAt.Value.Date <= request.EndDate.Date)
                                                    .Include(x => x.TypeOfFault)
                                                    .Include(x => x.ProcessStatus)
                                                    .Include(x => x.UserProcessApplicant)
                                                    .Include(x => x.UserProcessAuthorizing)
                                                    .Include(x => x.UserProcessApproving)
                                                    .Include(x => x.TypeOfFailure)
                                                    .Include(x => x.ProcessSupport)
                                                    .OrderByDescending(x => x.TypeOfFault).ToListAsync());
                }
                else
                {
                    source = _mapper.Map<List<DisciplinaryProcessDto>>(await _unitOfWork.DisciplinaryProcessRepository.Get()
                                                    .Where(x => x.ProcessStatusId == request.ProcessStatusId)
                                                    .Include(x => x.TypeOfFault)
                                                    .Include(x => x.ProcessStatus)
                                                    .Include(x => x.UserProcessApplicant)
                                                    .Include(x => x.UserProcessAuthorizing)
                                                    .Include(x => x.UserProcessApproving)
                                                    .Include(x => x.TypeOfFailure)
                                                    .Include(x => x.ProcessSupport)
                                                    .OrderByDescending(x => x.TypeOfFault).ToListAsync());
                }
                

                response.Data = source;
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, Overtimeservice en el método PostOvertime, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al crear el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;

        }

        public async Task<ApiResponse<List<DisciplinaryProcessDto>>> GetByStatusAndCampaign(GetByStatusAndCampaignDisciplinaryProcessQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<DisciplinaryProcessDto>>();
            var time = new DateTime();

            try
            {

                var source = new List<DisciplinaryProcessDto>();
                if (request.StartDate.Date != time && request.EndDate.Date != time)
                {
                    source = _mapper.Map<List<DisciplinaryProcessDto>>(await _unitOfWork.DisciplinaryProcessRepository.Get()
                                                    .Where(x => x.ProcessStatusId == request.ProcessStatusId && x.CampaignName == request.CostCenter && x.CreatedAt.Value.Date >= request.StartDate.Date && x.CreatedAt.Value.Date <= request.EndDate.Date)
                                                    .Include(x => x.TypeOfFault)
                                                    .Include(x => x.ProcessStatus)
                                                    .Include(x => x.UserProcessApplicant)
                                                    .Include(x => x.UserProcessAuthorizing)
                                                    .Include(x => x.UserProcessApproving)
                                                    .Include(x => x.TypeOfFailure)
                                                    .Include(x => x.ProcessSupport)
                                                    .OrderByDescending(x => x.TypeOfFault).ToListAsync());
                }
                else
                {
                    source = _mapper.Map<List<DisciplinaryProcessDto>>(await _unitOfWork.DisciplinaryProcessRepository.Get()
                                                    .Where(x => x.ProcessStatusId == request.ProcessStatusId && x.CampaignName == request.CostCenter)
                                                    .Include(x => x.TypeOfFault)
                                                    .Include(x => x.ProcessStatus)
                                                    .Include(x => x.UserProcessApplicant)
                                                    .Include(x => x.UserProcessAuthorizing)
                                                    .Include(x => x.UserProcessApproving)
                                                    .Include(x => x.TypeOfFailure)
                                                    .Include(x => x.ProcessSupport)
                                                    .OrderByDescending(x => x.TypeOfFault).ToListAsync());
                }

                response.Data = source;
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, Overtimeservice en el método PostOvertime, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al crear el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<List<DisciplinaryProcessDto>>> GetByStatusAndApplicant(GetByStatusAndCurrentUserIdDisciplinaryProcessQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<DisciplinaryProcessDto>>();
            var time = new DateTime();

            try
            {
                var source = new List<DisciplinaryProcessDto>();
                if (request.StartDate.Date != time && request.EndDate.Date != time)
                {

                    source = _mapper.Map<List<DisciplinaryProcessDto>>(await _unitOfWork.DisciplinaryProcessRepository.Get()
                                                    .Where(x => x.ProcessStatusId == request.ProcessStatusId && x.userProcessApplicantId == _userId && x.CreatedAt.Value.Date >= request.StartDate.Date && x.CreatedAt.Value.Date <= request.EndDate.Date)
                                                    .Include(x => x.TypeOfFault)
                                                    .Include(x => x.ProcessStatus)
                                                    .Include(x => x.UserProcessApplicant)
                                                    .Include(x => x.UserProcessAuthorizing)
                                                    .Include(x => x.UserProcessApproving)
                                                    .Include(x => x.TypeOfFailure)
                                                    .Include(x => x.ProcessSupport)
                                                    .OrderByDescending(x => x.TypeOfFault).ToListAsync());
                } else
                {
                    source = _mapper.Map<List<DisciplinaryProcessDto>>(await _unitOfWork.DisciplinaryProcessRepository.Get()
                                                    .Where(x => x.ProcessStatusId == request.ProcessStatusId && x.userProcessApplicantId == _userId)
                                                    .Include(x => x.TypeOfFault)
                                                    .Include(x => x.ProcessStatus)
                                                    .Include(x => x.UserProcessApplicant)
                                                    .Include(x => x.UserProcessAuthorizing)
                                                    .Include(x => x.UserProcessApproving)
                                                    .Include(x => x.TypeOfFailure)
                                                    .Include(x => x.ProcessSupport)
                                                    .OrderByDescending(x => x.TypeOfFault).ToListAsync());
                }

                response.Data = source;
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, Overtimeservice en el método PostOvertime, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al crear el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<List<DisciplinaryProcessDto>>> GetByStatusAndAuthorizing(GetByStatusAndAuthorizingDisciplinaryProcessQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<DisciplinaryProcessDto>>();
            var time = new DateTime();

            try
            {
                var source = new List<DisciplinaryProcessDto>();
                if (request.StartDate.Date != time && request.EndDate.Date != time)
                {
                    source = _mapper.Map<List<DisciplinaryProcessDto>>(await _unitOfWork.DisciplinaryProcessRepository.Get()
                                                    .Where(x => x.ProcessStatusId == request.ProcessStatusId && x.userProcessAuthorizingId == _userId && x.CreatedAt.Value.Date >= request.StartDate.Date && x.CreatedAt.Value.Date <= request.EndDate.Date)
                                                    .Include(x => x.TypeOfFault)
                                                    .Include(x => x.ProcessStatus)
                                                    .Include(x => x.UserProcessApplicant)
                                                    .Include(x => x.UserProcessAuthorizing)
                                                    .Include(x => x.UserProcessApproving)
                                                    .Include(x => x.TypeOfFailure)
                                                    .Include(x => x.ProcessSupport)
                                                    .OrderByDescending(x => x.TypeOfFault).ToListAsync());
                }
                else
                {
                    source = _mapper.Map<List<DisciplinaryProcessDto>>(await _unitOfWork.DisciplinaryProcessRepository.Get()
                                                    .Where(x => x.ProcessStatusId == request.ProcessStatusId && x.userProcessAuthorizingId == _userId)
                                                    .Include(x => x.TypeOfFault)
                                                    .Include(x => x.ProcessStatus)
                                                    .Include(x => x.UserProcessApplicant)
                                                    .Include(x => x.UserProcessAuthorizing)
                                                    .Include(x => x.UserProcessApproving)
                                                    .Include(x => x.TypeOfFailure)
                                                    .Include(x => x.ProcessSupport)
                                                    .OrderByDescending(x => x.TypeOfFault).ToListAsync());
                }

                response.Data = source;
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, Overtimeservice en el método PostOvertime, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al crear el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<List<DisciplinaryProcessDto>>> GetByStatusAndApproving(GetByStatusAndApprovingDisciplinaryProcessQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<DisciplinaryProcessDto>>();
            var time = new DateTime();

            try
            {
                var source = new List<DisciplinaryProcessDto>();
                if (request.StartDate.Date != time && request.EndDate.Date != time)
                {
                    source = _mapper.Map<List<DisciplinaryProcessDto>>(await _unitOfWork.DisciplinaryProcessRepository.Get()
                                                    .Where(x => x.ProcessStatusId == request.ProcessStatusId && x.userProcessApprovingId == _userId && x.CreatedAt.Value.Date >= request.StartDate.Date && x.CreatedAt.Value.Date <= request.EndDate.Date)
                                                    .Include(x => x.TypeOfFault)
                                                    .Include(x => x.ProcessStatus)
                                                    .Include(x => x.UserProcessApplicant)
                                                    .Include(x => x.UserProcessAuthorizing)
                                                    .Include(x => x.UserProcessApproving)
                                                    .Include(x => x.TypeOfFailure)
                                                    .Include(x => x.ProcessSupport)
                                                    .OrderByDescending(x => x.TypeOfFault).ToListAsync());
                }
                else
                {
                    source = _mapper.Map<List<DisciplinaryProcessDto>>(await _unitOfWork.DisciplinaryProcessRepository.Get()
                                                .Where(x => x.ProcessStatusId == request.ProcessStatusId && x.userProcessApprovingId == _userId)
                                                .Include(x => x.TypeOfFault)
                                                .Include(x => x.ProcessStatus)
                                                .Include(x => x.UserProcessApplicant)
                                                .Include(x => x.UserProcessAuthorizing)
                                                .Include(x => x.UserProcessApproving)
                                                .Include(x => x.TypeOfFailure)
                                                .Include(x => x.ProcessSupport)
                                                .OrderByDescending(x => x.TypeOfFault).ToListAsync());
                }

                response.Data = source;
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, Overtimeservice en el método PostOvertime, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al crear el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<DisciplinaryProcess> GetByIdProcess1(int Id)
        {
            return await _unitOfWork.DisciplinaryProcessRepository
                                        .Get()
                                        .FirstOrDefaultAsync(x => x.Id == Id);

        }

        public async Task<ApiResponse<string>> SavePdf(IFormFile file)
        {
            var response = new ApiResponse<string>();

            try
            {
                string UrlPath = @"Resources\\PublicFiles\\SoportesProcesoDisciplinario";
                string Pathfinal = Path.Combine(Directory.GetCurrentDirectory(), UrlPath);

                string name = "17_SOLPRO_";

                var fullPath = "";

                if (file.Length > 0)
                {
                    // Se valida si la ruta existe o si no se crea.
                    if (!Directory.Exists(Pathfinal))
                        Directory.CreateDirectory(Pathfinal);

                    fullPath = Path.Combine(Pathfinal, name + file.FileName);
                    using var stream = new FileStream(fullPath, FileMode.Create);
                    file.CopyTo(stream);
                }

                response.Data = "";
                response.Result = true;
                response.Message = "OK";

                response.Url = fullPath;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al Guardar el documento, DisciplinaryProcessService en el método SavePdf, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }
            return await Task.Run(() => response);
        }

        public async Task<ApiResponse<string>> SavePdfCopy(List<IFormFile> files, string prefix, string Id)
        {
            var response = new ApiResponse<string>();

            try
            {
                string UrlPath = @"Resources\\PublicFiles\\SoportesProcesoDisciplinario";
                string Pathfinal = Path.Combine(Directory.GetCurrentDirectory(), UrlPath);

                string name = Id + prefix;

                var fullPath = "";

                if (files.Count > 0)
                {

                    foreach (var file in files)
                    {

                        // Se valida si la ruta existe o si no se crea.
                        if (!Directory.Exists(Pathfinal))
                            Directory.CreateDirectory(Pathfinal);

                        fullPath = Path.Combine(Pathfinal, name + file.FileName);
                        using var stream = new FileStream(fullPath, FileMode.Create);
                        file.CopyTo(stream);

                    }
                
                }

                response.Data = "";
                response.Result = true;
                response.Message = "OK";

                response.Url = fullPath;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al Guardar el documento, DisciplinaryProcessService en el método SavePdf, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }
            return await Task.Run(() => response);
        }

        public async Task<ApiResponse<string>> SavePdf(IFormFile file, string prefix, string Id)
        {
            var response = new ApiResponse<string>();

            try
            {
                string UrlPath = @"Resources\\PublicFiles\\SoportesProcesoDisciplinario";
                string Pathfinal = Path.Combine(Directory.GetCurrentDirectory(), UrlPath);

                string name = Id + prefix;

                var fullPath = "";

                if (file.Length > 0)
                {
                    // Se valida si la ruta existe o si no se crea.
                    if (!Directory.Exists(Pathfinal))
                        Directory.CreateDirectory(Pathfinal);

                    fullPath = Path.Combine(Pathfinal, name + file.FileName);
                    using var stream = new FileStream(fullPath, FileMode.Create);
                    file.CopyTo(stream);
                }

                response.Data = "";
                response.Result = true;
                response.Message = "OK";

                response.Url = fullPath;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al Guardar el documento, DisciplinaryProcessService en el método SavePdf, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }
            return await Task.Run(() => response);
        }

        public async Task<int> getIdProcess()
        {


            var source = await _unitOfWork.DisciplinaryProcessRepository.Get().MaxAsync(x => x.Id);



            return source;
        }

        public async Task<bool> SendEmail(GetSendEmailDisciplinaryProcessQuery request, CancellationToken cancellationToken)
        {

            correo correo = new correo();

            // _Correo correo = new _Correo()
            {
                correo.ServerName = "smtp.office365.com";
                correo.Port = "587";
                correo.SenderEmailId = "no-reply@uno27.com";
                correo.SenderPassword = "N0=R3Pl$y";
                //correo.IMG = "Resources/PublicFiles/Images/Icono Bienvenida Fondo Blanco .png";
            };

            try
            {
                var smtpServerName = correo.ServerName;
                var port = correo.Port;
                var senderEmailId = correo.SenderEmailId;
                var senderPassword = correo.SenderPassword;

                MailMessage mail = new MailMessage();
                mail.From = new System.Net.Mail.MailAddress("no-reply@uno27.com");
                mail.Subject = "Notificación Solicitud de Proceso - Uno27 S.A.S";
                // The important part -- configuring the SMTP client
                SmtpClient smtp = new SmtpClient();
                smtp.Port = Int32.Parse(port);   // [1] You can try with 465 also, I always used 587 and got success
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network; // [2] Added this
                smtp.UseDefaultCredentials = false; // [3] Changed this
                smtp.Credentials = new NetworkCredential(senderEmailId, senderPassword);  // [4] Added this. Note, first parameter is NOT string.
                smtp.Host = smtpServerName;
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;


                //recipient address . el problema es el correo electronico.
                mail.To.Add(new MailAddress(request.Email));

                string request1 = "Se ha generado una Solicitude proceso #1234567.";
                string contact = "Si no has enviado esta solicitud o necesitas más información, no dudes en visitar nuestras instalaciones o contactarse con nuestra atención al usuario.";
                string enunciado = "Para restablecer tu contraseña, por favor copia el siguiente código ";
                string enunciado2 = " y luego inicia sesión en nuestro aplicativo ";
                string grax = "Muchas gracias,";
                string team = " Humans - Procesos disciplinarios";

                /*AlternateView plainView =
                     AlternateView.CreateAlternateViewFromString(text,
                                             Encoding.UTF8,
                                             MediaTypeNames.Text.Plain);*/

                string names = "";

                string code = "";
                string html = "<p>"
                                    + "Hola " + "<b>" + names + "</b>" + ","
                                    + "<br>" + "<br>"
                                    + request1
                                    + "<br>"
                                    + contact
                                    + "<br>"
                                    + enunciado + "<b>" + code + "</b>" + enunciado2 + "<a href='https://example.com'>Portal hojas de vida UNO27</a>"
                                    + "<br>" + "<br>"
                                    + grax
                                    + "<br>"
                                    + "<b>" + team + "</b>" +
                             "</p>" +
                              "<img src='cid:imagen' width='320' height='220' />";

                AlternateView htmlView =
                    AlternateView.CreateAlternateViewFromString(html,
                                            Encoding.UTF8,
                                            MediaTypeNames.Text.Html);
                //string Evidencia = "Email.png";
                //var ruta = Path.Combine(HttpContext.Current.Server.MapPath("~/Content/public"), Path.GetFileName(Evidencia));


                //var path = Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName);

                //var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().CodeBase);

                var logoimage = Path.Combine(Directory.GetCurrentDirectory(), correo.IMG);

                string relLogo = new Uri(logoimage).LocalPath;

                LinkedResource img = new LinkedResource(relLogo, MediaTypeNames.Image.Jpeg);
                //img.ContentId = "imagen";
                img.ContentId = "imagen";


                //htmlView.LinkedResources.Add(img);
                htmlView.LinkedResources.Add(img);


                //mail.AlternateViews.Add(plainView);
                mail.AlternateViews.Add(htmlView);

                smtp.Send(mail);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}", ex.ToString());
            }

            return await Task.Run(() => true);
        }

        public async Task<bool> SendEmailDisciplinaryprocess(EmailBodyDto EmailBody)
        {
            correo correo = new correo();
            {
                correo.ServerName = "smtp.office365.com";
                correo.Port = "587";
                correo.SenderEmailId = "no-reply@uno27.com";
                correo.SenderPassword = "N0=R3Pl$y";
                correo.IMG = "Resources/PublicFiles/Images/uno27_logo.png";
            };

            try
            {
                var smtpServerName = correo.ServerName;
                var port = correo.Port;
                var senderEmailId = correo.SenderEmailId;
                var senderPassword = correo.SenderPassword;

                MailMessage mail = new MailMessage();
                mail.From = new System.Net.Mail.MailAddress("no-reply@uno27.com");
                mail.Subject = EmailBody.Subject;



                // The important part -- configuring the SMTP client
                SmtpClient smtp = new SmtpClient();

                smtp.Port = Int32.Parse(port);
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(senderEmailId, senderPassword);
                smtp.Host = smtpServerName;

                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                if (EmailBody.Email != null)
                {
                    if (validateEmail(EmailBody.Email))
                        mail.To.Add(new MailAddress(EmailBody.Email));
                }
                else if (EmailBody.UserRol.Count > 0)
                {
                    foreach (var item in EmailBody.UserRol)
                    {
                        if (validateEmail(item.Email))
                        {
                            MailAddress bcc = new MailAddress(item.Email);
                            mail.To.Add(bcc);
                        }
                    }
                }

                string request = EmailBody.Body + " " + "<b>" + EmailBody.NameAplicant + "</b>";
                string requesttwo = "Implicado en el proceso: " + "<b>" + EmailBody.NameUser + "</b>";
                string contact = "Falta: " + EmailBody.Fault;
                string enunciado = "Descripción de la Falta: " + EmailBody.DescriptionOfTheFault;
                string enunciado2 = "Fecha de Solicitud: " + EmailBody.StatusDate.ToString();
                string grax = "Ingrese a " + "<a href='" + EmailBody.url + "'>Humans Uno27</a>" + " para ver la solicitud  del proceso. ";
                string team = "Muchas gracias, " + " <br>" + "<br>" + "Humans - Uno27 -  Procesos disciplinarios";

                string code = "";
                string html = " <p>"
                                    + "Hola" + "<b>" + "</b>" + ", "
                                    + "<br>" + "<br>"
                                    + request
                                    + "<br>" + "<br>"
                                    + requesttwo
                                    + "<br>"
                                    + contact
                                    + "<br>"
                                    + enunciado + "<b>" + code + "</b>" + "<br>" + enunciado2 + ""
                                    + "<br>" + "<br>"
                                    + grax
                                    + "<br>" + "<br>"
                                    + "<b>" + team + "</b>"
                                    + "</p>"
                                    + "<img src='cid:imagen' width='300' height='166' />";

                AlternateView htmlView =
                    AlternateView.CreateAlternateViewFromString(html,
                                            Encoding.UTF8,
                                            MediaTypeNames.Text.Html);


                var logoimage = Path.Combine(Directory.GetCurrentDirectory(), correo.IMG);

                string relLogo = new Uri(logoimage).LocalPath;

                LinkedResource img = new LinkedResource(relLogo, MediaTypeNames.Image.Jpeg);

                img.ContentId = "imagen";

                htmlView.LinkedResources.Add(img);

                mail.AlternateViews.Add(htmlView);

                smtp.Send(mail);///
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTimeoutTestMessage(): {0}", ex.ToString());
            }

            return await Task.Run(() => true);
        }

        public bool validateEmail(string email)
        {
            if (email == null)
            {
                return false;
            }
            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<ApiResponse<List<DisciplinaryProcessDto>>> GetDisciplinaryProcessByDate(GetDisciplinaryProcessByDateQuery request, CancellationToken cancellation)
        {
            var response = new ApiResponse<List<DisciplinaryProcessDto>>();

            try
            {

                var source = _mapper.Map<List<DisciplinaryProcessDto>>(await _unitOfWork.DisciplinaryProcessRepository.Get()
                                                                            .Where(x => x.CreatedAt.Value.Date >= request.StartDate.Date && x.CreatedAt.Value.Date <= request.EndDate.Date && x.ProcessStatusId == request.Status)
                                                                            .Include(x => x.TypeOfFault)
                                                                            .Include(x => x.ProcessStatus)
                                                                            .Include(x => x.ProcessSupport)
                                                                            .Include(x => x.UserProcessApplicant)
                                                                            .Include(x => x.UserProcessAuthorizing)
                                                                            .Include(x => x.UserProcessApproving)
                                                                            .Include(x => x.TypeOfFailure)
                                                                            .OrderByDescending(x => x.CreatedAt)
                                                                            .ToListAsync());

                response.Data = source;
                response.Result = true;
                response.Message = "OK";

            }
            catch (Exception ex)
            {

                throw;
            }

            return response;
        }

    }
}

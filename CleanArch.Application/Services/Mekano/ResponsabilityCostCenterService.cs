using Application.Common.Response;
using Application.Core.Exceptions;
using Application.Cqrs.Mekano.Queries;
using Application.Cqrs.ResponsabilitiesCostCenter.Commands;
using Application.DTOs.Mekano;
using Application.DTOs.User;
using Application.Interfaces.Mekano;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Domain.Interfaces.User;
using Domain.Models.Mekano;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Mekano
{
    public class ResponsabilityCostCenterService : IResponsabilityCostCenterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        private readonly IUserRepository _userRepository;
        public ResponsabilityCostCenterService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<ResponsabilityCostCenter> logger, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _userRepository = userRepository;

        }
        public async Task<ApiResponse<ResponsabilityCostCenterDto>> PostResponsability(PostResponsabilityCostCenterCommand request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<ResponsabilityCostCenterDto>();
            try 
            {               
                bool exists = await CheckUserCostCenterExistsById(request.CostCenterId, request.UserId);

                if(exists)
                {
                    throw new BadRequestException("El usuario ya es Responsable del Centro de Costos ingresado");
                 
                }
                else
                {
                    response.Data = _mapper.Map<ResponsabilityCostCenterDto>(await _unitOfWork.responsabilityCostCenter.Add(_mapper.Map<ResponsabilityCostCenter>(request)));
                    response.Message = "OK";
                    response.Result = true;
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, ResponsabilityCostCenterService en el método PostResponsability, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al crear el registro, consulte con el administrador  { ex.Message } ";
            }

            return response;
        }

        /// <summary>
        /// Método para validar si el usuario existe en la tabla de base de datos.
        /// Validamos si dicho usuario posee permisos.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<bool> CheckById(Guid? Id)
        {
            return await _userRepository.Get().Where(c => c.Id == Id).CountAsync() > 0 ? true : false;
        }

        public async Task<ApiResponse<List<ResponsabilityCostCenterDto>>> Get(string document)
        {
            var response = new ApiResponse<List<ResponsabilityCostCenterDto>>();

            try
            {
                var user = GetUserByDocument(document)?? throw new NotFoundException(" La entidad no se puede consultar");

                var source= _mapper.Map<List<ResponsabilityCostCenterDto>>(await _unitOfWork.responsabilityCostCenter.Get().Where(x => x.UserId == user.Id)
                    .OrderByDescending(x => x.CreatedAt)
                    .ProjectTo<ResponsabilityCostCenterDto>(_mapper.ConfigurationProvider)
                    .ToListAsync());

                if (source.Count>0)
                {
                    response.Data = source;
                    response.Result = true;
                    response.Message = "OK";

                }
                else
                    throw new NotFoundException(" El usuario no tiene centro de costos asignado");
                       
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el registro, ResponsabilityCostCenterService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al realizar la consulta, consulte con el administrador  { ex.Message } ";

            }
            return response;     
        }

        public async Task<ApiResponse<List<ResponsabilityCostCenterDto>>> GetAll()
        {
            var response = new ApiResponse<List<ResponsabilityCostCenterDto>>();

            try
            {

                var source = _mapper.Map<List<ResponsabilityCostCenterDto>>(
                            await _unitOfWork.responsabilityCostCenter.Get()
                                                                      .OrderByDescending(x => x.CostCenter)
                                                                      .ProjectTo<ResponsabilityCostCenterDto>(_mapper.ConfigurationProvider)
                                                                      .ToListAsync());
            
                response.Data = _mapper.Map<List<ResponsabilityCostCenterDto>>(source);
                response.Result = true;
                response.Message = "OK";

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el registro, ResponsabilityCostCenterService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al realizar la consulta, consulte con el administrador  { ex.Message } ";

            }
            return response;
        }

        public UserDto GetUserByDocument(string document)
        {
            UserDto user = new UserDto();

            user = _userRepository
                      .Get()
                      .Where(c => c.Document == document.Trim())
                      .ProjectTo<UserDto>(_mapper.ConfigurationProvider)
                      .FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Método para validar si el usuario de sesión posee permisos
        /// para realizar procedimientos sobre dicho centro de costos.
        /// </summary>
        /// <param name="costCenterId"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> CheckUserCostCenterExistsById(int costCenterId, Guid id)
        {
            var res= await _unitOfWork.responsabilityCostCenter
                .Get()
                .Where(x => x.CostCenterId == costCenterId && x.UserId == id)
                .CountAsync() > 0 ? true : false;
            return res;
        }


        public async Task<ApiResponse<List<ResponsabilityCostCenterDto>>> GetAllByUser()
        {
            var response = new ApiResponse<List<ResponsabilityCostCenterDto>>();
         
            try
            {

                //var source = await _unitOfWork.responsabilityCostCenter.Get()                                                                    
                //                                                      .GroupBy(x => new { x.UserId,x.CostCenterId,x.User.Names,x.CostCenter.Name}) 
                //                                                      .Select( g => new ResponsabilityCostCenterDto ()
                //                                                                { 
                //                                                                    UserId = g.Key.UserId,
                //                                                                    CostCenterId =  g.Key.CostCenterId,
                //                                                                    NamesUser = g.Key.Names,
                //                                                                    NameCostCenter = g.Key.Name,
                //                                                                })
                //                                                      .OrderBy(x=> x.UserId)
                //                                                      .ToListAsync();

                var source = _mapper.Map<List<ResponsabilityCostCenterDto>>(
                             await _unitOfWork.responsabilityCostCenter.Get()
                                                                       .OrderByDescending(x => x.User)
                                                                       .ProjectTo<ResponsabilityCostCenterDto>(_mapper.ConfigurationProvider)
                                                                       .ToListAsync());

                response.Data = _mapper.Map<List<ResponsabilityCostCenterDto>>(source);
                response.Result = true;
                response.Message = "OK";

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el registro, ResponsabilityCostCenterService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al realizar la consulta, consulte con el administrador,  { ex.Message } ";
            }
            return response;
        }
        
    }
    
}


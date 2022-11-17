using Application.Common.Response;
using Application.Core.Exceptions;
using Application.Interfaces.Mekano;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Domain.Models.Mekano;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Mekano
{
    public class MekanoUserService : IMekanoUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentUserService _currentUserService;
        private readonly IResponsabilityCostCenterService _responsabilityCostCenterService;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private Guid _userId;
        private string _createdUpdateByName;

        public MekanoUserService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MekanoUserService> logger, 
            IResponsabilityCostCenterService responsabilityCostCenterService, ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _responsabilityCostCenterService = responsabilityCostCenterService;
            _userId = (Guid)_currentUserService.GetUserInfo().Id;
            _createdUpdateByName = _currentUserService.GetUserInfo().Name;
            
        }

        public async Task<bool> checkByDocumentExists(string document)
        {
            return await _unitOfWork.MekanoUserRepository.Get()
                             .Where(x => x.Document.Trim() == document.Trim())
                             .CountAsync() > 0 ? true : false;

        }

        public async Task<ApiResponse<MekanoUser>> GetByIdMekanoUser(string document)
        {
            var response = new ApiResponse<MekanoUser>();
            var exists = await checkByDocumentExists(document);

            try
            {
                if(exists)
                {
                    response.Data = await _unitOfWork.MekanoUserRepository.Get()
                                                                          .Where(x => x.Document == document.Trim() && x.Active == true)
                                                                          .FirstOrDefaultAsync();
                    response.Result = true;
                    response.Message = "OK";

                }
                else
                    throw new BadRequestException("El documento ingresado no existe.");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el registro, CostCenterService en el método GetByIdMekanoUser, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al Obtener el Registro, consulte con el administrador  { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<bool>> GetValidateResponsibleCostCenter(int CostCenterUserId)
        {

            var response = new ApiResponse<bool>();
                    
            try
            {
                var result = await _unitOfWork.responsabilityCostCenter.Get()
                                                             .CountAsync(x => x.CostCenterId == CostCenterUserId && x.UserId == _userId) != 0;
                if (result)
                {
                    response.Data = result;
                    response.Result = true;
                    response.Message = "OK";

                }
                else
                    throw new BadRequestException("El Solicitante del proceso no pertenece al centro de costos del usuario.");

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el registro, CostCenterService en el método GetByIdMekanoUser, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al Obtener el Registro, consulte con el administrador  { ex.Message } ";
            }

            return response;


        }
    }
}

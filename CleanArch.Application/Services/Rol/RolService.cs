using Application.Common.Response;
using Application.Core.Exceptions;
using Application.Cqrs.Rol.Commands;
using Application.DTOs.User;
using Application.Interfaces.Rol;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Domain.Interfaces.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Rol
{
    public class RolService : IRolService
    {
        private readonly IRolRepository _rolRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _autoMapper;
        private readonly ILogger _logger;


        public RolService(
            IRolRepository rolRepository,
            IMapper autoMapper,
            IUnitOfWork unitOfWork,
            ILogger<RolService> logger
        )
        {
            _rolRepository = rolRepository;
            _autoMapper = autoMapper;
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        public bool CheckById(Guid? Id)
        {
            return _rolRepository
                    .Get()
                    .Where(c => c.Id == Id)
                    .Count() == 0 ? false : true;
        }

        public Domain.Models.Rol.Rol GetById(Guid Id)
        {
            return _rolRepository
                     .Get()
                     .Where(c => c.Id == Id)
                     .FirstOrDefault();
        }

        public  async Task<ApiResponse<List<RolDto>>> Get()
        {
            var response = new ApiResponse<List<RolDto>>();

            try
            {
                response.Data =  await _unitOfWork.RolRepository.Get()
                                                                .ProjectTo<RolDto>(_autoMapper.ConfigurationProvider)
                                                                .ToListAsync();

                response.Message = "OK";
                response.Result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al cargar los registros, RolService en el método Get, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al obtener los registros, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<RolDto>> PostRol(PostRolCommand rolCommand)
        {
            var response = new ApiResponse<RolDto>();
            try
            {
                response.Data =  _autoMapper.Map<RolDto>(await _unitOfWork.RolRepository
                                            .Add(_autoMapper.Map<Domain.Models.Rol.Rol>(rolCommand)));

                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, RolService en el método PostRol, { ex.Message } ");      
                response.Result = false;
                response.Message = $"Error al crear el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<RolDto>> PutRol(PutRolCommand rolCommand)
        {
            var response = new ApiResponse<RolDto>();
            try
            {
                response.Data =  _autoMapper.Map<RolDto>(await _unitOfWork.RolRepository
                              .Put(_autoMapper.Map<PutRolCommand, Domain.Models.Rol.Rol>(rolCommand, await GetRolById(rolCommand.Id))));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al editar el registro, RolService en el método PutRol, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
            
        }

        public async Task<ApiResponse<bool>> DeleteRol(Guid id)
        {
            var response = new ApiResponse<bool>();
            try
            {
                response.Data = await _unitOfWork.RolRepository.Delete(_autoMapper.Map<Domain.Models.Rol.Rol>(await GetRolById(id)));
                response.Result = true;
                response.Message = "OK";

            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al eliminar el registro, RolService en el método DeleteRol, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al eliminar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<RolDto>> PutStatusActivateRolById(PutStatusActivateRolById request)
        {
            var response = new ApiResponse<RolDto>();
            try
            {
                response.Data = _autoMapper.Map<RolDto>(_rolRepository
                          .PutStatusActivateRolById(_autoMapper.Map<PutStatusActivateRolById, Domain.Models.Rol.Rol>(request, await GetRolById(request.Id))));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al cambiar de estado el registro, RolService en el método PutStatusActivateRolById, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        
        }

        public async Task<ApiResponse<RolDto>> PutStatusDeactivateRolById(PutStatusDeactivateRolById request)
        {
            var response = new ApiResponse<RolDto>();
            try
            {
                response.Data = _autoMapper.Map<RolDto>(_rolRepository
                            .PutStatusDeactivateRolById(_autoMapper.Map<PutStatusDeactivateRolById, Domain.Models.Rol.Rol>(request, await GetRolById(request.Id))));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al cambiar de estado el registro, RolService en el método PutStatusDeactivateRolById, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
          
        }

        private async Task<Domain.Models.Rol.Rol> GetRolById(Guid id)
        {
            return await _unitOfWork.RolRepository.GetById(id) ?? throw new NotFoundException("La entidad a procesar no existe");
        }
    }
}

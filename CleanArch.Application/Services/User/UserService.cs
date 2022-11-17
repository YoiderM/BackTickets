using Application.Common.Response;
using Application.Core.Exceptions;
using Application.Cqrs.User.Commands;
using Application.DTOs.Mekano;
using Application.DTOs.User;
using Application.Interfaces.User;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Domain.Interfaces.User;
using Domain.Models.Mekano;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRolService _userRolService;
        private readonly IMapper _autoMapper;
        private readonly ICurrentUserService _currentUser;
        private readonly ILogger _logger;

        private Guid? CreatedBy = null;
        private Guid? UpdatedBy = null;
        public UserService(
            IUserRepository userRepository,
            IUserRolService userRolService,
            ICurrentUserService currentUser,
            IUnitOfWork unitOfWork,
            IMapper autoMapper,
            ILogger<UserService> logger

            )
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
            _userRolService = userRolService;
            _currentUser = currentUser;
            _autoMapper = autoMapper;
            CreatedBy = _currentUser.GetUserInfo().Id;
            UpdatedBy = _currentUser.GetUserInfo().Id;
            _logger = logger;


        }
        public async Task<ApiResponse<List<UserDto>>> GetUser(int without)
        {
            var response = new ApiResponse<List<UserDto>>();

            try
            {
                var source = _unitOfWork.UserRepository.Get();
 
                response.Data = without == 1 ?  await source.ProjectTo<UserDto>(_autoMapper.ConfigurationProvider).ToListAsync()
                                              : await source.Where(x => x.Status).ProjectTo<UserDto>(_autoMapper.ConfigurationProvider).ToListAsync();

                response.Message = "OK";
                response.Result = true;                
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al cargar los registros, UserService en el método GetUser, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public async Task<ApiResponse<List<UserResponsabilityCostCenterDto>>> GetUserByCostCenter()
        {
            var response = new ApiResponse<List<UserResponsabilityCostCenterDto>>();

            try
            {
                var source = await _unitOfWork.UserRepository.Get().ProjectTo<UserResponsabilityCostCenterDto>(_autoMapper.ConfigurationProvider).ToListAsync();

                response.Data = source;
                response.Message = "OK";
                response.Result = true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al cargar los registros, UserService en el método GetUser, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;
        }

        public UserDto GetUserByDocumentAndSubcampaign(string document, int subCampaignId)
        {
            UserDto users = new UserDto();

            users = _userRepository
                      .Get()
                      .Where(c => c.Document == document.Trim())
                      .ProjectTo<UserDto>(_autoMapper.ConfigurationProvider)
                      .FirstOrDefault();
            return users;

        }
        public bool CheckById(Guid? Id)
        {
            return _userRepository
                    .Get()
                    .Where(c => c.Id == Id)
                    .Count() == 0 ? false : true;
        }
        public async Task<ApiResponse<UserDto>> PostUser(Domain.Models.User.User user)
        {
            var response = new ApiResponse<UserDto>();

            try
            {
                user.CreatedBy = CreatedBy;
          
                response.Data = _autoMapper.Map<UserDto>(await _unitOfWork.UserRepository.Add(user));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, UserService en el método PostUser, { ex.Message } ");             
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;


        }
        public async Task<ApiResponse<UserDto>> PutStatusActivateUserById(PutStatusActivateUserById request)
        {
            var response = new ApiResponse<UserDto>();

            var user = await GetUserById(request.Id) ?? throw new NotFoundException("El registro a procesar no existe");
            try
            {

                user = _autoMapper.Map<PutStatusActivateUserById, Domain.Models.User.User>(request, user);
                user.UpdatedBy = UpdatedBy;
                user.UpdatedAt = DateTime.Now;

                response.Data = _autoMapper.Map<UserDto>(await _userRepository.PutStatusActivateUserById(user));
                response.Message = "OK";
                response.Result = true;
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al activar el usuario, UserService en el método PutStatusDeactivateUserById, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";

            }

            return response;

           
        }
        public async Task<ApiResponse<UserDto>> PutStatusDeactivateUserById(PutStatusDeactivateUserById request)
        {

            var response = new ApiResponse<UserDto>();

            var user = await GetUserById(request.Id) ?? throw new NotFoundException("El registro a procesar no existe");
            try
            {
                user = _autoMapper.Map<PutStatusDeactivateUserById, Domain.Models.User.User>(request, user);
                user.UpdatedBy = CreatedBy;
                user.UpdatedAt = DateTime.Now;
               
                response.Data= _autoMapper.Map<UserDto>(await _userRepository.PutStatusDeactivateUserById(user));
                response.Result = true;
                response.Message = "OK";
                 
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al inactivar el usuario, UserService en el método PutStatusDeactivateUserById, { ex.Message } ");             
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;  
        }
        public async Task<ApiResponse<UserDto>> PutUser(PutUserCommand request)
        {
            var response = new ApiResponse<UserDto>();

            try
            {
                var user = await GetUserById(request.Id) ?? throw new NotFoundException("El registro a procesar no existe");
                DeleteUserRolRange(user.Id);
                PostUserRolRange(request);

                response.Data = await UpdateUser(user, request);
                response.Result = true;
                response.Message = "OK";             
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el registro, UserService en el método PutUser, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }

            return response;

        }
        public Domain.Models.User.User PutUserExcel(UserDto userDto)
        {
            var user = _autoMapper.Map<Domain.Models.User.User>(userDto);
            _userRepository.Put(user);

            return user;
        }
        public async Task<ApiResponse<bool>> DeleteUser(Guid id)
        {

            var response = new ApiResponse<bool>();

            try
            {
                var user = await GetUserById(id); //?? throw new NotFoundException("El registro a procesar no existe");
                //_userRolService.DeleteRangeByUserId(user.Id);

                DeleteUserRolRange(user.Id);

                response.Data = await _unitOfWork.UserRepository.Delete(await GetUserById(id));
                response.Result = true;
                response.Message = "OK";
                //return await _unitOfWork.UserRepository.Delete(await GetUserById(id));

            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al eliminar el registro, UserService en el método DeleteUser, { ex.Message } ");           
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";


            }

            return response;
        }
        public async Task<Domain.Models.User.User> GetUserById(Guid id)
        {
            return await _unitOfWork.UserRepository.GetById(id) ?? throw new NotFoundException("La entidad a procesar no existe");
        }
        public async Task<bool> CheckUserExistsByDocument(string document)
        {

            return await _unitOfWork.UserRepository.Get()
                                                   .Where(x => x.Document.Trim()
                                                   .Equals(document.Trim()))
                                                   .CountAsync() > 0 ? false : true; 

        }
        public async Task<bool> CheckUserExistsByDocumentInMekano(string document)
        {
            return await _userRepository.GetUsersMekano().Where(x => x.Document.Trim() == document.Trim() && x.Active == true)
                                                         .CountAsync() > 0 ? true : false;


        }
        public async Task<string> GetCampaignNameFromMekano(string document)
        {

            return await _userRepository.GetUsersMekano()
                                              .Where(x => x.Document.Trim() == document.Trim() && x.Active == true)
                                              .Select(x => x.Campaign)
                                              .FirstOrDefaultAsync();


        }
        private void PostUserRolRange(PutUserCommand request)
        {
            try
            {
                var ListUserRol = new List<UserRol>() { };

                foreach (var rol in request.Roles)
                {
                    ListUserRol.Add(new UserRol()
                    {
                        RolId = rol,
                        UserId = request.Id
                    });
                }

                if (ListUserRol.Count > 0) _userRolService.PostRange(ListUserRol);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al insertar listado de roles, UserService en el método PostUserRolRange, { ex.Message } ");
                throw new Exception($"{ ex.Message }");
            }
        }
        private void DeleteUserRolRange(Guid id)
        {
            try
            {
                _userRolService.DeleteRangeByUserId(id);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar listado de roles, UserService en el método DeleteUserRolRange, { ex.Message } ");
                throw new Exception($"{ ex.Message }");
            }
        }
        private async Task<UserDto> UpdateUser(Domain.Models.User.User user, PutUserCommand request)
        {
            try
            {
                user = _autoMapper.Map<PutUserCommand, Domain.Models.User.User>(request, user);
                user.UpdatedBy = CreatedBy;
                user.UpdatedAt = DateTime.Now;
                return _autoMapper.Map<UserDto>(await _unitOfWork.UserRepository.Put(user));
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al editar el usuario, UserService en el método UpdateUser, { ex.Message } ");
                throw new Exception($"{ ex.Message }");
            }
        }
        public  async Task<MekanoUser> GetUserByDocumentInMekano(string document)
        {
            return await _userRepository.GetUsersMekano()
                .Where(x => x.Document.Trim() == document.Trim() && x.Active == true).FirstOrDefaultAsync();
        }
    }
}

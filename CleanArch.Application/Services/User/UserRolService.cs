using Application.Core.Exceptions;
using Application.Cqrs.UserRol.Commands;
using Application.DTOs.User;
using Application.Interfaces.User;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.User;
using Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.User
{
    public class UserRolService : IUserRolService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRolRepository _userRolRepository;
        private readonly IMapper _mapper;

        public UserRolService(
            IUnitOfWork unitOfWork,
            IUserRolRepository userRolRepository,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _userRolRepository = userRolRepository;
            _mapper = mapper;
        }

        public async Task<UserRolDto> Post(AddUserRolCommand userRolCommand)
        {
            return _mapper.Map<UserRolDto>(await _unitOfWork.UserRolRepository.Add(_mapper.Map<UserRol>(userRolCommand)));
        }

        public List<UserRol> PostRange(List<UserRol> userRol)
        {
            return _userRolRepository.PostRange(userRol);
        }

        public async Task<UserRolDto> Put(UpdateUserRolCommand userRolCommand)
        {

            return _mapper.Map<UserRolDto>(await _unitOfWork.UserRolRepository
                          .Put(_mapper.Map<UpdateUserRolCommand, UserRol>(userRolCommand, await GetUserRolById(userRolCommand.Id))));

        }

        public async Task<bool> Delete(Guid id)
        {
            return await _unitOfWork.UserRolRepository.Delete(await GetUserRolById(id));
        }

        public bool DeleteRangeByUserId(Guid id)
        {
            var usersRol = _unitOfWork.UserRolRepository.Get()
                                                        .Where(x => x.UserId == id).ToList();

            if (usersRol.Count > 0)
            {
                return _userRolRepository.DeleteRange(usersRol);
            }

            return true;
        }

        private async Task<UserRol> GetUserRolById(Guid id)
        {
            return await _unitOfWork.UserRolRepository.GetById(id) ?? throw new NotFoundException("La entidad a procesar no existe");
        }


    }
}

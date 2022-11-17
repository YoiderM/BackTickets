using Application.Cqrs.UserRol.Commands;
using Application.DTOs.User;
using Domain.Models.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.User
{
    public interface IUserRolService
    {
        Task<UserRolDto> Post(AddUserRolCommand userRolCommand);
        Task<UserRolDto> Put(UpdateUserRolCommand userRolCommand);
        List<UserRol> PostRange(List<UserRol> userRol);
        Task<bool> Delete(Guid id);
        bool DeleteRangeByUserId(Guid id);
    }
}

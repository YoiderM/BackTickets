using Application.Common.Response;
using Application.Cqrs.Rol.Commands;
using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Rol
{
    public interface IRolService
    {
        Task<ApiResponse<List<RolDto>>> Get();
        Domain.Models.Rol.Rol GetById(Guid Id);
        Task<ApiResponse<RolDto>> PostRol(PostRolCommand rolCommand);
        Task<ApiResponse<RolDto>> PutRol(PutRolCommand rolCommand);
        Task<ApiResponse<bool>> DeleteRol(Guid id);
        bool CheckById(Guid? Id);
        Task<ApiResponse<RolDto>> PutStatusActivateRolById(PutStatusActivateRolById request);
        Task<ApiResponse<RolDto>> PutStatusDeactivateRolById(PutStatusDeactivateRolById request);
    }
}

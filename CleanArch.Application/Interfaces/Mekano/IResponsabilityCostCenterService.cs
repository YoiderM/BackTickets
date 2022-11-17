using Application.Common.Response;
using Application.Cqrs.ResponsabilitiesCostCenter.Commands;
using Application.DTOs.Mekano;
using Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Mekano
{
    public interface IResponsabilityCostCenterService
    {
        Task<ApiResponse<ResponsabilityCostCenterDto>> PostResponsability(PostResponsabilityCostCenterCommand request, CancellationToken cancellationToken);
        Task<ApiResponse<List<ResponsabilityCostCenterDto>>> Get(string document);
        Task<bool> CheckUserCostCenterExistsById(int costCenterId, Guid id);
        UserDto GetUserByDocument(string document);
        Task<bool> CheckById(Guid? Id);
        Task<ApiResponse<List<ResponsabilityCostCenterDto>>> GetAll();
       
        Task<ApiResponse<List<ResponsabilityCostCenterDto>>> GetAllByUser();
    }
}

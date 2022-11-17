using Application.Common.Response;
using Application.DTOs.Mekano;
using Domain.Models.Mekano;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Mekano
{
    public interface ICostCenterService
    {
        Task<ApiResponse<List<CostCenterDto>>> GetCostCenter();
        Task<ApiResponse<CostCenterDto>> GetById(int Id);
        Task<bool> checkById(int Id);
        
    }
}

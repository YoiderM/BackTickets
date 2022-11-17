using Application.Common.Response;
using Domain.Models.Mekano;
using System.Threading.Tasks;

namespace Application.Interfaces.Mekano
{
    public interface IMekanoUserService
    {
        Task<bool> checkByDocumentExists(string document);
        Task<ApiResponse<MekanoUser>> GetByIdMekanoUser(string document);

        Task<ApiResponse<bool>> GetValidateResponsibleCostCenter(int CostCenterUserId);
    }
}

using Application.Common.Response;
using Application.Cqrs.User.Commands;
using Application.DTOs.Mekano;
using Application.DTOs.User;
using Domain.Models.Mekano;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.User
{
    public interface IUserService
    {
        Task<ApiResponse<List<UserDto>>>GetUser(int without);

        Task<ApiResponse<List<UserResponsabilityCostCenterDto>>> GetUserByCostCenter();
        Task<ApiResponse<UserDto>> PostUser(Domain.Models.User.User user);
        Task<ApiResponse<UserDto>> PutUser(PutUserCommand request);
        Task<ApiResponse<bool>> DeleteUser(Guid id);
        Task<ApiResponse<UserDto>> PutStatusActivateUserById(PutStatusActivateUserById request);
        Task<ApiResponse<UserDto>> PutStatusDeactivateUserById(PutStatusDeactivateUserById request);
        Task<bool> CheckUserExistsByDocument(string document);
        Task<MekanoUser> GetUserByDocumentInMekano(string document);
        Task<bool> CheckUserExistsByDocumentInMekano(string document); 
        Task<string> GetCampaignNameFromMekano(string document); 
        UserDto GetUserByDocumentAndSubcampaign(string document, int subCampaignId);
        Domain.Models.User.User PutUserExcel(UserDto userDto);       
        bool CheckById(Guid? Id);
        Task<Domain.Models.User.User> GetUserById(Guid id);


    }
}

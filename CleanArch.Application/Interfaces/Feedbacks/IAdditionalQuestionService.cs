using Application.Common.Response;
using Application.DTOs.Feedbacks;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Feedbacks
{
    public interface IAdditionalQuestionService
    {
        Task<ApiResponse<List<AdditionalQuestionDto>>> GetAllAdditionalQuestion();
    }
}

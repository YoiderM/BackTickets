using Application.Common.Response;
using Application.Cqrs.Feedbacks.ResponseAdditionalQuestion.Queries;
using Application.DTOs.Feedbacks;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Feedbacks
{
    public interface IResponseAdditionalQuestionService
    {
        Task<ApiResponse<List<ResponseAdditionalQuestionDto>>> GetByResponseAccompanimentPlanIdResponseAdditionalQuestion(GetByResponseAccompanimentPlanIdResponseAdditionalQuestionQuery request, CancellationToken cancellationToken);
        Task PostResponseAdditionalQuestion(List<ResponseAdditionalQuestionDto> responseAdditionalQuestionDtos);
    }
}

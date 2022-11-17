using Application.Common.Response;
using Application.Cqrs.Feedbacks.ResponseQuestion.Queries;
using Application.DTOs.Feedbacks;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.Feedbacks
{
    public interface IResponseQuestionService
    {
        Task<ApiResponse<ResponseQuestionAndResponseAdditionalDto>> GetByResponseAccompanimentPlanIdResponseQuestion(GetByResponseAccompanimentPlanIdResponseQuestionQuery request, CancellationToken cancellationToken);
        Task PostResponseQuestion(List<ResponseQuestionDto> responseQuestionDto);
    }
}

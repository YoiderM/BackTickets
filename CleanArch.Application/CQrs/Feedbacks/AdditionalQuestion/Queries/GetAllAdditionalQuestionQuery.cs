using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.AdditionalQuestion.Queries
{
    public class GetAllAdditionalQuestionQuery : IRequest<ApiResponse<List<AdditionalQuestionDto>>>
    {
    }
    public class GetAllAdditionalQuestionQueryHandler : IRequestHandler<GetAllAdditionalQuestionQuery, ApiResponse<List<AdditionalQuestionDto>>>
    {
        private readonly IAdditionalQuestionService _additionalQuestionService;
        public GetAllAdditionalQuestionQueryHandler(IAdditionalQuestionService additionalQuestionService)
        {
            _additionalQuestionService = additionalQuestionService;
        }
        public Task<ApiResponse<List<AdditionalQuestionDto>>> Handle(GetAllAdditionalQuestionQuery request, CancellationToken cancellationToken)
        {
            return _additionalQuestionService.GetAllAdditionalQuestion();
        }
    }
}

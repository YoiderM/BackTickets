using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.ResponseAdditionalQuestion.Queries
{
    public class GetByResponseAccompanimentPlanIdResponseAdditionalQuestionQuery :IRequest<ApiResponse<List<ResponseAdditionalQuestionDto>>>
    {
        public int ResponseAccompanimentPlanId { get; set; }
    }
    public class GetByResponseAccompanimentPlanIdResponseAdditionalQuestionQueryHandle : IRequestHandler<GetByResponseAccompanimentPlanIdResponseAdditionalQuestionQuery, ApiResponse<List<ResponseAdditionalQuestionDto>>>
    {
        private readonly IResponseAdditionalQuestionService _responseAdditionalQuestionService;
        private readonly IMapper _mapper;
        public GetByResponseAccompanimentPlanIdResponseAdditionalQuestionQueryHandle(IResponseAdditionalQuestionService responseAdditionalQuestionService, IMapper mapper)
        {
            _responseAdditionalQuestionService = responseAdditionalQuestionService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<ResponseAdditionalQuestionDto>>> Handle(GetByResponseAccompanimentPlanIdResponseAdditionalQuestionQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ApiResponse<List<ResponseAdditionalQuestionDto>>>(await _responseAdditionalQuestionService.GetByResponseAccompanimentPlanIdResponseAdditionalQuestion(request, cancellationToken));
        }
    }
}

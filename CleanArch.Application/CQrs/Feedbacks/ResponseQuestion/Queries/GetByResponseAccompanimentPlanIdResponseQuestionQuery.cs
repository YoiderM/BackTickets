using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.ResponseQuestion.Queries
{
    public class GetByResponseAccompanimentPlanIdResponseQuestionQuery : IRequest<ApiResponse<ResponseQuestionAndResponseAdditionalDto>>
    {
        public int ResponseAccompanimentPlanId { get; set; }
    }
    public class GetByResponseAccompanimentPlanIdResponseQuestionQueryHandle : IRequestHandler<GetByResponseAccompanimentPlanIdResponseQuestionQuery, ApiResponse<ResponseQuestionAndResponseAdditionalDto>>
    {
        private readonly IResponseQuestionService _responseQuestionService;
        private readonly IMapper _mapper;
        public GetByResponseAccompanimentPlanIdResponseQuestionQueryHandle(IResponseQuestionService responseQuestionService, IMapper mapper)
        {
            _responseQuestionService = responseQuestionService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<ResponseQuestionAndResponseAdditionalDto>> Handle(GetByResponseAccompanimentPlanIdResponseQuestionQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ApiResponse<ResponseQuestionAndResponseAdditionalDto>>(await _responseQuestionService.GetByResponseAccompanimentPlanIdResponseQuestion(request, cancellationToken));
        }
    }
}

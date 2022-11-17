using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.ResponseAccompanimentPlan.Commands
{
    public class PostResponseAccompanimentPlanCommand : IRequest<ApiResponse<ResponseAccompanimentPlanDto>>
    {
        public int ResponseAccompanimentPlanId { get; set; }
        public int AccompanimentPlanId { get; set; }
        public DateTime ScheduledDate { get; set; }
        public DateTime StartDate { get; set; }
        public int TypeAccompanimentPlanId { get; set; }
        public string ConclusionsAndCommitments { get; set; }
        public List<ResponseQuestionDto> responseQuestions { get; set; }
        public List<ResponseAdditionalQuestionDto> responseAdditionalQuestions { get; set; }
    }
    public class PostResponseAccompanimentPlanCommandHandler : IRequestHandler<PostResponseAccompanimentPlanCommand, ApiResponse<ResponseAccompanimentPlanDto>>
    {
        private readonly IResponseAccompanimentPlanService _responseAccompanimentPlanService;
        public PostResponseAccompanimentPlanCommandHandler(IResponseAccompanimentPlanService responseAccompanimentPlanService)
        {
            _responseAccompanimentPlanService = responseAccompanimentPlanService;
        }
        public async Task<ApiResponse<ResponseAccompanimentPlanDto>> Handle(PostResponseAccompanimentPlanCommand request, CancellationToken cancellationToken)
        {
            return await _responseAccompanimentPlanService.PostResponseAccompanimentPlan(request, cancellationToken);
        }
    }
}

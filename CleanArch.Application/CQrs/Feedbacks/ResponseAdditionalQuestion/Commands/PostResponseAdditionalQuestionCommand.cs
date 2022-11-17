using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.ResponseAdditionalQuestion.Commands
{
    public class PostResponseAdditionalQuestionCommand : IRequest<ApiResponse<ResponseAdditionalQuestionDto>>
    {
        public string Question { get; set; }
        public string Response { get; set; }
        public int ResponseAccompanimentPlanId { get; set; }
    }
    public class PostResponseAdditionalQuestionCommandHandler : IRequestHandler<PostResponseAdditionalQuestionCommand, ApiResponse<ResponseAdditionalQuestionDto>>
    {
        private readonly IResponseAdditionalQuestionService _responseAdditionalQuestionService;
        public PostResponseAdditionalQuestionCommandHandler(IResponseAdditionalQuestionService responseAdditionalQuestionService)
        {
            _responseAdditionalQuestionService = responseAdditionalQuestionService;
        }

        public async Task<ApiResponse<ResponseAdditionalQuestionDto>> Handle(PostResponseAdditionalQuestionCommand request, CancellationToken cancellationToken)
        {
            return await _responseAdditionalQuestionService.PostResponseAdditionalQuestion(request, cancellationToken);
        }
    }
}

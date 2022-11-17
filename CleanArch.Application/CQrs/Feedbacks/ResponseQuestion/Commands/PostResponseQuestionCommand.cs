using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Feedbacks.ResponseQuestion.Commands
{
    public class PostResponseQuestionCommand : IRequest<ApiResponse<ResponseQuestionDto>>
    {
        public string Response { get; set; }
        public int QuestionnaireTemplateId { get; set; }
        public int QuestionnaireQuestionTemplateId { get; set; }
        public int ResponseAccompanimentPlanId { get; set; }
    }
    public class PostResponseQuestionCommandHandler : IRequestHandler<PostResponseQuestionCommand, ApiResponse<ResponseQuestionDto>>
    {
        private readonly IResponseQuestionService _responseQuestionService;
        public PostResponseQuestionCommandHandler(IResponseQuestionService responseQuestionService)
        {
            _responseQuestionService = responseQuestionService;
        }

        public async Task<ApiResponse<ResponseQuestionDto>> Handle(PostResponseQuestionCommand request, CancellationToken cancellationToken)
        {
            return await _responseQuestionService.PostResponseQuestion(request, cancellationToken);
        }
    }
}

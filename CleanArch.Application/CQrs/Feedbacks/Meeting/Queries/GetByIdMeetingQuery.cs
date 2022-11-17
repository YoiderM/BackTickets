using Application.Common.Response;
using Application.DTOs.Meetings;
using Application.Interfaces.Meetings;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Meetings.Meeting.Queries
{
    public class GetByIdMeetingQuery : IRequest<ApiResponse<MeetingDto>>
    {
        public int Id { get; set; }
    }
    public class GetByIdMeetingQueryHandler : IRequestHandler<GetByIdMeetingQuery, ApiResponse<MeetingDto>>
    {
        private readonly IMeetingService _meetingService;
        private readonly IMapper _mapper;
        public GetByIdMeetingQueryHandler(IMeetingService meetingService, IMapper mapper)
        {
            _meetingService = meetingService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<MeetingDto>> Handle(GetByIdMeetingQuery request, CancellationToken cancellationToken)
        {
            var meetingDto = _mapper.Map<ApiResponse<MeetingDto>>(await _meetingService.GetByIdMeeting(request, cancellationToken));
            var talkingAboutDto=0;
            return meetingDto;
        }
    }
}

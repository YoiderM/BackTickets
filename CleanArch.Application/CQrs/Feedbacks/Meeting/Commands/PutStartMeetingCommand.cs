using Application.Common.Response;
using Application.DTOs.Meetings;
using Application.Interfaces.Meetings;
using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Meetings.Meeting.Commands
{
    public class PutStartMeetingCommand : IRequest<ApiResponse<MeetingDto>>
    {
        public int id { get; set; }
    }
    public class PutStartMeetingCommandHandler : IRequestHandler<PutStartMeetingCommand, ApiResponse<MeetingDto>>
    {
        private readonly IMeetingService _meetingService;
        private readonly IMapper _mapper;
        public PutStartMeetingCommandHandler(IMeetingService meetingService, IMapper mapper)
        {
            _meetingService = meetingService;
            _mapper = mapper;
        }
        public async Task<ApiResponse<MeetingDto>> Handle(PutStartMeetingCommand request, CancellationToken cancellationToken)
        {
            return await _meetingService.PutStartMeeting(request, cancellationToken);
        }
    }
}

using Application.Common.Response;
using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriodDetail.Commands
{
    public class PostOvertimeCommand : IRequest<ApiResponse<OvertimeDetailDto>>
	{
		public bool? Aproved { get; set; } = false;
		public string Login { get; set; }	
		public string JobName { get; set; }
		public string Document { get; set; }
		public string Names { get; set; }
		public string Observation { get; set; }
		public string AuthObservation { get; set; }
		public string AdminObservation { get; set; }
		public bool? UserStatus { get; set; } = true;
		public int TotalHours { get; set; }
		public bool CompensatoryApplies { get; set; } = false;
		public bool SundayNumber1 { get; set; } = false;
		public bool SundayNumbre2 { get; set; } = false;
		public DateTime? LoginTime { get; set; }
		public DateTime? OvertimeDay { get; set; }
		public DateTime? InitialHour { get; set; }
		public DateTime? EndHour { get; set; }
		public Decimal? Salary { get; set; }
		public int Status { get; set; } = 1;
		public Guid OvertimeTypeId { get; set; }
		public int OvertimePeriodId { get; set; }
		public int CostCenterId { get; set; }


	}

	public class PostOvertimeCommandHandler : IRequestHandler<PostOvertimeCommand, ApiResponse<OvertimeDetailDto>>
	{
		private readonly IOvertimeService _overtimeService;

		public  PostOvertimeCommandHandler(IOvertimeService overtimeService)
		{
			_overtimeService = overtimeService;
		}

		public async Task<ApiResponse<OvertimeDetailDto>> Handle(PostOvertimeCommand request, CancellationToken cancellationToken)
		{
			return await _overtimeService.PostDetail(request);	
		}
	}
}

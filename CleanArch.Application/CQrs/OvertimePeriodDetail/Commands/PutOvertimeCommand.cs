using Application.Common.Response;
using Application.Interfaces.Overtimes;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriodDetail.Commands
{
    public class PutOvertimeCommand : IRequest<ApiResponse<Object>>
	{
		public Guid Id { get; set; }
		public bool? Aproved { get; set; }
		public string Login { get; set; }
		public string JobName { get; set; }
		public string Document { get; set; }
		public string Names { get; set; }
		public string Observation { get; set; }
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
		public int CostCenterId { get; set; }
		public Guid OvertimeTypeId { get; set; }
		public int OvertimePeriodId { get; set; }

	}

	public class PutOvertimeCommandHandle : IRequestHandler<PutOvertimeCommand, ApiResponse<Object>>
	{
	
		private readonly IOvertimeService _overtimeService;

		public  PutOvertimeCommandHandle(IOvertimeService overtimeService) => _overtimeService = overtimeService;
		public async Task<ApiResponse<Object>> Handle(PutOvertimeCommand request, CancellationToken cancellationToken)
		{		

			return await _overtimeService.PutOvertimeDetail(request, cancellationToken);

		}


	}
}

using Application.Common.Response;
using Application.DTOs.OvertimePeriods;
using Application.Interfaces.Overtimes;
using AutoMapper;
using Domain.Models.Overtimes;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriods.Commands
{
    public class CreateOvertimePeriodcommand : IRequest<ApiResponse<OvertimePeriodDto>>
	{
		public DateTime? StartAllowedDate { get; set; }
		public DateTime? EndAllowedDate { get; set; }
		public DateTime? StartPeriodDate { get; set; }
		public DateTime? EndPeriodDate { get; set; }
		public int? WeekNumber { get; set; }
		public int? fortnight { get; set; }
		public bool? IsOpen { get; set; }
		public bool? IsPaid { get; set; }
	}

	public class CreateOvertimePerodCommandHandle : IRequestHandler<CreateOvertimePeriodcommand, ApiResponse<OvertimePeriodDto>>
	{
		private readonly IOvertimePeriodService _overtimePeriodService;
		private readonly IMapper _mapper;
		public CreateOvertimePerodCommandHandle(
			IOvertimePeriodService overtimePeriodService,
			IMapper mapper
		)
		{
			_mapper = mapper;
			_overtimePeriodService = overtimePeriodService;

		}
		public async Task<ApiResponse<OvertimePeriodDto>> Handle(CreateOvertimePeriodcommand request, CancellationToken cancellationToken)
		{
			OvertimePeriod overtimePeriod = _mapper.Map<OvertimePeriod>(request);

			return _mapper.Map<ApiResponse<OvertimePeriodDto>>
				(await _overtimePeriodService.PostPeriod(request, cancellationToken));
		}
	}
}

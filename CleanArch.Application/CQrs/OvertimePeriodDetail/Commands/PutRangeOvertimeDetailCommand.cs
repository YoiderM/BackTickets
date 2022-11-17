using Application.Common.Response;
using Application.Interfaces.Overtimes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriodDetail.Commands
{
    public class PutRangeOvertimeDetailCommand : IRequest<ApiResponse<bool>>
    {
        public List<Guid> OvertimeDetailsId { get; set; }   
    }

	public class PutRangeOvertimeDetailCommandHandler : IRequestHandler<PutRangeOvertimeDetailCommand, ApiResponse<bool>>
	{

		private readonly IOvertimeService _overtimeService;

		public PutRangeOvertimeDetailCommandHandler(IOvertimeService overtimeService) => _overtimeService = overtimeService;
		public async Task<ApiResponse<bool>> Handle(PutRangeOvertimeDetailCommand request, CancellationToken cancellationToken)
		{

			return await _overtimeService.PutRangeOvertimeDetailCommand(request, cancellationToken);

		}


	}
}

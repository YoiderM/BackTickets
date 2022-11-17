using Application.Common.Response;
using Application.Interfaces.Overtimes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriods.Commands
{
    public class DeleteOvertimePeriodCommand :IRequest<ApiResponse<bool>>
    {

        public int Id { get; set; }
    }
    public class DeleteOvertimePeriodCommandHandler : IRequestHandler<DeleteOvertimePeriodCommand, ApiResponse<bool>>
    {

        private readonly IOvertimePeriodService _overtimePeriodservice;

        public DeleteOvertimePeriodCommandHandler(IOvertimePeriodService overtimePeriodservice) => _overtimePeriodservice = overtimePeriodservice;
       
        

        public async Task<ApiResponse<bool>> Handle(DeleteOvertimePeriodCommand request, CancellationToken cancellationToken)
        {
            return await _overtimePeriodservice.DeletePeriod(request.Id);
        }
    }
}

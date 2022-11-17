using Application.Common.Response;
using Application.Interfaces.Overtimes;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.OvertimePeriodDetail.Commands
{
    public class DeleteOvertimeDetailCommand : IRequest<ApiResponse<bool>>
    {
        public Guid Id { get; set; }
    }

    public class DeleteOvertimeDetailCommandHandler : IRequestHandler<DeleteOvertimeDetailCommand, ApiResponse<bool>>
    {
        private readonly IOvertimeService _overtimeService;

        public DeleteOvertimeDetailCommandHandler(IOvertimeService overtimeService) => _overtimeService = overtimeService;
        public async Task<ApiResponse<bool>> Handle(DeleteOvertimeDetailCommand request, CancellationToken cancellationToken)
        {           
            return await _overtimeService.DeleteDetail(request.Id);
        }   
    }
}

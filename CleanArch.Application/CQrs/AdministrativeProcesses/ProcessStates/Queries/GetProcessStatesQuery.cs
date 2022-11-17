using Application.Common.Response;
using Application.Interfaces.AdministrativeProcesses;
using Domain.Models.AdministrativeProcesses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.AdministrativeProcesses.ProcessStates.Queries
{
    public class GetProcessStatesQuery : IRequest<ApiResponse<List<ProcessStatus>>>
    {

    }

    public class GetProcessStatesQueryHandler : IRequestHandler<GetProcessStatesQuery, ApiResponse<List<ProcessStatus>>>
    {
        private readonly IProcessStatusService _processStatusService;

        public GetProcessStatesQueryHandler(IProcessStatusService processStatusService)
        {
            _processStatusService = processStatusService;

        }

        public async Task<ApiResponse<List<ProcessStatus>>> Handle(GetProcessStatesQuery request, CancellationToken cancellationToken)
        {
            return await _processStatusService.GetProcess(request, cancellationToken);
        }
    }
}

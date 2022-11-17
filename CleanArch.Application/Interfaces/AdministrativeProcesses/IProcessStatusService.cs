using Application.Common.Response;
using Application.Cqrs.AdministrativeProcesses.ProcessStates.Queries;
using Domain.Models.AdministrativeProcesses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.AdministrativeProcesses
{
    public interface IProcessStatusService
    {

        Task<ApiResponse<List<ProcessStatus>>> GetProcess(GetProcessStatesQuery request, CancellationToken cancellationToken);
    }
}

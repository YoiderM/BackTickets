using Application.Common.Response;
using Application.Cqrs.AdministrativeProcesses.HistoryChangeProcesses.Commands;
using Application.DTOs.Administrativeprocesses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.AdministrativeProcesses
{
    public interface IProcessHistoryChangeService
    {
        Task<ApiResponse<ProcessChangeHistoryDto>> PostChange(PostChangeProcessHistoryCommand request);

    }
}

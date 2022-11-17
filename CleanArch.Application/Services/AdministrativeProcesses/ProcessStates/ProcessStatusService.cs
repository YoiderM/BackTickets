using Application.Common.Response;
using Application.Cqrs.AdministrativeProcesses.ProcessStates.Queries;
using Application.Interfaces.AdministrativeProcesses;
using Domain.Interfaces;
using Domain.Models.AdministrativeProcesses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.AdministrativeProcesses.ProcessStates
{
    public class ProcessStatusService : IProcessStatusService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public ProcessStatusService(IUnitOfWork unitOfWork, ILogger<ProcessStatus> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        public async Task<ApiResponse<List<ProcessStatus>>> GetProcess(GetProcessStatesQuery request , CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<ProcessStatus>>();

            try
            {
                response.Data = await _unitOfWork.ProcessStatusRepository.Get()
                                                                         .OrderBy(x => x.Order)
                                                                         .ToListAsync();

                response.Result = true;
                response.Message = "OK";

            }
            catch (Exception ex)
            {

                _logger.LogError($"Error al consultar los registros, TypeOfFaultService en el método GetTypes, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar los registros, consulte con el administrador. { ex.Message } ";
            }

            return response;

        }
    }
}

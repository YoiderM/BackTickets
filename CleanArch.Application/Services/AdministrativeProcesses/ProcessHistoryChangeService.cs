using Application.Common.Response;
using Application.Cqrs.AdministrativeProcesses.HistoryChangeProcesses.Commands;
using Application.DTOs.Administrativeprocesses;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models.AdministrativeProcesses;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces.AdministrativeProcesses
{
    public class ProcessHistoryChangeService : IProcessHistoryChangeService
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IUnitOfWork _unitOfWork;

        public ProcessHistoryChangeService(IUnitOfWork unitOfWork, ILogger<ProcessHistoryChangeService> logger, IMapper mapper)
        {
            _unitOfWork=unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<ApiResponse<ProcessChangeHistoryDto>> PostChange(PostChangeProcessHistoryCommand request)
        {
            var response = new ApiResponse<ProcessChangeHistoryDto>();
            try
            {
                var source = _mapper.Map<ProcessChangeHistoryDto>(await _unitOfWork.ProcessChangeHistoryRepository.Add(_mapper.Map<ProcessChangeHistory>(request)));
                response.Data = source;
                response.Result = true;
                response.Message = "OK";

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el registro, Overtimeservice en el método PostOvertime, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al crear el registro, consulte con el administrador. { ex.InnerException } ";
            }
            return response;
        }
    }
}

using Application.Common.Response;
using Application.Cqrs.AdministrativeProcesses.TypeOfFaults.Queries;
using Application.Interfaces.AdministrativeProcesses;
using Domain.Interfaces;
using Domain.Models.AdministrativeProcesses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.AdministrativeProcesses.TypeOfFaults
{
    public class TypeOfFaultService : ITypeOfFaultService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public TypeOfFaultService(IUnitOfWork unitOfWork, ILogger<TypeOfFault> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;

        }

        public async Task<ApiResponse<List<TypeOfFault>>> GetTypes(GetTypeOfFaultQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<TypeOfFault>>();

            try
            {
                response.Data = await _unitOfWork.TypeOfFaultRepository.Get().ToListAsync();
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

        public async Task<TypeOfFault> GetTypesById(int type)
        {           
            var source = await _unitOfWork.TypeOfFaultRepository.GetById(type);
              
            return source;
        }
    } 
}

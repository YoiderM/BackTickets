using Application.Common.Response;
using Application.Cqrs.AdministrativeProcesses.TypeOfFaults.Queries;
using Domain.Models.AdministrativeProcesses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.AdministrativeProcesses
{
    public interface ITypeOfFaultService
    {
        Task<ApiResponse<List<TypeOfFault>>> GetTypes(GetTypeOfFaultQuery request, CancellationToken cancellationToken);
        Task<TypeOfFault> GetTypesById(int type);
    }
}

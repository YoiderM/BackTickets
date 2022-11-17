using Application.Common.Response;
using Application.Interfaces.AdministrativeProcesses;
using Domain.Models.AdministrativeProcesses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.AdministrativeProcesses.TypeOfFaults.Queries
{
    public class GetTypeOfFaultQuery : IRequest<ApiResponse<List<TypeOfFault>>>
    {
    }

    public class GetTypeOfFaultQueryHandler : IRequestHandler<GetTypeOfFaultQuery, ApiResponse<List<TypeOfFault>>>
    {
        private readonly ITypeOfFaultService _typeOfFaultService;

        public GetTypeOfFaultQueryHandler(ITypeOfFaultService typeOfFaultService)
        {
            _typeOfFaultService = typeOfFaultService;

        }
        public async Task<ApiResponse<List<TypeOfFault>>> Handle(GetTypeOfFaultQuery request, CancellationToken cancellationToken)
        {
            return await _typeOfFaultService.GetTypes(request, cancellationToken);
        }
    }
}

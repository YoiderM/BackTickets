using Application.Common.Response;
using Application.DTOs.Administrativeprocesses;
using Domain.Models.AdministrativeProcesses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Queries
{
    public class GetDisciplinaryProcessQuery :IRequest<ApiResponse<List<DisciplinaryProcessDto>>>
    {

    }

    public class GetDisciplinaryProcessQueryHandler : IRequestHandler<GetDisciplinaryProcessQuery, ApiResponse<List<DisciplinaryProcessDto>>>
    {
        public Task<ApiResponse<List<DisciplinaryProcessDto>>> Handle(GetDisciplinaryProcessQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

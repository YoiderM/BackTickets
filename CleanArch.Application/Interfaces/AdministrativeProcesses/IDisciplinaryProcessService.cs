using Application.Common.Response;
using Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Commands;
using Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Queries;
using Application.DTOs.Administrativeprocesses;
using Domain.Models.AdministrativeProcesses;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Interfaces.AdministrativeProcesses
{
    public interface IDisciplinaryProcessService
    {
        Task<ApiResponse<DisciplinaryProcessDto>> PostDisciplinary(PostDisciplinaryProcessCommand request, CancellationToken cancellationToken);
        Task<ApiResponse<List<DisciplinaryProcessDto>>> GetByStatus(GetByStatusDisciplinaryProcessQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<DisciplinaryProcessDto>>> GetByStatusAndCampaign(GetByStatusAndCampaignDisciplinaryProcessQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<DisciplinaryProcessDto>>> GetByStatusAndApplicant(GetByStatusAndCurrentUserIdDisciplinaryProcessQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<DisciplinaryProcessDto>>> GetByStatusAndApproving(GetByStatusAndApprovingDisciplinaryProcessQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<DisciplinaryProcessDto>>> GetByStatusAndAuthorizing(GetByStatusAndAuthorizingDisciplinaryProcessQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<DisciplinaryProcessDto>> PutProcess(PutDisciplinaryProcessCommand request, CancellationToken cancellationToken);
        Task<ApiResponse<DisciplinaryProcessDto>> PutProcessResponse(PutResponseDisciplinaryProcessCommand request, CancellationToken cancellationToken);

        public Task<ApiResponse<string>> SavePdf(IFormFile file);

        Task<bool> SendEmail(GetSendEmailDisciplinaryProcessQuery request, CancellationToken cancellationToken);
        Task<ApiResponse<List<DisciplinaryProcessDto>>> GetDisciplinaryProcessByDate(GetDisciplinaryProcessByDateQuery request, CancellationToken cancellationToken);
    }
}

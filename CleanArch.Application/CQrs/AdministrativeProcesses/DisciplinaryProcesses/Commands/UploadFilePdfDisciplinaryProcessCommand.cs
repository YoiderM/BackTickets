using Application.Common.Response;
using Application.DTOs.Administrativeprocesses;
using Application.Interfaces.AdministrativeProcesses;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Commands
{
    public class UploadFilePdfDisciplinaryProcessCommand :IRequest<ApiResponse<string>>
    {

        public IFormFile filePdf { get; set; }
    }

    public class UploadFilePdfDisciplinaryProcessCommandhandler : IRequestHandler<UploadFilePdfDisciplinaryProcessCommand, ApiResponse<string>>
    {

        private readonly IDisciplinaryProcessService _disciplinaryProcessService;
        private readonly IMapper _mapper;

        public UploadFilePdfDisciplinaryProcessCommandhandler(IDisciplinaryProcessService disciplinaryProcessService,IMapper mapper)
        {
            _disciplinaryProcessService = disciplinaryProcessService;
            _mapper=mapper;

    }
        public Task<ApiResponse<string>> Handle(UploadFilePdfDisciplinaryProcessCommand request, CancellationToken cancellationToken)
        {
      
            return  _disciplinaryProcessService.SavePdf(request.filePdf);
        }
    }


}

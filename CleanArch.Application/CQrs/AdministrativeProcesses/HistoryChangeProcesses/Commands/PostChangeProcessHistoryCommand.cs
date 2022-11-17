using Application.Common.Response;
using Application.DTOs.Administrativeprocesses;
using Application.Interfaces.AdministrativeProcesses;
using AutoMapper;
using Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.AdministrativeProcesses.HistoryChangeProcesses.Commands
{
    public class PostChangeProcessHistoryCommand : IRequest<ApiResponse<ProcessChangeHistoryDto>>
    {
        public DateTime StatusDate { get; set; }
        public bool Status { get; set; }
        public Guid StatusStart { get; set; }
        public Guid StatusNext { get; set; }
        public Guid ProcessPerformedById { get; set; }
        public int DisciplinaryProcessId { get; set; }

    }

    public class PostChangeProcessHistoryCommandHandler : IRequestHandler<PostChangeProcessHistoryCommand, ApiResponse<ProcessChangeHistoryDto>>
    {

        private readonly IProcessHistoryChangeService _processHistoryChangeService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public PostChangeProcessHistoryCommandHandler(IProcessHistoryChangeService processHistoryChangeService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _processHistoryChangeService = processHistoryChangeService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;

        }
        public async Task<ApiResponse<ProcessChangeHistoryDto>> Handle(PostChangeProcessHistoryCommand request, CancellationToken cancellationToken)
        {         
            return await _processHistoryChangeService.PostChange(request);
        }
    }

}

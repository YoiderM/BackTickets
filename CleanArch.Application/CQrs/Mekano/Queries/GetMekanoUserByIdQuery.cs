using Application.Common.Response;
using Application.Interfaces.Mekano;
using Domain.Models.Mekano;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Mekano.Queries
{
    public class GetMekanoUserByIdQuery :IRequest<ApiResponse<MekanoUser>>
    {
        public string Document { get; set; }
    }

    public class GetMekanoUserByIdHandler : IRequestHandler<GetMekanoUserByIdQuery, ApiResponse<MekanoUser>>
    {
        private readonly IMekanoUserService _mekanoUserService;
        public GetMekanoUserByIdHandler(IMekanoUserService mekanoUserService)
        {
            _mekanoUserService = mekanoUserService;

        }
        public async Task<ApiResponse<MekanoUser>> Handle(GetMekanoUserByIdQuery request, CancellationToken cancellationToken)
        {
            return  await _mekanoUserService.GetByIdMekanoUser(request.Document);
        }
    }
}

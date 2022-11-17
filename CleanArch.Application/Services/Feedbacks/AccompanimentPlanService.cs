using Application.Common.Mappings;
using Application.Common.Response;
using Application.Cqrs.Feedbacks.AccompanimentPlan.Queries;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using Application.Interfaces.Rol;
using Application.Interfaces.User;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.CustomEntities;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Feedbacks
{
    public class AccompanimentPlanService : IAccompanimentPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private ICurrentUserService _currentUserService;
        private Guid _userId;
        private string _createdByName;
        private IRolService _rolService;
        private readonly IUserRolService _userRolService;
        private readonly IUserService _userService;
        public AccompanimentPlanService(
            IUnitOfWork unitOfWork, 
            IMapper mapper, 
            ILogger<AccompanimentPlanService> logger,
            ICurrentUserService currentUserService,
            IRolService rolService,
            IUserRolService userRolService,
            IUserService userService
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
            _currentUserService = currentUserService;
            _rolService = rolService;
            _userRolService = userRolService;
            _userService = userService;
        }
        public async Task<PaginatedList<AccompanimentPlanDto>> GetAccompanimentPlans(GetResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            return await _unitOfWork.AccompanimentPlanRepository.Get()
                                                            .Include(x => x.TypeAccompanimentPlan)
                                                            .Include(x => x.Status)
                                                            .ProjectTo<AccompanimentPlanDto>(_mapper.ConfigurationProvider)
                                                            .OrderByDescending(x => x.Id)
                                                            .PaginatedListAsync(request.PageNumber, request.PageSize);

        }
        public async Task<ApiResponse<List<AccompanimentPlanDto>>> GetByTypeAccompanimentPlan(GetByTypeAccompanimentPlanResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<AccompanimentPlanDto>>();
            try
            {
                response.Data = _mapper.Map<List<AccompanimentPlanDto>>(await _unitOfWork.AccompanimentPlanRepository.Get()
                                                                    .Where(x => x.TypeAccompanimentPlanId == request.TypeAccompanimentPlanId)
                                                                    .Include(x => x.TypeAccompanimentPlan)
                                                                    .Include(x => x.Status)
                                                                    .OrderBy(x => x.CreatedAt)
                                                                    .ToListAsync());
                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, AccompanimentPlanService en el método GetByAccompanimentPlan, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
        public async Task<ApiResponse<List<AccompanimentPlanDto>>> GetByDocumentAccompanimentPlan(GetByDocumentResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<AccompanimentPlanDto>>();
            try
            {
                response.Data = _mapper.Map<List<AccompanimentPlanDto>>(await _unitOfWork.AccompanimentPlanRepository.Get()
                                                                    .Where(x => x.Document == request.Document)
                                                                    .Include(x => x.TypeAccompanimentPlan)
                                                                    .Include(x => x.Status)
                                                                    .OrderBy(x => x.CreatedAt)
                                                                    .ToListAsync());
                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, AccompanimentPlanService en el método GetByDocumentAccompanimentPlan, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
        public async Task<ApiResponse<List<AccompanimentPlanDto>>> GetByStatusIdAccompanimentPlan(GetByStatusIdResponseAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<AccompanimentPlanDto>>();
            try
            {
                response.Data = _mapper.Map<List<AccompanimentPlanDto>>(await _unitOfWork.AccompanimentPlanRepository.Get()
                                                                    .Where(x => x.StatusId == request.StatusId)
                                                                    .Include(x => x.TypeAccompanimentPlan)
                                                                    .Include(x => x.Status)
                                                                    .OrderBy(x => x.CreatedAt)
                                                                    .ToListAsync());
                response.Result = true;
                response.Message = "Ok";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, AccompanimentPlanService en el método GetByStatusIdAccompanimentPlan, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
    }
}

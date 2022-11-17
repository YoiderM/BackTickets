using Application.Common.Response;
using Application.Core.Exceptions;
using Application.Cqrs.Feedbacks.TypeAccompanimentPlan.Queries;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using Domain.Interfaces;
using Domain.Models.Feedbacks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Feedbacks
{
    public class TypeAccompanimentPlanService : ITypeAccompanimentPlanService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        public TypeAccompanimentPlanService(IUnitOfWork unitOfWork, ILogger<TypeAccompanimentPlan> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
        }
        public async Task<ApiResponse<List<TypeAccompanimentPlanDto>>> GetTypes(GetTypeAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<List<TypeAccompanimentPlanDto>>();
            try
            {
                response.Data = _mapper.Map<List<TypeAccompanimentPlanDto>>(await _unitOfWork.TypeAccompanimentPlanRepository.Get().ToListAsync());
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar los registros, TypeAccompanimentPlanService en el método GetTypes, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar los registros, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
        public async Task<ApiResponse<TypeAccompanimentPlanDto>> GetTypesById(int type)
        {
            var response = new ApiResponse<TypeAccompanimentPlanDto>();
            try
            {
                response.Data = _mapper.Map<TypeAccompanimentPlanDto>(await _unitOfWork.TypeAccompanimentPlanRepository.GetById(type));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar los registros, TypeAccompanimentPlanService en el método GetTypesById, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar los registros, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
        public async Task<ApiResponse<ReturnStartDateAndEndDateNextAccompanimentPlan>> GetNextDateAccompanimentPlan(GetNextDateByTypeAccompanimentPlanQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<ReturnStartDateAndEndDateNextAccompanimentPlan>();
            try
            {
                var getTypeAccompanimentPlan = await _unitOfWork.TypeAccompanimentPlanRepository.Get()
                                                                    .Where(x => x.Id == request.TypeAccompanimentPlanId)
                                                                    .FirstOrDefaultAsync();
                var nextTypeAccompanimentPlan = await _unitOfWork.TypeAccompanimentPlanRepository.Get()
                                                                    .Where(x => x.Order == (getTypeAccompanimentPlan.Order + 1))
                                                                    .FirstOrDefaultAsync();
                if (nextTypeAccompanimentPlan == null)
                {
                    throw new NotFoundException("Hemos finalizado nuestro Programa del Plan de Acompañamiento");
                }
                else
                {
                    var startDate = DateTime.Now.AddDays(nextTypeAccompanimentPlan.NextMeetingDays);
                    ReturnStartDateAndEndDateNextAccompanimentPlan returnStartDateAndEndDateNextAccompanimentPlan = new ReturnStartDateAndEndDateNextAccompanimentPlan
                    {
                        StartDate = startDate.ToString("yyyy-MM-dd"),
                        EndDate = startDate.AddDays(3).ToString("yyyy-MM-dd")
                    };
                    response.Data = returnStartDateAndEndDateNextAccompanimentPlan;
                }
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar los registros, TypeAccompanimentPlanService en el método GetNextDateAccompanimentPlan, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar los registros, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
    }
}

using Application.DTOs.Mekano;
using Application.Interfaces.Mekano;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Domain.Models.Mekano;
using Application.Common.Response;
using System;
using Microsoft.Extensions.Logging;
using Application.Core.Exceptions;

namespace Application.Services.Mekano
{
    public class CostCenterService : ICostCenterService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public CostCenterService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CostCenter> logger) => (_unitOfWork ,_mapper, _logger) = (unitOfWork, mapper, logger);


        public async Task<ApiResponse<List<CostCenterDto>>> GetCostCenter()
        {
            var response = new ApiResponse<List<CostCenterDto>>();

            try
            {
                response.Data = _mapper.Map<List<CostCenterDto>>(await _unitOfWork.CostCenterRepository.Get()
                    .OrderBy(x => x.Name)
                    .ProjectTo<CostCenterDto>(_mapper.ConfigurationProvider)
                    .ToListAsync());
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los Registros, CostCenterService en el método GetCostcenter, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al Obtener los Registros, consulte con el administrador  { ex.Message } ";
            }
            return response;            
        }

        public async Task<ApiResponse<CostCenterDto>> GetById(int Id)
        {
            var response = new ApiResponse<CostCenterDto>();
            try
            {
                bool existe = await checkById(Id);

                if (existe==false) 
                {                
                     throw new NotFoundException("El Centro de Costos ingresado no existe");
                }
                else { 
                    response.Data = _mapper.Map<CostCenterDto>(await _unitOfWork.CostCenterRepository.Get()
                                                                 .Where(x => x.Status == true)
                                                                 .OrderBy(x => x.Name)
                                                                 .FirstOrDefaultAsync(x => x.Id == Id));
                    response.Result = true;
                    response.Message = "OK";
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener el registro, CostCenterService en el método GetById, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al Obtener el Registro, consulte con el administrador  { ex.Message } ";
            }

            return response;
        }

        public async Task<bool> checkById(int Id)
        {
            return await _unitOfWork.CostCenterRepository
                .Get()
                .CountAsync(x => x.Id == Id) > 0 ?
                true : false;
        }
    }
}

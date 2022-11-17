using Application.Common.Response;
using Application.DTOs.Feedbacks;
using Application.Interfaces.Feedbacks;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Feedbacks
{
    public class AdditionalQuestionService : IAdditionalQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private ICurrentUserService _currentUserService;
        //private string _createdUpdateByName;
        //private Guid _userId;
        public AdditionalQuestionService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<AdditionalQuestionService> logger, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _currentUserService = currentUserService;
            //_userId = (Guid)_currentUserService.GetUserInfo().Id;
            //_createdUpdateByName = _currentUserService.GetUserInfo().Name;
        }
        public async Task<ApiResponse<List<AdditionalQuestionDto>>> GetAllAdditionalQuestion()
        {
            var response = new ApiResponse<List<AdditionalQuestionDto>>();
            try
            {
                response.Data = _mapper.Map<List<AdditionalQuestionDto>>(await _unitOfWork.AdditionalQuestionRepository
                                                                                            .Get()
                                                                                            .Include(x => x.QuestionType)
                                                                                            .Include(x => x.OriginQuestion)
                                                                                            .Where(x => x.Active == true)
                                                                                            .ToListAsync());
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar los registros, AdditionalQuestionService en el método GetAllAdditionalQuestion, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar los registros, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
    }
}

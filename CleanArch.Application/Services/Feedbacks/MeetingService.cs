using Application.Common.Response;
using Application.Core.Exceptions;
using Application.Cqrs.Meetings.Meeting.Commands;
using Application.Cqrs.Meetings.Meeting.Queries;
using Application.DTOs.Meetings;
using Application.Interfaces.Meetings;
using AutoMapper;
using CleanArchitecture.Application.Common.Interfaces;
using Domain.Interfaces;
using Domain.Models.Meetings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Services.Feedbacks
{
    public class MeetingService : IMeetingService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private ICurrentUserService _currentUserService;
        //private string _createdUpdateByName;
        //private Guid _userId;
        public MeetingService(IUnitOfWork unitOfWork, IMapper mapper, ILogger<MeetingService> logger, ICurrentUserService currentUserService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _currentUserService = currentUserService;
            //_userId = (Guid)_currentUserService.GetUserInfo().Id;
            //_createdUpdateByName = _currentUserService.GetUserInfo().Name;
        }
        public async Task<ApiResponse<MeetingDto>> GetByIdMeeting(GetByIdMeetingQuery request, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<MeetingDto>();
            try
            {
                response.Data = _mapper.Map<MeetingDto>(await _unitOfWork.MeetingRepository
                                                .Get()
                                                .Where(x => x.Id == request.Id)
                                                .Include(x => x.Status)
                                                .Include(x => x.TypeMeeting)
                                                .FirstOrDefaultAsync());
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al consultar el registro, MeetingService en el método GetByIdMeeting, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al consultar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }

        public async Task<ApiResponse<MeetingDto>> PutStartMeeting(PutStartMeetingCommand putStatusCommand, CancellationToken cancellationToken)
        {
            var response = new ApiResponse<MeetingDto>();
            try
            {
                Meeting meeting = await _unitOfWork.MeetingRepository.GetById(putStatusCommand.id) ?? throw new NotFoundException("The meeting is not found");
                meeting.StartDate = DateTime.Now;
                meeting.StatusId = new Guid("F0B0FE0A-046D-4637-91B8-2DEB52E48816");
                //meeting.UpdatedBy = (Guid)_currentUserService.GetUserInfo().Id;
                meeting.UpdatedAt = DateTime.Now;
                response.Data = _mapper.Map<MeetingDto>(await _unitOfWork.MeetingRepository.Put(meeting));
                response.Result = true;
                response.Message = "OK";
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el registro, MeetingService en el método PutStartMeeting, { ex.Message } ");
                response.Result = false;
                response.Message = $"Error al actualizar el registro, consulte con el administrador. { ex.Message } ";
            }
            return response;
        }
    }
}

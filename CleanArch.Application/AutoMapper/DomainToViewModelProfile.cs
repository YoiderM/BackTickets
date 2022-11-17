using Application.AutoMapper.Resolver;
using Application.Cqrs.Novelties.Commands;
using Application.DTOs.Administrativeprocesses;
using Application.DTOs.Configurations;
using Application.DTOs.Feedbacks;
using Application.DTOs.Mekano;
using Application.DTOs.Novelties;
using Application.DTOs.OvertimePeriods;
using Application.DTOs.User;
using AutoMapper;
using Core.Models.configuration;
using Domain.Models.AdministrativeProcesses;
using Domain.Models.Feedbacks;
using Domain.Models.Mekano;
using Domain.Models.Novelties;
using Domain.Models.Overtimes;
using Domain.Models.Rol;
using Domain.Models.User;
using Domain.Models.Resources;
using Application.DTOs.Resources;
using Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Commands;

namespace CleanArch.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            #region administrativeProcess
            CreateMap<DisciplinaryProcess, PostDisciplinaryProcessCommand>();
            #endregion

            #region Users-Rols-UserRols  

            CreateMap<User, UserDto>();           
            CreateMap<User, UserResponsabilityCostCenterDto>();           

            CreateMap<UserRol, UserRolDto>();
            CreateMap<Rol, RolDto>();
            CreateMap<MekanoUser, MekanoUserDto>();

            #endregion

            #region Configuration
            CreateMap<Configuration, ConfigurationDto>();
            CreateMap<Category, CategoryDto>();
            #endregion

            #region Overtimes
            
            CreateMap<OvertimePeriod, OvertimePeriodDto>()
                 .ForMember(x => x.StartAllowedDate, opt => opt.MapFrom(x => DatetimeFormatResolver.YearMonthDay(x.StartAllowedDate)))
                 .ForMember(x => x.EndAllowedDate, opt => opt.MapFrom(x => DatetimeFormatResolver.YearMonthDay(x.EndAllowedDate)))
                 .ForMember(x => x.EndPeriodDate, opt => opt.MapFrom(x => DatetimeFormatResolver.YearMonthDay(x.EndPeriodDate)))
                 .ForMember(x => x.StartPeriodDate, opt => opt.MapFrom(x => DatetimeFormatResolver.YearMonthDay(x.StartPeriodDate)));
            CreateMap<OvertimeDetail, OvertimeDetailDto>()
                .ForMember(x => x.OvertimeDay, opt => opt.MapFrom(x => DatetimeFormatResolver.YearMonthDay(x.OvertimeDay)));
            CreateMap<OvertimeType, OvertimeTypeDto>();

            #endregion

            #region CostCenter          
            CreateMap<CostCenter, CostCenterDto>();
            CreateMap<TypeOfFault, TypeOfFaultDto>();
            CreateMap<ProcessStatus, ProcessStatus>();
            CreateMap<ResponsabilityCostCenter, ResponsabilityCostCenterDto>();
            CreateMap<DisciplinaryProcess, DisciplinaryProcessDto>()
                .ForMember(x => x.StatusDateFormat, opt => opt.MapFrom(x => DatetimeFormatResolver.YearMonthDay(x.StatusDate)));
            CreateMap<ProcessChangeHistory, ProcessChangeHistoryDto>();
            #endregion

            #region Feedback
            CreateMap<ResponseAccompanimentPlan, ResponseAccompanimentPlanDto>()
                .ForMember(x => x.StartDate, opt => opt.MapFrom(x => DatetimeFormatResolver.YearMonthDayHoursMinutes(x.StartDate)))
                .ForMember(x => x.FinalDate, opt => opt.MapFrom(x => DatetimeFormatResolver.YearMonthDayHoursMinutes(x.FinalDate)))
                .ForMember(x => x.ScheduledDate, opt => opt.MapFrom(x => DatetimeFormatResolver.YearMonthDay(x.ScheduledDate)));
            #endregion

            #region Novelties
            CreateMap<TB_ASISTENCIA_MARCADORES, TB_ASISTENCIA_MARCADORESDto>();
            CreateMap<ConfigurationNovelties, ConfigurationNoveltiesDto>();
            CreateMap<NoveltyEntry, NoveltyEntryCommandDto>();
            CreateMap<NoveltyEntry, NoveltyEntryQueryDto>();
            CreateMap<NoveltyEntry, PutStatusNoveltyPersonCommand>();
            CreateMap<NoveltyEntry, NoveltyEntryDto>();
            CreateMap<ConfigurationNovelties, ConfigurationNoveltiesDto>();
            CreateMap<ProcessStatus, ProcessStatusDto>();
            CreateMap<ConfigurationNoveltiesDto, NoveltyEntryDto>();
            CreateMap<NoveltyHistory, NoveltyHistoryDto>();
            CreateMap<NoveltyHistory, NoveltyHistoryQueryDto>();
            CreateMap<MekanoUser, UserMekanoByCostCenterDto>();
            CreateMap<ProcessStatus, ProcessStatusDto>();
            CreateMap<ProcessStatus, ProcessStatus>();
            #endregion

            #region Resources
            CreateMap<Resources, ResourcesDto>();
            #endregion
        }
    }
}
using Application.Cqrs.AdministrativeProcesses.DisciplinaryProcesses.Commands;
using Application.Cqrs.AdministrativeProcesses.HistoryChangeProcesses.Commands;
using Application.Cqrs.Novelties.Commands;
//using Application.Cqrs.Novelties.Queries;
using Application.Cqrs.OvertimePeriodDetail.Commands;
using Application.Cqrs.OvertimePeriods.Commands;
using Application.Cqrs.ResponsabilitiesCostCenter.Commands;
using Application.Cqrs.Rol.Commands;
using Application.Cqrs.User.Commands;
using Application.Cqrs.UserRol.Commands;
using Application.DTOs.Administrativeprocesses;
using Application.DTOs.Configurations;
using Application.DTOs.Feedbacks;
using Application.DTOs.Mekano;
using Application.DTOs.Novelties;
using Application.DTOs.OvertimePeriods;
using Application.DTOs.Resources;
using Application.DTOs.User;
using AutoMapper;
using Core.Models.configuration;
using Domain.Models.AdministrativeProcesses;
using Domain.Models.Feedbacks;
using Domain.Models.Mekano;
using Domain.Models.Novelties;
using Domain.Models.Overtimes;
using Domain.Models.Resources;
using Domain.Models.Rol;
using Domain.Models.User;

namespace CleanArch.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<UploadOvertimesPeriodCommand, OvertimePeriod>();
            CreateMap<CreateOvertimePeriodcommand, OvertimePeriod>();
            CreateMap<UpdateOvertimePeriodCommand, OvertimePeriod>();
            CreateMap<DeleteOvertimePeriodCommand, OvertimePeriod>();

            CreateMap<DeleteOvertimeDetailCommand, OvertimeDetail>();
            CreateMap<PostOvertimeCommand, OvertimeDetail>();
            CreateMap<PutOvertimeCommand, OvertimeDetail>();

            CreateMap<OvertimeDetailDto, OvertimeDetail>();
            CreateMap<OvertimeTypeDto, OvertimeType>();

            #region Administrative process
            CreateMap<DisciplinaryProcessDto, DisciplinaryProcess>();          
            CreateMap<ProcessChangeHistoryDto, ProcessChangeHistory>();
            CreateMap<ProcessStatusDto, ProcessStatus>();
            CreateMap<TypeOfFaultDto, TypeOfFault>();



            CreateMap<PostDisciplinaryProcessCommand, DisciplinaryProcess>();       
            CreateMap<PostChangeProcessHistoryCommand, ProcessChangeHistory>();
            CreateMap<PutDisciplinaryProcessCommand, DisciplinaryProcess>();
            CreateMap<PutResponseDisciplinaryProcessCommand, DisciplinaryProcess>();


            #endregion

            #region Users-Rols-UserRols

            // Users
            CreateMap<UserDto, User>();
            CreateMap<UserResponsabilityCostCenterDto, User>();
            CreateMap<PostUserCommand, User>();
            CreateMap<PutUserCommand, User>();
            CreateMap<DeleteUserCommand, User>();
            CreateMap<PutStatusActivateUserById, User>();
            CreateMap<PutStatusDeactivateUserById, User>();
            CreateMap<MekanoUserDto, MekanoUser>();

            // Rols
            CreateMap<RolDto, Rol>();
            CreateMap<PostRolCommand, Rol>();
            CreateMap<PutRolCommand, Rol>();
            CreateMap<DeleteRolCommand, Rol>();
            CreateMap<PutStatusActivateRolById, Rol>();
            CreateMap<PutStatusDeactivateRolById, Rol>();

            // UserRol
            CreateMap<UserRolDto, UserRol>();
            CreateMap<AddUserRolCommand, UserRol>();
            CreateMap<PutUserCommand, UserRol>();
            CreateMap<DeleteUserRolCommand, UserRol>();
            CreateMap<PutUserCommand, UserRol>();

            #endregion

            #region Configurations          
            CreateMap<CategoryDto, Category>();
            CreateMap<ConfigurationDto, Configuration>();
            #endregion

            #region ResponsabilityCostCenter
            CreateMap<PostResponsabilityCostCenterCommand, ResponsabilityCostCenter>();
            CreateMap<ResponsabilityCostCenterDto, ResponsabilityCostCenter>();
            #endregion

            #region Feedbacks
            CreateMap<AccompanimentPlanDto, AccompanimentPlan>().ReverseMap();
            CreateMap<ResponseAccompanimentPlanDto, ResponseAccompanimentPlan>().ReverseMap();
            CreateMap<TypeAccompanimentPlanDto, TypeAccompanimentPlan>().ReverseMap();
            CreateMap<AdditionalQuestionDto, AdditionalQuestion>().ReverseMap();
            CreateMap<QuestionnaireTemplateDto, QuestionnaireTemplate>().ReverseMap();
            CreateMap<QuestionnaireQuestionTemplateDto, QuestionnaireQuestionTemplate>().ReverseMap();
            CreateMap<ResponseQuestionDto, ResponseQuestion>().ReverseMap();
            CreateMap<ResponseAdditionalQuestionDto, ResponseAdditionalQuestion>().ReverseMap();
            CreateMap<ResponseQuestionAndQuestionnaireDto, ResponseQuestion>().ReverseMap();
            #endregion

            #region Novelties
            CreateMap<TB_ASISTENCIA_MARCADORESDto, TB_ASISTENCIA_MARCADORES>();
            CreateMap<TB_ASISTENCIA_MARCADORESDto, TB_ASISTENCIA_MARCADORESDto>();
            CreateMap<ConfigurationNoveltiesDto, ConfigurationNovelties>();
            CreateMap<NoveltyEntryCommandDto, NoveltyEntry>();
            CreateMap<PutStatusNoveltyPersonCommand, NoveltyEntry>();
            CreateMap<NoveltyEntryQueryDto, NoveltyEntry>();
            CreateMap<ConfigurationNoveltiesDto, ConfigurationNovelties>();
            CreateMap<ProcessStatusDto, ProcessStatus>();
            CreateMap<NoveltyEntryDto, NoveltyEntry>();
            CreateMap<NoveltyHistoryDto, NoveltyHistory>();
            CreateMap<UserMekanoByCostCenterDto, MekanoUser>();
            CreateMap<ProcessStatusDto, ProcessStatus>();
            CreateMap<NoveltyHistoryCommandDto, NoveltyHistoryDto>();
            CreateMap<NoveltyHistoryQueryDto, NoveltyHistory>();

            CreateMap<NoveltyEntryDto, ConfigurationNoveltiesDto>();
            CreateMap<NoveltyEntryDto, NoveltyEntryQueryDto>();
            CreateMap<AnticipatedNoveltyEntryCommandDto, NoveltyEntryDto>();
            CreateMap<NoveltyEntryDto, AnticipatedNoveltyEntryCommandDto>();
            CreateMap<NoveltyEntryCommandDto, NoveltyEntryDto>();
            
            #endregion

            #region Resources
            CreateMap<ResourcesDto, Resources>();
            #endregion
        }
    }
}


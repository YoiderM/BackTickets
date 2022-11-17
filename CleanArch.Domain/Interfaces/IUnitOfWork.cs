using Core.Models.configuration;
using Domain.Models.AdministrativeProcesses;
using Domain.Models.Feedbacks;
using Domain.Models.Mekano;
using Domain.Models.Novelties;
using Domain.Models.Overtimes;
using Domain.Models.Resources;
using Domain.Models.Rol;
using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IIntRepository<OvertimePeriod> overtimePeriod { get; }
        IIntRepository<CostCenter> CostCenterRepository { get; }
        IIntRepository<MekanoUser> MekanoUserRepository { get; }
        IIntRepository<ResponsabilityCostCenter> responsabilityCostCenter { get; }
        IRepository<OvertimeDetail> overtimeDetail { get; }
        IRepository<OvertimeType> overtimeType { get; }
        IRepository<Configuration> ConfigurationRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<Models.User.User> UserRepository { get; }
        IRepository<Models.User.UserRol> UserRolRepository { get; }
        IRepository<Rol> RolRepository { get; }
        IRepository<OvertimeTemp> OvertimeTempRepository { get; }
        IRepository<ProcessChangeHistory> ProcessChangeHistoryRepository { get; }
        IRepository<ProcessSupport> ProcessSupportRepository { get; }     
        IIntRepository<ProcessStatus> ProcessStatusRepository { get; }
        IIntRepository<TypeOfFault> TypeOfFaultRepository { get; }
        IIntRepository<DisciplinaryProcess> DisciplinaryProcessRepository { get; }
        IIntRepository<AccompanimentPlan> AccompanimentPlanRepository { get; }
        IIntRepository<TypeAccompanimentPlan> TypeAccompanimentPlanRepository { get; }
        IIntRepository<ResponseQuestion> ResponseQuestionRepository { get; }
        IIntRepository<AdditionalQuestion> AdditionalQuestionRepository { get; }
        IIntRepository<QuestionnaireTemplate> QuestionnaireTemplateRepository { get; }
        IIntRepository<QuestionnaireQuestionTemplate> QuestionnaireQuestionTemplateRepository { get; }
        IIntRepository<ResponseAccompanimentPlan> ResponseAccompanimentPlanRepository { get; }
        IIntRepository<ResponseAdditionalQuestion> ResponseAdditionalQuestionRepository { get; }
        IIntRepository<ConfigurationNovelties> ConfigurationNoveltiesRepository { get; }
        IIntRepository<TB_ASISTENCIA_MARCADORES> TB_ASISTENCIA_MARCADORESRepository { get; }
        IRepository<NoveltyEntry> NoveltyEntryRepository { get; }
        IRepository<NoveltyHistory> NoveltyHistoryRepository { get; }
        IRepository<Resources> ResourcesRepository { get; }


        void SaveChanges();
        Task SaveChangesAsync();

        string GetDbConnection();
    }
}

using CleanArch.Infra.Data.Context;
using Core.Models.configuration;
using Domain.Interfaces;
using Domain.Models.AdministrativeProcesses;
using Domain.Models.Feedbacks;
using Domain.Models.Mekano;
using Domain.Models.Novelties;
using Domain.Models.Overtimes;
using Domain.Models.Resources;
using Domain.Models.Rol;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infra.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly U27ApplicationDBContext _ctx;
        public IIntRepository<OvertimePeriod> overtimePeriod => new BaseIntRepository<OvertimePeriod>(_ctx);
        public IRepository<OvertimeDetail> overtimeDetail => new BaseRepository<OvertimeDetail>(_ctx);
        public IIntRepository<CostCenter> CostCenterRepository => new BaseIntRepository<CostCenter>(_ctx);
        public IIntRepository<MekanoUser> MekanoUserRepository => new BaseIntRepository<MekanoUser>(_ctx);
        public IIntRepository<ResponsabilityCostCenter> responsabilityCostCenter => new BaseIntRepository<ResponsabilityCostCenter>(_ctx);
        public IRepository<OvertimeType> overtimeType => new BaseRepository<OvertimeType>(_ctx);
        public IRepository<Category> CategoryRepository => new BaseRepository<Category>(_ctx);
        public IRepository<Configuration> ConfigurationRepository => new BaseRepository<Configuration>(_ctx);
        public IRepository<UserRol> UserRolRepository => new BaseRepository<UserRol>(_ctx);
        public IRepository<User> UserRepository =>  new BaseRepository<User>(_ctx);
        public IRepository<Rol> RolRepository =>  new BaseRepository<Rol>(_ctx);
        public IRepository<OvertimeTemp> OvertimeTempRepository =>  new BaseRepository<OvertimeTemp>(_ctx);
        public IRepository<ProcessChangeHistory> ProcessChangeHistoryRepository => new BaseRepository<ProcessChangeHistory>(_ctx);
        public IIntRepository<ProcessStatus> ProcessStatusRepository => new BaseIntRepository<ProcessStatus>(_ctx);
        public IIntRepository<TypeOfFault> TypeOfFaultRepository => new BaseIntRepository<TypeOfFault>(_ctx);
        public IIntRepository<DisciplinaryProcess> DisciplinaryProcessRepository => new BaseIntRepository<DisciplinaryProcess>(_ctx);
        public IRepository<ProcessSupport> ProcessSupportRepository => new BaseRepository<ProcessSupport>(_ctx);
        public IIntRepository<AccompanimentPlan> AccompanimentPlanRepository => new BaseIntRepository<AccompanimentPlan>(_ctx);
        public IIntRepository<TypeAccompanimentPlan> TypeAccompanimentPlanRepository => new BaseIntRepository<TypeAccompanimentPlan>(_ctx);
        public IIntRepository<ResponseAccompanimentPlan> ResponseAccompanimentPlanRepository => new BaseIntRepository<ResponseAccompanimentPlan>(_ctx);
        public IIntRepository<ResponseAdditionalQuestion> ResponseAdditionalQuestionRepository => new BaseIntRepository<ResponseAdditionalQuestion>(_ctx);
        public IIntRepository<ResponseQuestion> ResponseQuestionRepository => new BaseIntRepository<ResponseQuestion>(_ctx);
        public IIntRepository<AdditionalQuestion> AdditionalQuestionRepository => new BaseIntRepository<AdditionalQuestion>(_ctx);
        public IIntRepository<QuestionnaireTemplate> QuestionnaireTemplateRepository => new BaseIntRepository<QuestionnaireTemplate>(_ctx);
        public IIntRepository<QuestionnaireQuestionTemplate> QuestionnaireQuestionTemplateRepository => new BaseIntRepository<QuestionnaireQuestionTemplate>(_ctx);
        public IIntRepository<ConfigurationNovelties> ConfigurationNoveltiesRepository => new BaseIntRepository<ConfigurationNovelties>(_ctx);
        public IIntRepository<TB_ASISTENCIA_MARCADORES> TB_ASISTENCIA_MARCADORESRepository => new BaseIntRepository<TB_ASISTENCIA_MARCADORES>(_ctx);
        public IRepository<NoveltyEntry> NoveltyEntryRepository => new BaseRepository<NoveltyEntry>(_ctx);
        public IRepository<NoveltyHistory> NoveltyHistoryRepository => new BaseRepository<NoveltyHistory>(_ctx);
        public IRepository<Resources> ResourcesRepository => new BaseRepository<Resources>(_ctx);

        public UnitOfWork(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
            
        }
        
        public string GetDbConnection()
        {
           return _ctx.Database.GetDbConnection().ConnectionString;
        }


        public void Dispose()
        {
            if (_ctx != null)
            {
                _ctx.Dispose();
            }
        }

        public void SaveChanges()
        {
            _ctx.SaveChanges();
        }




        public async Task SaveChangesAsync()
        {
            await _ctx.SaveChangesAsync();
        }
    }
}

using CleanArchitecture.Application.Common.Interfaces;
using Core.Models.Common;
using Core.Models.configuration;
using Domain.Models.AdministrativeProcesses;
using Domain.Models.ConfigurationDates;
using Domain.Models.Feedbacks;
using Domain.Models.Groups;
using Domain.Models.Mekano;
using Domain.Models.Novelties;
using Domain.Models.Overtimes;
using Domain.Models.Resources;
using Domain.Models.Rol;
using Domain.Models.User;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace CleanArch.Infra.Data.Context
{
    public class U27ApplicationDBContext : DbContext
    {
        private readonly ICurrentUserService _currentUserService;
        public U27ApplicationDBContext(
            DbContextOptions options,
            ICurrentUserService currentUserService
            ) : base(options)
        {
            _currentUserService = currentUserService;
        }

        #region Configuration
        public DbSet<Category> Categories { get; set; }
        public DbSet<Configuration> Configurations { get; set; }
        #endregion

        #region Groups

        public DbSet<PayrollAuthorize> PayrollAuthorizes { get; set; }


        #endregion

        #region ConfigurationDates

        public DbSet<Holiday> Holidays { get; set; }


        #endregion

        #region Overtimes

        public DbSet<OvertimeDetail> OvertimeDetails { get; set; }
        public DbSet<OvertimePeriod> OvertimePeriods { get; set; }
        public DbSet<OvertimeType> OvertimeTypes { get; set; }
        public DbSet<OvertimeTemp> OvertimeTemps { get; set; }

        [NotMapped]
        public DbSet<OvertimeTempErrors> OvertimeTempErrors { get; set; }
        public DbSet<ResponsabilityCostCenter> ResponsabilitiesCostCenter { get; set; }


        #endregion

        #region Mekano

        public DbSet<MekanoUser> MekanoUsers { get; set; }
        public DbSet<CostCenter> CostCenters { get; set; }



        #endregion

        #region User
        public DbSet<User> Users { get; set; }

        public DbSet<UserRol> UserRols { get; set; }

        #endregion

        #region Rol
        public DbSet<Rol> Rols { get; set; }

        #endregion

        #region AdministrativeProcesses

        public DbSet<DisciplinaryProcess> DisciplinaryProcesses { get; set; }
        public DbSet<ProcessChangeHistory> HistoryChangeprocesses { get; set; }
        public DbSet<ProcessStatus> ProcessStates { get; set; }
        public DbSet<TypeOfFault> TypesOfFaults { get; set; }
        public DbSet<ProcessSupport> ProcessSupports { get; set; }

        #endregion

        #region Novelties
        public DbSet<TB_ASISTENCIA_MARCADORES> TB_ASISTENCIA_MARCADORES { get; set; }
        public DbSet<ConfigurationNovelties> ConfigurationNovelties { get; set; }
        public DbSet<NoveltyEntry> NoveltyEntry { get; set; }
        public DbSet<NoveltyHistory> NoveltyHistory { get; set; }
        #endregion

        #region Feedbacks
        public DbSet<AccompanimentPlan> AccompanimentPlans { get; set; }
        public DbSet<TypeAccompanimentPlan> TypeAccompanimentPlans { get; set; }
        public DbSet<ResponseQuestion> ResponseQuestions { get; set; }
        public DbSet<AdditionalQuestion> AdditionalQuestions { get; set; }
        public DbSet<QuestionnaireTemplate> QuestionnaireTemplates { get; set; }
        public DbSet<QuestionnaireQuestionTemplate> QuestionnaireQuestionTemplates { get; set; }
        public DbSet<ResponseAccompanimentPlan> ResponseAccompanimentPlans { get; set; }
        public DbSet<ResponseAdditionalQuestion> ResponseAdditionalQuestions { get; set; }
        #endregion

        public DbSet<Resources> Resources { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Load all assemblies from configurations folder in infra.data
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder
                        .Entity<OvertimeTempErrors>(builder =>
                        {
                            builder.HasNoKey();
                            //builder.ToTable("MY_ENTITY");
                        });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            var UserInfo = _currentUserService.GetUserInfo();
            var userName = string.Concat(UserInfo.Name, " ", UserInfo.LastName);

            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<Entity> entry in ChangeTracker.Entries<Entity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.Id;
                        entry.Entity.CreatedByName = userName;
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _currentUserService.Id;
                        entry.Entity.UpdatedByName = userName;
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedAt = DateTime.Now;
                        entry.Entity.UpdatedByName = userName;
                        entry.Entity.UpdatedBy = _currentUserService.Id;
                        break;
                }
            }


            foreach (Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<EntityWithIntId> entry in ChangeTracker.Entries<EntityWithIntId>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedBy = _currentUserService.Id;
                        entry.Entity.LastCreatedByName = userName;
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedBy = _currentUserService.Id;
                        entry.Entity.LastUpdatedByName = userName;
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                    case EntityState.Deleted:
                        entry.Entity.DeletedAt = DateTime.Now;
                        entry.Entity.LastUpdatedByName = userName;
                        entry.Entity.UpdatedBy = _currentUserService.Id;
                        break;
                }
            }




            var result = await base.SaveChangesAsync(cancellationToken);


            return result;
        }
    }
}

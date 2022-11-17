using Application.Common.BulkInserts;
using Application.Common.Interfaces;
using Application.Interfaces.AdministrativeProcesses;
using Application.Interfaces.Configurations;
using Application.Interfaces.Feedbacks;
using Application.Interfaces.Mekano;
using Application.Interfaces.Novelties;
using Application.Interfaces.Overtimes;
using Application.Interfaces.Resources;
using Application.Interfaces.Rol;
using Application.Interfaces.User;
using Application.Services.AdministrativeProcesses;
using Application.Services.AdministrativeProcesses.ProcessStates;
using Application.Services.AdministrativeProcesses.TypeOfFaults;
using Application.Services.Configurations;
using Application.Services.Feedbacks;
using Application.Services.Mekano;
using Application.Services.Novelties;
using Application.Services.overtimes;
using Application.Services.Overtimes;
using Application.Services.Resources;
using Application.Services.Rol;
using Application.Services.User;
using CleanArch.Application.Interfaces.Auths;
using CleanArch.Application.Services.Auths;
using Domain.Interfaces;
using Infra.Data.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Infra.Ioc
{
    public static class ApplicationDependencycontainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
         
            services.AddScoped<IBulkInsert, BulkInsert>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();


            // Configuration
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<ICategoryService, CategoryService>();

            // overtime
            services.AddScoped<IOvertimeTypeService, OvertimeTypeService>();
            services.AddScoped<IOvertimePeriodService, OvertimePeriodService>();
            services.AddScoped<IOvertimeService, OvertimeService>();
           

            // Auth
            services.AddScoped<IAuthService, AuthService>();

            // User
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRolService, RolService>();
            services.AddScoped<IUserRolService, UserRolService>();

            // CostCenter
            services.AddScoped<ICostCenterService, CostCenterService>();
            services.AddScoped<IResponsabilityCostCenterService, ResponsabilityCostCenterService>();

            // MekanoUser
            services.AddScoped<IMekanoUserService, MekanoUserService>();
            services.AddScoped<IOvertimeTempService, OvertimeTempService>();

            //AdministrativeProcesses
            services.AddScoped<ITypeOfFaultService, TypeOfFaultService>();
            services.AddScoped<IProcessStatusService, ProcessStatusService>();
            services.AddScoped<IDisciplinaryProcessService, DisciplinaryProcessService>();
            services.AddScoped<IProcessHistoryChangeService, ProcessHistoryChangeService>();

            //Feedbacks
            services.AddScoped<IAccompanimentPlanService, AccompanimentPlanService>();
            services.AddScoped<ITypeAccompanimentPlanService, TypeAccompanimentPlanService>();
            services.AddScoped<IAdditionalQuestionService, AdditionalQuestionService>();
            services.AddScoped<IResponseAccompanimentPlanService, ResponseAccompanimentPlanService>();
            services.AddScoped<IResponseQuestionService, ResponseQuestionService>();
            services.AddScoped<IQuestionnaireQuestionTemplateService, QuestionnaireQuestionTemplateService>();
            services.AddScoped<IResponseAdditionalQuestionService, ResponseAdditionalQuestionService>();

            //Novelties
            services.AddScoped<INoveltiesService, NoveltiesService>();

            //Resources 
            services.AddScoped<IResourcesService, ResourcesService>();
        }

    }
}

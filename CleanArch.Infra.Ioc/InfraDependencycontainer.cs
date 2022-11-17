
using Domain.Interfaces;
using Domain.Interfaces.Configurations;
using Domain.Interfaces.Overtimes;
using Domain.Interfaces.User;
using Infra.Data.Repository;
using Infra.Data.Repository.Configurations;
using Infra.Data.Repository.Overtimes;
using Infra.Data.Repository.Users;
using Microsoft.Extensions.DependencyInjection;


namespace Infra.Ioc
{
    public static class InfraDependencycontainer
    {
        public static void RegisterServices(IServiceCollection services)
        {

            // Configuration
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<IAuthRepository, AuthRepository>();           

            // User
            services.AddScoped<IUserRepository, UserRepository>();

            // Rol
            services.AddScoped<IRolRepository, RolRepository>();

            // UserRol
            services.AddScoped<IUserRolRepository, UserRolRepository>();

            // Overtimes
            services.AddScoped<IOvertimeTempRepository, OvertimeTempRepository>();

            #region GenericRepository
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            #endregion


        }

    }
}

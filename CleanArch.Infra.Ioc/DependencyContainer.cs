using CleanArch.Infra.Data.Context;
using Infra.Ioc;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.Infra.Ioc
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        { 

            services.AddScoped<U27ApplicationDBContext>();

            //Core Services
            //services.AddScoped<ISMSNotification, SMSNotification>();
 
            //Application Layer.
            ApplicationDependencycontainer.RegisterServices(services);

            // Infra.Data Layer
            InfraDependencycontainer.RegisterServices(services);

            // Infra.Data Layer
            CoreServiceContainer.RegisterServices(services);


        }
    }
}

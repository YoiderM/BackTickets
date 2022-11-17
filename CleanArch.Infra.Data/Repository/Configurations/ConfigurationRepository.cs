using CleanArch.Infra.Data.Context;
using Core.Models.configuration;
using Domain.Interfaces.Configurations;
using System.Linq;

namespace Infra.Data.Repository.Configurations
{
    public class ConfigurationRepository : IConfigurationRepository
    {

        private readonly U27ApplicationDBContext _ctx;

        public ConfigurationRepository(U27ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public IQueryable<Configuration> Get()
        {           
            return _ctx.Configurations;
        }
    }
}

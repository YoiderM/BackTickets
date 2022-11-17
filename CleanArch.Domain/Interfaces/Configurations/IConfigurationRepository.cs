using Core.Models.configuration;
using System.Linq;

namespace Domain.Interfaces.Configurations
{
    public interface IConfigurationRepository
    {
        IQueryable<Configuration> Get();
    }
}

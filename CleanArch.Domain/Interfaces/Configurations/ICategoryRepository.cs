using Core.Models.configuration;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Interfaces.Configurations
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Get();
        Category Post(Category category);
        Category Put(Category category);
        Category Activate(Category category);
        Task<Category> Deactivate(Category category);
        bool Delete(Category category);
    }
}

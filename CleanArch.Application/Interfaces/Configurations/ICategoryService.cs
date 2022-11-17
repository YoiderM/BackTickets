using Application.Configurations.Categories.Command;
using Application.DTOs.Configurations;
using Core.Models.configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Interfaces.Configurations
{
    public interface ICategoryService
    {
        List<CategoryDto> GetCategories();
        Category PostCategory(Category category);
        Category PutCategory(PutCategoryCommand category);
        Category ActivateCategory(Guid id);
        Task<Category> DeactivateCategory(Guid id);
        bool DeleteCategory(Guid id);
      
    }
}

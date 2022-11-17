using Application.Configurations.Categories.Command;
using Application.Core.Exceptions;
using Application.DTOs.Configurations;
using Application.Interfaces.Configurations;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Core.Models.configuration;
using Domain.Interfaces.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Services.Configurations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public List<CategoryDto> GetCategories()
        {
            var source = _categoryRepository.Get().ProjectTo<CategoryDto>(_mapper.ConfigurationProvider).ToList();

            return source;
                                         
        }
        public Category PostCategory(Category category)
        {
            return _categoryRepository.Post(category);
        }

        public Category PutCategory(PutCategoryCommand putCategoryCommand)
        {
            Category category = GetCategoryById(putCategoryCommand.Id);

            if (category == null)
            {
                throw new NotFoundException("Category", "Id");
            }

            category = _mapper.Map<PutCategoryCommand, Category>(putCategoryCommand, category);

            _categoryRepository.Put(category);

            return category;
        }

        public Category ActivateCategory(Guid id)
        {
            CategoryDto categoryDto = _categoryRepository.Get()
                                             .Where(x => x.Id == id)
                                             .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                                             .FirstOrDefault();
            if (categoryDto == null)
            {
                throw new NotFoundException("categoryDto", "Id");
            }

            Category category = _mapper.Map<Category>(categoryDto);

            return _categoryRepository.Activate(category);
        }

        public async Task<Category> DeactivateCategory(Guid id)
        {
            CategoryDto categoryDto = await _categoryRepository.Get()
                                            .Where(x => x.Id == id)
                                            .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                                            .FirstOrDefaultAsync();
            if (categoryDto == null)
            {
                throw new NotFoundException("categoryDto", "Id");
            }

            Category category = _mapper.Map<Category>(categoryDto);

            return await _categoryRepository.Deactivate(category);
        }

        private Category GetCategoryById(Guid id)
        {
            return _categoryRepository
                  .Get()
                  .Where(x => x.Id == id)
                  .FirstOrDefault();
        }

        public bool DeleteCategory(Guid id)
        {
            CategoryDto categoryDto = _categoryRepository.Get()
                                                         .Where(x => x.Id == id)
                                                         .ProjectTo<CategoryDto>(_mapper.ConfigurationProvider)
                                                         .FirstOrDefault();
            if (categoryDto == null)
            {
                throw new NotFoundException("categoryDto", "Id");
            }

            Category category = _mapper.Map<Category>(categoryDto);

            return _categoryRepository.Delete(category);
        }

       
    }
}

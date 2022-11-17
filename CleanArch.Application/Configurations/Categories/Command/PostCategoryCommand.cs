using Application.DTOs.Configurations;
using Application.Interfaces.Configurations;
using AutoMapper;
using Core.Models.configuration;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Configurations.Categories.Command
{
    public class PostCategoryCommand : IRequest<CategoryDto>
    {        
        public string Name { get; set; }

        public bool Status { get; set; } = true;

        public string Description { get; set; }

        public bool CanChanged { get; set; } = true;
    }

    public class PostCategoryCommandHandler : IRequestHandler<PostCategoryCommand, CategoryDto>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public PostCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(PostCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _categoryService
                                                  .PostCategory(_mapper.Map<Category>(request));

            return _mapper.Map<CategoryDto>(category);
        }
    }
}

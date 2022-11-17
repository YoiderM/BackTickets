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
    public class PutCategoryCommand : IRequest<CategoryDto>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public bool Status { get; set; } = true;

        public string Description { get; set; }

        public bool CanChanged { get; set; } = true;
    }

    public class PutCategoryCommandHandler : IRequestHandler<PutCategoryCommand, CategoryDto>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public PutCategoryCommandHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(PutCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _categoryService.PutCategory(request);

            return await Task.Run(() => _mapper.Map<CategoryDto>(category));
        }

    }
}

using Application.DTOs.Configurations;
using Application.Interfaces.Configurations;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Cqrs.Categories
{
    public class GetCategoryQuery : IRequest<List<CategoryDto>>
    {

    }
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, List<CategoryDto>>
    {
        private readonly ICategoryService _categoryService;
        public GetCategoryQueryHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            return _categoryService.GetCategories();
        }
    }
}

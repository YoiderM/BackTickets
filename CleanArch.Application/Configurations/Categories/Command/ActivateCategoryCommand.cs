using Application.Interfaces.Configurations;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Configurations.Categories.Command
{
    public class ActivateCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class ActivateCategoryCommandHandler : IRequestHandler<ActivateCategoryCommand, bool>
    {

        private readonly ICategoryService _categoryService;

        public ActivateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public async Task<bool> Handle(ActivateCategoryCommand request, CancellationToken cancellationToken)
        {
            _categoryService.ActivateCategory(request.Id);

            return true;
        }
    }
}

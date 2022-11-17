using Application.Interfaces.Configurations;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Configurations.Categories.Command
{
    public class DeactivateCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class DeactivateCategoryCommandHandler : IRequestHandler<DeactivateCategoryCommand, bool>
    {

        private readonly ICategoryService _categoryService;

        public DeactivateCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public async Task<bool> Handle(DeactivateCategoryCommand request, CancellationToken cancellationToken)
        {
            _categoryService.DeactivateCategory(request.Id);

            return await Task.Run(() => true);
        }
    }
}

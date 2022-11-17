using Application.Interfaces.Configurations;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Configurations.Categories.Command
{
    public class DeleteCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }

    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
    {

        private readonly ICategoryService _categoryService;

        public DeleteCategoryCommandHandler(ICategoryService categoryService)
        {
            _categoryService = categoryService;

        }

        public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            _categoryService.DeleteCategory(request.Id);

            return true;
        }
    }
}

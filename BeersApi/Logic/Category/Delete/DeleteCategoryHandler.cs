using BeersApi.Components.Infrastructure;
using MediatorWrapper.Errors;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BeersApi.Logic.Category.Delete
{
  
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryRequest, DeleteCategoryResponse>
    {
        private readonly IDbContextFactory dbContextFactory;

        public DeleteCategoryHandler(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<DeleteCategoryResponse> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
        {
            var databaseContext = this.dbContextFactory.GetDbContext();

            var category = await databaseContext.Categories.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (category == null)
            {
                return ErrorCode.ItemNotFound.CreateErrorResponse<DeleteCategoryResponse>("Category NotFound", $"Category with Id: {request.Id} NotFound");
            }

            databaseContext.Categories.Remove(category);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return new DeleteCategoryResponse();
        }
    }
}

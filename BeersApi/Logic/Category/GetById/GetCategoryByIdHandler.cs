using BeersApi.Components.Infrastructure;
using MediatorWrapper.Errors;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BeersApi.Logic.Category.GetById
{ 
    public class GetCategoryByIdHandler : IRequestHandler<GetCategoryByIdRequest, GetCategoryByIdResponse>
    {
        private readonly IDbContextFactory dbContextFactory;

        public GetCategoryByIdHandler(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<GetCategoryByIdResponse> Handle(GetCategoryByIdRequest request, CancellationToken cancellationToken)
        {
            var databaseContext = this.dbContextFactory.GetDbContext();

            var category = await databaseContext.Categories.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (category == null)
            {
                return ErrorCode.ItemNotFound.CreateErrorResponse<GetCategoryByIdResponse>("Category NotFound", $"Category with Id: {request.Id} NotFound");
            }

            return new GetCategoryByIdResponse
            {
                Category = category,
            };
        }
    }
}

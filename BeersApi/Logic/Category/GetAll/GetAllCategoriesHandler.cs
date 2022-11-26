using BeersApi.Components.Infrastructure;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BeersApi.Logic.Category.GetAll
{
    public class GetAllCategoriesHandler : IRequestHandler<GetAllCategoriesRequest, GetAllCategoriesResponse>
    {
        private readonly IDbContextFactory serviceScopeRepository;

        public GetAllCategoriesHandler(IDbContextFactory serviceScopeRepository)
        {
            this.serviceScopeRepository = serviceScopeRepository;
        }

        public async Task<GetAllCategoriesResponse> Handle(GetAllCategoriesRequest request, CancellationToken cancellationToken)
        {
            var databaseContext = this.serviceScopeRepository.GetDbContext();

            var categoryList = await databaseContext.Categories.ToListAsync(cancellationToken);

            return new GetAllCategoriesResponse
            {
                Categories = categoryList,
            };
        }
    }
}

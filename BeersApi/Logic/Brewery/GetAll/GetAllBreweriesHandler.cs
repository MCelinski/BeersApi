using BeersApi.Components.Infrastructure;
using BeersApi.Logic.Category.GetAll;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BeersApi.Logic.Brewery.GetAll
{
    public class GetAllBreweriesHandler : IRequestHandler<GetAllBreweriesRequest, GetAllBreweriesResponse>
    {
        private readonly IDbContextFactory serviceScopeRepository;

        public GetAllBreweriesHandler(IDbContextFactory serviceScopeRepository)
        {
            this.serviceScopeRepository = serviceScopeRepository;
        }

        public async Task<GetAllBreweriesResponse> Handle(GetAllBreweriesRequest request, CancellationToken cancellationToken)
        {
            var databaseContext = this.serviceScopeRepository.GetDbContext();

            var breweries = await databaseContext.Breweries.ToListAsync(cancellationToken);

            return new GetAllBreweriesResponse
            {
                Breweries = breweries,
            };
        }
    }
}

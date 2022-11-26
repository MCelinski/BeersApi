using BeersApi.Components.Infrastructure;
using MediatorWrapper.Errors;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BeersApi.Logic.Brewery.Delete
{
  
    public class DeleteBreweryHandler : IRequestHandler<DeleteBreweryRequest, DeleteBreweryResponse>
    {
        private readonly IDbContextFactory dbContextFactory;

        public DeleteBreweryHandler(IDbContextFactory dbContextFactory)
        {
            this.dbContextFactory = dbContextFactory;
        }

        public async Task<DeleteBreweryResponse> Handle(DeleteBreweryRequest request, CancellationToken cancellationToken)
        {
            var databaseContext = this.dbContextFactory.GetDbContext();

            var brewery = await databaseContext.Breweries.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (brewery == null)
            {
                return ErrorCode.ItemNotFound.CreateErrorResponse<DeleteBreweryResponse>("Brewery NotFound", $"Brewery with Id: {request.Id} NotFound");
            }

            databaseContext.Breweries.Remove(brewery);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return new DeleteBreweryResponse();
        }
    }
}

using AutoMapper;
using BeersApi.Components.Infrastructure;
using BeersApi.Logic.Category.Put;
using MediatorWrapper.Errors;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BeersApi.Logic.Brewery.Put
{
    public class PutBreweryHandler : IRequestHandler<PutBreweryRequest, PutBreweryResponse>
    {
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PutDeviceHandler"/> class.
        /// </summary>
        /// <param name="dbContextFactory"></param>
        /// <param name="mapper"></param>
        public PutBreweryHandler(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handle method for updating Device.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response.</returns>
        public async Task<PutBreweryResponse> Handle(PutBreweryRequest request, CancellationToken cancellationToken)
        {
            var databaseContext = this.dbContextFactory.GetDbContext();

            var brewery = await databaseContext.Breweries.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
            if (brewery == null)
            {
                return ErrorCode.ItemNotFound.CreateErrorResponse<PutBreweryResponse>("Brewery NotFound", $"Brewery with Id: {request.Id} NotFound");
            }

            var breweryExist = await databaseContext.Breweries.AnyAsync(u => u.Name == request.Name, cancellationToken);
            if (breweryExist)
            {
                return ErrorCode.ObjectExists.CreateErrorResponse<PutBreweryResponse>("Brewery already exist", $"Brewery with Name: {request.Name} already exist");
            }

            this.mapper.Map(request, brewery);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return new PutBreweryResponse
            {
                Category = brewery,
            };
        }
    }
}

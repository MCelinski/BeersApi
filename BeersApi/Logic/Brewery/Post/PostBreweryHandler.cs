using AutoMapper;
using BeersApi.Components.Infrastructure;
using BeersApi.Logic.Category.Post;
using MediatorWrapper.Errors;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BeersApi.Logic.Brewery.Post
{
    public class PostBreweryHandler : IRequestHandler<PostBreweryRequest, PostBreweryResponse>
    {
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper mapper;


        public PostBreweryHandler(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public async Task<PostBreweryResponse> Handle(PostBreweryRequest request, CancellationToken cancellationToken)
        {
            var databaseContext = this.dbContextFactory.GetDbContext();

            var breweryExists = await databaseContext.Breweries.AnyAsync(u => u.Name == request.Name, cancellationToken);
            if (breweryExists)
            {
                return ErrorCode.ObjectExists.CreateErrorResponse<PostBreweryResponse>("Brewery already assigned", $"Brewery with Name: {request.Name} is already assigned");
            }

            var brewery = this.mapper.Map<Models.Entities.Brewery>(request);

            databaseContext.Breweries.Add(brewery);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return new PostBreweryResponse()
            {
                Id = brewery.Id,
            };
        }
    }
}

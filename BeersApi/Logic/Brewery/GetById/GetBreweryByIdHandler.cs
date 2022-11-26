using AutoMapper;
using BeersApi.Components.Infrastructure;
using BeersApi.Logic.Brewery.Post;
using MediatorWrapper.Errors;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using BeersApi.Logic.Category.GetById;

namespace BeersApi.Logic.Brewery.GetById
{


    public class GetBreweryByIdHandler : IRequestHandler<GetBreweryByIdRequest, GetBreweryByIdResponse>
    {
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper mapper;


        public GetBreweryByIdHandler(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public async Task<GetBreweryByIdResponse> Handle(GetBreweryByIdRequest request, CancellationToken cancellationToken)
        {
            var databaseContext = this.dbContextFactory.GetDbContext();

            var brewery = await databaseContext.Breweries.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);

            if (brewery == null)
            {
                return ErrorCode.ItemNotFound.CreateErrorResponse<GetBreweryByIdResponse>("Brewery NotFound", $"Brewery with Id: {request.Id} NotFound");
            }

            return new GetBreweryByIdResponse()
            {
                Brewery = brewery
            };
        }
    }
}

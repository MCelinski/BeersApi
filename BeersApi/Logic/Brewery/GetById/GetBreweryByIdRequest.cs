using MediatR;

namespace BeersApi.Logic.Brewery.GetById
{
    public class GetBreweryByIdRequest : IRequest<GetBreweryByIdResponse>
    {
        public int Id { get; set; }
    }
}

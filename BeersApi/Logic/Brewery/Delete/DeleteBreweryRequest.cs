using MediatR;

namespace BeersApi.Logic.Brewery.Delete
{
    public class DeleteBreweryRequest : IRequest<DeleteBreweryResponse>
    {
        public int Id { get; set; }
    }
}

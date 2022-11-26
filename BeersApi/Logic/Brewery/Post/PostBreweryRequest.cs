using MediatR;

namespace BeersApi.Logic.Brewery.Post
{
    public class PostBreweryRequest : IRequest<PostBreweryResponse>
    {

        public string Name { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}

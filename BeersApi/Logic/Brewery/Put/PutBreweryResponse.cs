using MediatorWrapper.Models;

namespace BeersApi.Logic.Brewery.Put
{
    public class PutBreweryResponse : ResponseBase
    {
        public Models.Entities.Brewery Category { get; set; }
    }
}

using MediatorWrapper.Models;

namespace BeersApi.Logic.Brewery.GetById
{
    public class GetBreweryByIdResponse : ResponseBase
    {
        public Models.Entities.Brewery Brewery { get; set; }
    }
}

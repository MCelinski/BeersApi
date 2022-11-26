using MediatorWrapper.Models;
using System.Collections.Generic;

namespace BeersApi.Logic.Brewery.GetAll
{
    public class GetAllBreweriesResponse : ResponseBase
    {
        public IEnumerable<Models.Entities.Brewery> Breweries { get; set; }
    }
}

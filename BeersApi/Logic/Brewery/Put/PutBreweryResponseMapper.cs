using BeersApi.Components.Infrastructure;
using BeersApi.Logic.Category.Put;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Logic.Brewery.Put
{

    public class PutBreweryResponseMapper : HttpResponseMapperBase, IHttpResponseMapper<PutBreweryResponse>
    {
        public IActionResult Map(PutBreweryResponse response) =>
            response.HasError ? this.MapErrors(response) : new OkObjectResult(response);
    }
}

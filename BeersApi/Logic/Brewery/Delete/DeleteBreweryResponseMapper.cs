using BeersApi.Components.Infrastructure;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Logic.Brewery.Delete
{

    public class DeleteBreweryResponseMapper : HttpResponseMapperBase, IHttpResponseMapper<DeleteBreweryResponse>
    {
        public IActionResult Map(DeleteBreweryResponse response) =>
            response.HasError ? this.MapErrors(response) : new StatusCodeResult(StatusCodes.Status204NoContent);
    }
}

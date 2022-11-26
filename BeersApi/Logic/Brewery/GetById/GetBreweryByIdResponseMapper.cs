using BeersApi.Components.Infrastructure;
using BeersApi.Controllers;
using BeersApi.Logic.Brewery.Delete;
using BeersApi.Logic.Brewery.Post;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Logic.Brewery.GetById
{
    public class GetBreweryByIdResponseMapper : HttpResponseMapperBase, IHttpResponseMapper<PostBreweryResponse>
    {
        public IActionResult Map(PostBreweryResponse response) =>
             response.HasError ? this.MapErrors(response) : new StatusCodeResult(StatusCodes.Status204NoContent);
    }
}

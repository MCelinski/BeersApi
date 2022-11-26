using BeersApi.Components.Infrastructure;
using BeersApi.Controllers;
using BeersApi.Logic.Category.Post;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Logic.Brewery.Post
{

    public class PostBreweryResponseMapper : HttpResponseMapperBase, IHttpResponseMapper<PostBreweryResponse>
    {
        public IActionResult Map(PostBreweryResponse response) =>
            response.HasError ? this.MapErrors(response) : new CreatedAtRouteResult(new { action = nameof(BreweriesController.GetById), id = response.Id }, null);
    }
}

using BeersApi.Components.Infrastructure;
using BeersApi.Controllers;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Logic.Category.Post
{
    public class PostCategoryResponseMapper : HttpResponseMapperBase, IHttpResponseMapper<PostCategoryResponse>
    {
        public IActionResult Map(PostCategoryResponse response) =>
            response.HasError ? this.MapErrors(response) : new CreatedAtRouteResult(new { action = nameof(CategoriesController.GetById), id = response.Id }, null);
    }
}

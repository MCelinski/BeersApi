using BeersApi.Components.Infrastructure;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Logic.Category.Delete
{

    public class DeleteCategoryResponseMapper : HttpResponseMapperBase, IHttpResponseMapper<DeleteCategoryResponse>
    {
        public IActionResult Map(DeleteCategoryResponse response) =>
            response.HasError ? this.MapErrors(response) : new StatusCodeResult(StatusCodes.Status204NoContent);
    }
}

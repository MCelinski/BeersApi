using BeersApi.Components.Infrastructure;
using BeersApi.Logic.Category.GetById;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Logic.Category.Put
{
    public class PutCategoryResponseMapper : HttpResponseMapperBase, IHttpResponseMapper<PutCategoryResponse>
    {

        public IActionResult Map(PutCategoryResponse response) =>
            response.HasError ? this.MapErrors(response) : new OkObjectResult(response);
    }
}

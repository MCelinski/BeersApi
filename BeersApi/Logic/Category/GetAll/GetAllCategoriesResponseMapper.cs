using BeersApi.Components.Infrastructure;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Logic.Category.GetAll
{
    public class GetAllCategoriesResponseMapper : HttpResponseMapperBase, IHttpResponseMapper<GetAllCategoriesResponse>
    {
        public IActionResult Map(GetAllCategoriesResponse response) =>
            response.HasError ? this.MapErrors(response) : new OkObjectResult(response);
    }
}

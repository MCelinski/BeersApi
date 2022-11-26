using BeersApi.Components.Infrastructure;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Logic.Category.GetById
{
    public class GetCategoryByIdResponseMapper : HttpResponseMapperBase, IHttpResponseMapper<GetCategoryByIdResponse>
    {

        public IActionResult Map(GetCategoryByIdResponse response) =>
            response.HasError ? this.MapErrors(response) : new OkObjectResult(response);
    }
}


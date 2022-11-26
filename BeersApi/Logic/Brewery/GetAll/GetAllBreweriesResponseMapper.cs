using BeersApi.Components.Infrastructure;
using BeersApi.Logic.Category.GetAll;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Mvc;

namespace BeersApi.Logic.Brewery.GetAll
{

    public class GetAllBreweriesResponseMapper : HttpResponseMapperBase, IHttpResponseMapper<GetAllBreweriesResponse>
    {
        public IActionResult Map(GetAllBreweriesResponse response) =>
            response.HasError ? this.MapErrors(response) : new OkObjectResult(response);
    }
}

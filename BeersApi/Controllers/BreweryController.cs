using BeersApi.Logic.Brewery.Delete;
using BeersApi.Logic.Brewery.GetAll;
using BeersApi.Logic.Brewery.GetById;
using BeersApi.Logic.Brewery.Post;
using BeersApi.Logic.Brewery.Put;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BeersApi.Controllers
{
    [Route("api/[controller]")]
    public class BreweriesController : ControllerBase
    {
        private readonly IHttpMediator httpMediator;

        public BreweriesController(IHttpMediator httpMediator)
        {
            this.httpMediator = httpMediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostBreweryRequest request) => await this.httpMediator.Send(request);

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllBreweriesRequest request) => await this.httpMediator.Send(request);

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetBreweryByIdRequest request) => await this.httpMediator.Send(request);

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteBreweryRequest request) => await this.httpMediator.Send(request);

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(PutBreweryRequest request) => await this.httpMediator.Send(request);
    }
}

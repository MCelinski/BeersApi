using BeersApi.Logic.Category.Delete;
using BeersApi.Logic.Category.GetAll;
using BeersApi.Logic.Category.GetById;
using BeersApi.Logic.Category.Post;
using BeersApi.Logic.Category.Put;
using MediatorWrapper.HttpMediation;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BeersApi.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly IHttpMediator httpMediator;

        public CategoriesController(IHttpMediator httpMediator)
        {
            this.httpMediator = httpMediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostCategoryRequest request) => await this.httpMediator.Send(request);

        [HttpGet]
        public async Task<IActionResult> GetAll(GetAllCategoriesRequest request) => await this.httpMediator.Send(request);

        [HttpGet]
        [Route("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetCategoryByIdRequest request) => await this.httpMediator.Send(request);

        [HttpDelete]
        [Route("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCategoryRequest request) => await this.httpMediator.Send(request);

        [HttpPut("{Id}")]
        public async Task<IActionResult> Update(PutCategoryRequest request) => await this.httpMediator.Send(request);


    }
}

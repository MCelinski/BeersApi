using MediatR;

namespace BeersApi.Logic.Category.Put
{
    public class PutCategoryRequest : IRequest<PutCategoryResponse>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

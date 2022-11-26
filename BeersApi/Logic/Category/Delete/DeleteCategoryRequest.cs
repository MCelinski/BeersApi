using MediatR;

namespace BeersApi.Logic.Category.Delete
{
    public class DeleteCategoryRequest : IRequest<DeleteCategoryResponse>
    {
        public int Id { get; set; }
    }
}

using MediatR;

namespace BeersApi.Logic.Category.Post
{
    public class PostCategoryRequest : IRequest<PostCategoryResponse>
    {
        public string Name { get; set; }
    }
}

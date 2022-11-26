using MediatR;

namespace BeersApi.Logic.Category.GetById
{
    public class GetCategoryByIdRequest : IRequest<GetCategoryByIdResponse>
    {
        public int Id { get; set; }
    }
}

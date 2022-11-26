using AutoMapper;
using BeersApi.Components.Infrastructure;
using MediatorWrapper.Errors;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;


namespace BeersApi.Logic.Category.Post
{
    public class PostCategoryHandler : IRequestHandler<PostCategoryRequest, PostCategoryResponse>
    {
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper mapper;


        public PostCategoryHandler(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        public async Task<PostCategoryResponse> Handle(PostCategoryRequest request, CancellationToken cancellationToken)
        {
            var databaseContext = this.dbContextFactory.GetDbContext();

            var categoryExists = await databaseContext.Categories.AnyAsync(u => u.Name == request.Name, cancellationToken);
            if (categoryExists)
            {
                return ErrorCode.ObjectExists.CreateErrorResponse<PostCategoryResponse>("Category already assigned", $"Category with Name: {request.Name} is already assigned");
            }

            var category = this.mapper.Map<Models.Entities.Category>(request);

            databaseContext.Categories.Add(category);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return new PostCategoryResponse()
            {
                Id = category.Id,
            };
        }

    }
}

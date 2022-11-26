using AutoMapper;
using BeersApi.Components.Infrastructure;
using MediatorWrapper.Errors;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;

namespace BeersApi.Logic.Category.Put
{
    public class PutCategoryHandler : IRequestHandler<PutCategoryRequest, PutCategoryResponse>
    {
        private readonly IDbContextFactory dbContextFactory;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="PutDeviceHandler"/> class.
        /// </summary>
        /// <param name="dbContextFactory"></param>
        /// <param name="mapper"></param>
        public PutCategoryHandler(IDbContextFactory dbContextFactory, IMapper mapper)
        {
            this.dbContextFactory = dbContextFactory;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handle method for updating Device.
        /// </summary>
        /// <param name="request"></param>
        /// <param name="cancellationToken"></param>
        /// <returns>Response.</returns>
        public async Task<PutCategoryResponse> Handle(PutCategoryRequest request, CancellationToken cancellationToken)
        {
            var databaseContext = this.dbContextFactory.GetDbContext();

            var category = await databaseContext.Categories.FirstOrDefaultAsync(a => a.Id == request.Id, cancellationToken);
            if (category == null)
            {
                return ErrorCode.ItemNotFound.CreateErrorResponse<PutCategoryResponse>("Category NotFound", $"Category with Id: {request.Id} NotFound");
            }

            var categoryExist = await databaseContext.Categories.AnyAsync(u => u.Name == request.Name, cancellationToken);
            if (categoryExist)
            {
                return ErrorCode.ObjectExists.CreateErrorResponse<PutCategoryResponse>("Category already exist", $"Category with Name: {request.Name} already exist");
            }

            this.mapper.Map(request, category);
            await databaseContext.SaveChangesAsync(cancellationToken);

            return new PutCategoryResponse
            {
                Category = category,
            };
        }
    }
}

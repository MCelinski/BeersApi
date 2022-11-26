using BeersApi.Data;
using Microsoft.Extensions.DependencyInjection;

namespace BeersApi.Components.Infrastructure
{
    public class DbContextFactory : IDbContextFactory
    {
        private readonly IServiceScopeFactory serviceScopeFactory;

        /// <summary>
        /// Initializes a new instance of the <see cref="DbContextFactory"/> class.
        /// </summary>
        /// <param name="serviceScopeFactory"></param>
        public DbContextFactory(IServiceScopeFactory serviceScopeFactory)
        {
            this.serviceScopeFactory = serviceScopeFactory;
        }

        /// <summary>
        /// Creates scope and returns context.
        /// </summary>
        /// <returns>AppDbContext.</returns>
        public AppDbContext GetDbContext() => this.serviceScopeFactory.CreateScope().ServiceProvider.GetRequiredService<AppDbContext>();
    }
}

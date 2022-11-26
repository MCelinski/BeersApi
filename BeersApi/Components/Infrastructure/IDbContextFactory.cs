using BeersApi.Data;

namespace BeersApi.Components.Infrastructure
{
    public interface IDbContextFactory
    {
        /// <summary>
        /// Gets DbContext.
        /// </summary>
        /// <returns>AppDbContext.</returns>
        AppDbContext GetDbContext();
    }
}

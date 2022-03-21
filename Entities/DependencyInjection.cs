using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Entities
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(configuration.GetConnectionString("BloggingDatabase")));
            return services;
        }
    }
}

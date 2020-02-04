using BooksStore.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BooksStore.Infrastructure
{
    public static class StartupSetup
    {
        public static IConfiguration Configuration { get; }
        public static void AddDbContext(this IServiceCollection services) =>
            services.AddDbContext<BooksStoreContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
    }
}

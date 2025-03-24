using LojaVirtual.Core.Infra.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Mvc.Configurations
{
    public static class DbContextIdentityConfig
    {
        public static IServiceCollection AddDbContextIdentityConfig(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<LojaVirtualContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<LojaVirtualContext>();

            return services;
        }
    }
}

using LojaVirtual.Core.Business.Extensions.IdentityUser;
using LojaVirtual.Core.Business.Interfaces;
using LojaVirtual.Core.Business.Notifications;
using LojaVirtual.Core.Business.Services;
using LojaVirtual.Core.Infra.Repositories;

namespace LojaVirtual.Mvc.Configurations
{
    public static class DependencyInjectingConfig
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            // Repositories
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();
            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            //Notification
            services.AddScoped<INotifiable, Notifiable>();

            //Services
            services.AddScoped<ICategoriaService, CategoriaService>();
           
            services.AddScoped<IAppIdentifyUser, AppIdentityUser>();


            return services;
        }
    }
}

using AutoMapper;
using LojaVirtual.Core.Business.Entities;
using LojaVirtual.Mvc.Models;

namespace LojaVirtual.Mvc.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Categoria, CategoriaViewModel>().ReverseMap();
        }
    }
    public static class AutoMapperAdd
    {
        public static IServiceCollection AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            return services;
        }
    }
}

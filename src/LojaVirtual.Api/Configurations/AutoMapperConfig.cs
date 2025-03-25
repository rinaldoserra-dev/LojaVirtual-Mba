using AutoMapper;
using LojaVirtual.Api.Models;
using LojaVirtual.Core.Business.Entities;

namespace LojaVirtual.Api.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {            
            CreateMap<Categoria, CategoriaModel>().ReverseMap();            
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

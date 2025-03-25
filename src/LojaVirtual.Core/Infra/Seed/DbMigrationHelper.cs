using LojaVirtual.Core.Business.Entities;
using LojaVirtual.Core.Infra.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace LojaVirtual.Core.Infra.Seed
{
    public static class DbMigrationHelperExtension
    {
        public static void UseDbMigrationHelper(this WebApplication app)
        {
            DbMigrationHelper.EnsureSeedData(app).Wait();
        }
    }
    public static class DbMigrationHelper
    {
        public static async Task EnsureSeedData(WebApplication application)
        {
            var services = application.Services.CreateScope().ServiceProvider;
            await EnsureSeedData(services);
        }
        public static async Task EnsureSeedData(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope();
            var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();

            var context = scope.ServiceProvider.GetRequiredService<LojaVirtualContext>();

            if (env.EnvironmentName == "Development")

            {
                await context.Database.MigrateAsync();

                await EnsureSeedTables(context);
            }
        }
        private static async Task EnsureSeedTables(LojaVirtualContext context)
        {
            if (context.CategoriaSet.Any()) return;

            var idUser = Guid.NewGuid();

            var usuario = new IdentityUser
            {
                Id = idUser.ToString(),
                Email = "vendedor@teste.com",
                EmailConfirmed = true,
                NormalizedEmail = "VENDEDOR@TESTE.COM",
                UserName = "vendedor@teste.com",
                AccessFailedCount = 0,
                PasswordHash = "AQAAAAIAAYagAAAAEF/nmfwFGPa8pnY9AvZL8HKI7r7l+aM4nryRB+Y3Ktgo6d5/0d25U2mhixnO4h/K5w==",
                NormalizedUserName = "VENDEDOR@TESTE.COM"
            };
            
            var vendedor = new Vendedor(idUser, usuario.UserName);
            var categoria = new Categoria("Informática", "Descrição da categoria Informática");

            categoria.AddProduto(new Produto("Mouse", "Descrição do produto Mouse", "mouse.jpg", 100, 20, categoria.Id, vendedor.Id));

            await context.Users.AddAsync(usuario);
            await context.VendedorSet.AddAsync(vendedor);
            await context.CategoriaSet.AddAsync(categoria);

            await context.SaveChangesAsync();
        }
    }
}

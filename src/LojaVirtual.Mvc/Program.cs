using LojaVirtual.Core.Infra.Seed;
using LojaVirtual.Mvc.Configurations;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
    .AddDbContextIdentityConfig(builder.Configuration)
    .RegisterServices()
    .AddAutoMapper()
    .AddMvcConfiguration()
    .AddControllersWithViews();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseGlobalizationConfig();

app.UseStatusCodePagesWithReExecute("/Erro/{0}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.UseDbMigrationHelper();

app.Run();

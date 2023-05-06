using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.Contexts;
using WebStore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>(x=> x.UseSqlServer(builder.Configuration.GetConnectionString("SqlCS")));
builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<SeedRolesService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddIdentity<IdentityUser, IdentityRole>(x =>
{
    x.Password.RequiredLength = 4;
    x.Password.RequireNonAlphanumeric = false;
    x.Password.RequireUppercase = false;
    x.User.RequireUniqueEmail = false;
    x.SignIn.RequireConfirmedAccount = false;
    
}).AddEntityFrameworkStores<IdentityContext>();

var app = builder.Build();

//seed roles
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var seedRolesService = services.GetRequiredService<SeedRolesService>();
seedRolesService.SeedAsync().Wait();






app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

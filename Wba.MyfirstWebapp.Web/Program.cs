using Microsoft.EntityFrameworkCore;
using Pri.Ca.Core.Interfaces.Repositories;
using Pri.Ca.Core.Interfaces.Services;
using Pri.Ca.Core.Services;
using Pri.Ca.Infrastructure.Data;
using Pri.Ca.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

//Register dbContext
builder.Services.AddDbContext<ApplicationDbcontext>
    (options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("GamesDb")));
// Add services to the container.
//register repositories
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
//register services
builder.Services.AddScoped<IGameService, GameService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

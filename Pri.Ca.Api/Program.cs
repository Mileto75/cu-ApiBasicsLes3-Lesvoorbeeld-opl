using Microsoft.EntityFrameworkCore;
using Pri.Ca.Core.Interfaces.Repositories;
using Pri.Ca.Core.Interfaces.Services;
using Pri.Ca.Core.Services;
using Pri.Ca.Infrastructure.Data;
using Pri.Ca.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IImageService, ImageService>();
//register automapper service
builder.Services.AddAutoMapper(typeof(Program));
//register HttpContextAccessor
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();

app.Run();

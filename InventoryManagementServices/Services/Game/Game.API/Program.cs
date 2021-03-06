using Game.Core.Services;
using Game.Core.Services.Interfaces;
using Game.Infrastructure.Entities;
using Game.Infrastructure.Repositories;
using Game.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

var siteCorsPolicy = "SiteCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: siteCorsPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:5253", "http://localhost:3000", "http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
        });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IGameRepository, GameRepository>();
builder.Services.AddScoped<IGameService, GameService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connectionString = builder.Configuration["Games"];
builder.Services.AddDbContext<GamesContext>(options => options.UseSqlServer(connectionString));

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
app.UseCors(siteCorsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();

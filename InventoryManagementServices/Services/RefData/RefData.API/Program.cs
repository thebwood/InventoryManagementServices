using Microsoft.EntityFrameworkCore;
using RefData.API.Data;
using RefData.API.Repositories;
using RefData.API.Repositories.Interfaces;
using RefData.API.Services;
using RefData.API.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var siteCorsPolicy = "SiteCorsPolicy";

// Add services to the container.

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: siteCorsPolicy,
        builder =>
        {
            builder.WithOrigins("http://localhost:5253", "http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
        });
});

builder.Services.AddControllers();
builder.Services.AddScoped<IRefDataRepository, RefDataRepository>();
builder.Services.AddScoped<IRefDataService, RefDataService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connectionString = builder.Configuration["RefData"];
builder.Services.AddDbContext<RefDataContext>(options => options.UseSqlServer(connectionString));

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

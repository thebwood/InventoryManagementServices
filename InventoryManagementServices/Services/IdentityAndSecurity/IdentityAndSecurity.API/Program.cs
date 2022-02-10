using IdentityAndSecurity.API.Data;
using IdentityAndSecurity.API.Repositories;
using IdentityAndSecurity.API.Repositories.Interfaces;
using IdentityAndSecurity.API.Services;
using IdentityAndSecurity.API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var siteCorsPolicy = "SiteCorsPolicy";

var builder = WebApplication.CreateBuilder(args);

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
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
var connectionString = builder.Configuration["IdentityAndSecurity"];
builder.Services.AddDbContext<IdentityAndSecurityContext>(options => options.UseSqlServer(connectionString));
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

app.UseCors(siteCorsPolicy);
app.UseAuthorization();

app.MapControllers();

app.Run();

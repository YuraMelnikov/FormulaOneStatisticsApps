using AutoMapper.Extensions.ExpressionMapping;
using Entities.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Repository.IService;
using Repository.Mapping;
using Repository.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v0.1",
        Title = "FormulaOneStatistics API",
        Description = "An ASP.NET Core Web API for managing FormulaOneStatistics items",
    });
});
builder.Services.AddScoped<IServiceManager, ServiceManager>();
builder.Services.AddDbContext<RepositoryContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("BloggingDatabase")));
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddAutoMapper(cfg => { cfg.AddExpressionMapping(); }, typeof(MappingProfile).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

app.Run();

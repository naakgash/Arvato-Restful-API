using Arvato.API.Filters;
using Arvato.API.Middlewares;
using Arvato.Core;
using Arvato.Core.Cores;
using Arvato.Core.DTOs;
using Arvato.Core.Services;
using Arvato.Core.UnitOfWorks;
using Arvato.Repository;
using Arvato.Repository.Repositories;
using Arvato.Repository.UnitOfWorks;
using Arvato.Service.Mapping;
using Arvato.Service.Services;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// We activate the filter we have customized to return our own custom response value in validation errors.
builder.Services.AddControllers(options => { options.Filters.Add(new ValidateFilterAttribute()); }).AddFluentValidation(x => 
    x.RegisterValidatorsFromAssemblyContaining<GenreDto>());
builder.Services.AddControllers(options => { options.Filters.Add(new ValidateFilterAttribute()); }).AddFluentValidation(x =>
    x.RegisterValidatorsFromAssemblyContaining<Movie>());

//We suppress the default filter to return our own custom response value in validation errors.
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});

builder.Services.AddControllers().AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddStackExchangeRedisCache(options => {
    options.Configuration = builder.Configuration["RedisCacheOptions:Configuration"];
});

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));

builder.Services.AddAutoMapper(typeof(MapProfile));


builder.Services.AddDbContext<IMDBContext>(x =>
{
    x.UseNpgsql(builder.Configuration.GetConnectionString("SqlConnection"), option =>
    {
        option.MigrationsAssembly(Assembly.GetAssembly(typeof(IMDBContext)).GetName().Name);
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCustomException();

app.UseAuthorization();

app.MapControllers();

app.Run();

using DataAccess;
using Business;
using Core.Exceptions.Extensions;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Business.DependencyResolvers.Autofac;
using Core.Extensions;
using Core.Utilities.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDataAccessServices(builder.Configuration);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddBusinessService();
builder.Services.AddCoreModule();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory()).ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});

var app = builder.Build();
ServiceTool.ServiceProvider = app.Services;

// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    //app.ConfigureCustomExceptionMiddleware();
}

if (app.Environment.IsProduction())
{
    app.ConfigureCustomExceptionMiddleware();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

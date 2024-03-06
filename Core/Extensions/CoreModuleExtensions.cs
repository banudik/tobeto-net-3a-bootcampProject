using Core.CrossCuttingConcerns.Logging.Serilog.Loggers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Extensions;

public static class CoreModuleExtensions
{
    public static IServiceCollection AddCoreModule(this IServiceCollection services)
    {
        services.AddTransient<MongoDbLogger>(); //AddTransiet,AddSingleton,AddScoped
        services.AddTransient<MssqlLogger>();
        services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
        return services;
    }
}

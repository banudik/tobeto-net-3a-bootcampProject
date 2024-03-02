using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Core.Extensions;

public static class ServiceRegistration
{
    public static IServiceCollection AddSubClassesOfType
        (this IServiceCollection services, Assembly assembly,
        Type type, Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (Type? item in types)
        {
            if (addWithLifeCycle == null) { services.AddScoped(item); }
            else { addWithLifeCycle(services, type); }
        }
        return services;
    }

    public static IServiceCollection RegisterAssemblyTypes
        (this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetTypes().Where(t => t.IsClass && !t.IsAbstract);
        foreach (Type? type in types)
        {
            var interfaces = type.GetInterfaces();
            foreach (var @interface in interfaces)
            {
                services.AddScoped(@interface, type);
            }
        }
        return services;
    }
}
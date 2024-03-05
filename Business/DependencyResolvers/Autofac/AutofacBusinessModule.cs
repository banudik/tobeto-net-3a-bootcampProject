using Autofac;
using Autofac.Extras.DynamicProxy;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Business.DependencyResolvers.Autofac;

public class AutofacBusinessModule:Module
{
    protected override void Load(ContainerBuilder builder)
    {


        // MongoDbLogger için kayıt
        //builder.RegisterType<MongoDbLogger>().As<LoggerServiceBase>().InstancePerDependency();
        //builder.Register(c => new ConfigurationBuilder()
        //        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        //        .Build())
        //       .As<IConfiguration>()
        //       .SingleInstance();


        var assembly = System.Reflection.Assembly.GetExecutingAssembly();

        builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
            .EnableInterfaceInterceptors(new ProxyGenerationOptions()
            {
                Selector = new AspectInterceptorSelector()
            }).SingleInstance();
    }
}

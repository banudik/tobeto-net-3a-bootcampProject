using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class MongoDbLogger:LoggerServiceBase
{
    public MongoDbLogger()
    {
        var configuration = ServiceTool.ServiceProvider.GetRequiredService<IConfiguration>();
        var logConfig = configuration.GetSection("SerilogConfigurations:MongoDbConfiguration").Get<MongoDbConfiguration>();

        Logger = new LoggerConfiguration()
               .WriteTo.MongoDB(logConfig.ConnectionString, collectionName: logConfig.Collection)
               .CreateLogger();

    }
}

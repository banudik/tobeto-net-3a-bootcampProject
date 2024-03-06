using Serilog.Sinks.MSSqlServer;
using Serilog;
using Core.CrossCuttingConcerns.Logging.Serilog.ConfigurationModels;
using Core.Utilities.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Core.Utilities.Messages;

namespace Core.CrossCuttingConcerns.Logging.Serilog.Loggers;

public class MssqlLogger:LoggerServiceBase
{
    public MssqlLogger()
    {
        var configuration = ServiceTool.ServiceProvider.GetRequiredService<IConfiguration>();
        var logConfig = configuration.GetSection("SerilogConfigurations:MssqlConfiguration").Get<MssqlConfiguration>() ?? throw new Exception(SerilogMessages.NullOptionsMessage);
        MSSqlServerSinkOptions sinkOptions = new()
        { TableName = logConfig.TableName, AutoCreateSqlTable = logConfig.AutoCreateSqlTable };

        ColumnOptions columnOptions = new();
        global::Serilog.Core.Logger serilogConfig = new LoggerConfiguration().WriteTo
            .MSSqlServer(connectionString: logConfig.ConnectionString, sinkOptions: sinkOptions, columnOptions: columnOptions).CreateLogger();
        Logger = serilogConfig;


    }
}

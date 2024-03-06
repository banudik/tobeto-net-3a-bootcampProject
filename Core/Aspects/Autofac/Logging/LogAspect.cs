using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Logging;
using Core.CrossCuttingConcerns.Logging.Serilog;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Core.Utilities.Messages;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Core.Aspects.Autofac.Logging;

public class LogAspect:MethodInterception
{
    private LoggerServiceBase _loggerServiceBase;
    private IHttpContextAccessor _httpContextAccessor;

    public LogAspect(Type loggerService)
    {
        if (loggerService.BaseType != typeof(LoggerServiceBase))
        {
            throw new ArgumentException(AspectMessages.WrongLoggerType);
        }

        _loggerServiceBase = (LoggerServiceBase)ServiceTool.ServiceProvider.GetRequiredService(loggerService);
        _httpContextAccessor = ServiceTool.ServiceProvider.GetRequiredService<IHttpContextAccessor>();

    }

    protected override void OnBefore(IInvocation invocation)
    {
        var logParameters = new List<LogParameter>();
        for (int i = 0; i < invocation.Arguments.Length; i++)
        {
            logParameters.Add(new LogParameter
            {
                Name = invocation.GetConcreteMethod().GetParameters()[i].Name,
                Value = invocation.Arguments[i],
                Type = invocation.Arguments[i].GetType().Name
            });
        }
        var logDetail = new LogDetail
        {
            MethodName = invocation.Method.Name,
            LogParameters = logParameters,
            User = _httpContextAccessor.HttpContext == null || _httpContextAccessor.HttpContext.User.Identity.Name == null ? "?"
            : _httpContextAccessor.HttpContext.User.Identity.Name
        };
        _loggerServiceBase.Info(JsonConvert.SerializeObject(logDetail));
    }
}

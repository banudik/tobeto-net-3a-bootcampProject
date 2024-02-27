using Core.Exceptions.Handlers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Exceptions;

public class ExceptionMiddleware
{
    private readonly HttpExceptionHandler _handler;
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _handler = new HttpExceptionHandler();
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(context.Response, exception);
        }
    }

    private Task HandleExceptionAsync(HttpResponse response, Exception exception)
    {
        response.ContentType = "application/json";
        _handler.Response = response;
        return _handler.HandleExceptionAsync(exception);
    }
}

namespace UnitConversion.WebService.Middleware;

using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            await HandleValidationExceptionAsync(context, ex);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private static Task HandleValidationExceptionAsync(HttpContext context, ValidationException ex)
    {
        var response = new
        {
            Message = "Validation failed.",
            Errors = ex.Errors.Select(err => new
            {
                Property = err.PropertyName,
                Error = err.ErrorMessage
            })
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }

    private static Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        var response = new
        {
            Message = "An unexpected error occurred.",
            Details = ex.Message
        };

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
        return context.Response.WriteAsync(JsonSerializer.Serialize(response));
    }
}

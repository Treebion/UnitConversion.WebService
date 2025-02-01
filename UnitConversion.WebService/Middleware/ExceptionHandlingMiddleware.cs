namespace UnitConversion.WebService.Middleware;

using FluentValidation;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

/// <summary>
/// Middleware for handling exceptions in the application.
/// </summary>
public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
    /// </summary>
    /// <param name="next">The next middleware in the pipeline.</param>
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    /// <summary>
    /// Invokes the middleware to handle the HTTP context.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <returns>A task that represents the completion of request processing.</returns>
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

    /// <summary>
    /// Handles validation exceptions and writes a response to the context.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="ex">The validation exception.</param>
    /// <returns>A task that represents the completion of response writing.</returns>
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

    /// <summary>
    /// Handles general exceptions and writes a response to the context.
    /// </summary>
    /// <param name="context">The HTTP context.</param>
    /// <param name="ex">The exception.</param>
    /// <returns>A task that represents the completion of response writing.</returns>
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

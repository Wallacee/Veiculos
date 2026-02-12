using System.Text.Json;
using FluentValidation;
namespace Veiculos.WebApi.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (ValidationException ex)
        {
            context.Response.StatusCode = 400;
            context.Response.ContentType = "application/json";

            var errors = ex.Errors.Select(e => e.ErrorMessage);

            await context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                errors
            }));
        }
        catch (UnauthorizedAccessException)
        {
            context.Response.StatusCode = 401;
        }
        catch (Exception)
        {
            context.Response.StatusCode = 500;
        }
    }
}
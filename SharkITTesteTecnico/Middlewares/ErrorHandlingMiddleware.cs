using Microsoft.AspNetCore.Mvc;
using SharkITTesteTecnico.Application.Exceptions;
using System.Net;
using System.Text.Json;

namespace SharkITTesteTecnico.Api.Middleware;

public class ExceptionHandlingMiddleware(RequestDelegate next)
{
    private readonly RequestDelegate _next = next;

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleException(context, ex);
        }
    }

    private async Task HandleException(HttpContext context, Exception exception)
    {
        ProblemDetails problem = new()
        {
            Type = "https://tools.ietf.org/html/rfc7231",
            Instance = context.Request.Path,
            Detail = exception?.Message,
            Title = "Something went wrong."
        };

        switch (exception)
        {
            case BadRequestException badRequestException:
                problem.Status = (int)HttpStatusCode.BadRequest;

                foreach (var validationResult in badRequestException.Errors)
                {
                    problem.Extensions.Add(validationResult.Key, validationResult.Value);
                }
                break;
            case NotFoundException notFoundException:
                problem.Status = (int) HttpStatusCode.NotFound;
                break;
            default:
                problem.Status = (int) HttpStatusCode.InternalServerError;
                break;
        }

        var result = new ObjectResult(problem)
        {
            StatusCode = problem.Status
        };

        var response = JsonSerializer.Serialize(result.Value);

        context.Response.ContentType = "application/problem+json";

        await context.Response.WriteAsync(response);
    }

}

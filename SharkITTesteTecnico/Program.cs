using FastEndpoints;
using FastEndpoints.Swagger;
using SharkITTesteTecnico.Api.Middleware;
using SharkITTesteTecnico.Application.Extensions;
using SharkITTesteTecnico.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSecretManager()
    .AddMediator()
    .AddAuthorization()
    .AddDefaultDatabase()
    .AddDefaultDatabaseRepositories();

if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDefaultDatabaseSeeders();
}

builder.Services
    .AddMediator()
    .AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDefaultDatabaseSeeders();
}

app.UseFastEndpoints(configuration => {
    configuration.Errors.UseProblemDetails();
    configuration.Endpoints.Configurator = x =>
    {
        x.DontThrowIfValidationFails();
    };
});

app.UseSwaggerGen();

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();

using FastEndpoints;
using SharkITTesteTecnico.Api.Middleware;
using SharkITTesteTecnico.Application.Extensions;
using SharkITTesteTecnico.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
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
    .AddFastEndpoints();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDefaultDatabaseSeeders();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFastEndpoints(configuration => configuration.Errors.UseProblemDetails());

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();

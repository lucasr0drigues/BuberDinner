
using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Filters;
//using BuberDinner.Api.Middleware;
using BuberDinner.Application;
using Microsoft.AspNetCore.Mvc.Infrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddAplication()
        .AddInfrastructure(builder.Configuration)
        //.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
        .AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>()
        .AddControllers();
}

var app = builder.Build();
{
    //app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseExceptionHandler("/error");
    app.UseHttpsRedirection();
    app.MapControllers();
    app.Run();
}


using BuberDinner.Api.Filters;
//using BuberDinner.Api.Middleware;
using BuberDinner.Application;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddAplication()
        .AddInfrastructure(builder.Configuration)
        //.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
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

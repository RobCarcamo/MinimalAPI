using _03MinimalAPI.Contracts.Data;
using _03MinimalAPI.Controllers;
using _03MinimalAPI.Filters;
using _03MinimalAPI.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;

namespace _03MinimalAPI.Endpoints;

public class WineEndpoint : IEndpoint
{
    public IEndpointRouteBuilder AddRoutes(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/wine", WineController.GetAll)
            .Produces<IEnumerable<WineDto>>(200);
        //endpoints.MapGet("/api/wine/mapper", WineController.GetAll2);
        //endpoints.MapGet("/api/wine/{id:int}", WineController.GetById);
        //endpoints.MapPost("/api/wine", WineController.Create);
        //endpoints.MapPut("/api/wine/{id:int}", WineController.Update)
        //    .AddEndpointFilter<ValidatorFilter<WineUpdateDTO>>()
        //    .Produces(StatusCodes.Status204NoContent)
        //    .Produces<IEnumerable<string>>(StatusCodes.Status400BadRequest);
        //endpoints.MapDelete("/api/wine/{id:int}", WineController.Delete)
        //    .Produces(204);


        return endpoints;
    }
    public IServiceCollection RegisterModule(IServiceCollection builder)
    {
        builder.AddSingleton<IWineService, WineService>();
        return builder;
    }
}

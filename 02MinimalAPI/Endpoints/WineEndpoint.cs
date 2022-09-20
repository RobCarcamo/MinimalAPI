using _02MinimalAPI.Controllers;
using _02MinimalAPI.DTO;
using _02MinimalAPI.Filters;
using _02MinimalAPI.Models;
using _02MinimalAPI.Repository;

namespace _02MinimalAPI.Endpoints;

public class WineEndpoint : IEndpoint
{
    public IEndpointRouteBuilder AddRoutes(IEndpointRouteBuilder endpoints)
    {
        endpoints.MapGet("/api/wine", WineController.GetAll)
            .Produces<IEnumerable<WineDTO>>(200);
        endpoints.MapGet("/api/wine/mapper", WineController.GetAll2);
        endpoints.MapGet("/api/wine/{id:int}", WineController.GetById);
        endpoints.MapPost("/api/wine", WineController.Create);
        endpoints.MapPut("/api/wine/{id:int}", WineController.Update)
            .AddEndpointFilter<ValidatorFilter<WineUpdateDTO>>()
            .Produces(StatusCodes.Status204NoContent)
            .Produces<IEnumerable<string>>(StatusCodes.Status400BadRequest);
        endpoints.MapDelete("/api/wine/{id:int}", WineController.Delete)
            .Produces(204);


        return endpoints;
    }

    public IServiceCollection RegisterModule(IServiceCollection builder)
    {
        throw new NotImplementedException();
    }
}

using _03MinimalAPI.Endpoints;

namespace _03MinimalAPI.Startup;

public static class IEndpointRouteBuilderExtensions
{
    /// <summary>
    /// Map all routes that implement the IEndpoint
    /// </summary>
    /// <param name="builder"></param>
    public static void MapEndpoints(this WebApplication builder)
    {
        var scope = builder.Services.CreateScope();

        var endpoints = scope.ServiceProvider.GetServices<IEndpoint>();

        foreach (var endpoint in endpoints)
        {
            endpoint.AddRoutes(builder);
        }
    }
}

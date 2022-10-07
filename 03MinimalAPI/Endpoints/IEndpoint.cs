﻿namespace _03MinimalAPI.Endpoints
{
    public interface IEndpoint
    {
        IEndpointRouteBuilder AddRoutes(IEndpointRouteBuilder endpoints);
        IServiceCollection RegisterModule(IServiceCollection builder);
    }
}

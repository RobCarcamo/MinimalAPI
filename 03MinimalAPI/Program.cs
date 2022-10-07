using _03MinimalAPI.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.ConfigureSwagger();

app.UseHttpsRedirection();

app.MapEndpoints();

app.Run();

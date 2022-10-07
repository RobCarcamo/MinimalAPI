using _01MinimalAPI;
using _01MinimalAPI.Endpoints;
using Microsoft.Extensions.Primitives;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return Results.Ok(forecast);
})
.WithName("GetWeatherForecast");

#region Wines CRUD
app.MapGet("/api/wine", () => WineStore.wines.ToList());
app.MapGet("/api/wine/{id:int}", (int id) => WineStore.wines.SingleOrDefault(x => x.id == id));
app.MapGet("/api/wine2", () => Results.Ok(WineStore.wines.ToList()));

app.MapPost("/api/wine", (WineModel wine) =>
{
    WineStore.wines.Add(wine);

    return Results.Created($"/api/wine/{wine.id}", wine);
});

app.MapPut("/api/wine/{id:int}", (int id, WineModel wine) =>
{
    var wineStore = WineStore.wines.SingleOrDefault(x => x.id == id);
    wineStore.name = wine.name;
    wine.isChilean = wine.isChilean;
    wine.isActive = wine.isActive;

    return Results.Ok(wineStore);
});

//app.MapDelete("api/wine/{id:int}", (int id) =>
//{
//    //soft
//    var wineStore = WineStore.wines.SingleOrDefault(x => x.id == id);
//    wineStore.isActive = false;

//    //hard
//    //WineStore.wines.Remove(WineStore.wines.SingleOrDefault(x => x.id == id));

//    Results.NoContent();
//});

//app.MapWineEndpoints();
#endregion region

#region Otras formas de llamado



app.MapDelete("api/wine/{id:int}", WineDelete);
app.MapDelete("api/wine/{id:int}", (int id) => WineDelete(id));

static IResult WineDelete(int id)
{
    //soft
    var wineStore = WineStore.wines.SingleOrDefault(x => x.id == id);
    wineStore.isActive = false;

    //hard
    //WineStore.wines.Remove(WineStore.wines.SingleOrDefault(x => x.id == id));

    return Results.NoContent();
}

#endregion

#region Routes

app.MapGet("/api/route/{id:int}", (int id) => $"ruta get con parametro int:{id}");
app.MapGet("/api/route/{text}", (string text) => $"ruta get con parametro string:{text}");
//otros
// Bind query string values to a primitive type array.
// GET  /tags?q=1&q=2&q=3
app.MapGet("/api/tags", (int[] q) => $"tag1: {q[0]} , tag2: {q[1]}, tag3: {q[2]}");

// Bind to a string array.
// GET /tags2?names=john&names=jack&names=jane
app.MapGet("/api/tags2", (string[] names) =>
            $"tag1: {names[0]} , tag2: {names[1]}, tag3: {names[2]}");

// Bind to StringValues.
// GET /tags3?names=john&names=jack&names=jane
app.MapGet("/api/tags3", (StringValues names) =>
            $"tag1: {names[0]} , tag2: {names[1]}, tag3: {names[2]}");


#endregion



app.Run();
//app.Run("http://localhost:7500");

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}

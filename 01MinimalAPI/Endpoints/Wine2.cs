namespace _01MinimalAPI.Endpoints
{
    public static class Wine2 
    {

        public static WebApplication MapWineEndpoints(this WebApplication app)
        {
            app.MapDelete("api/wine/{id:int}", WineDelete);
            //app.MapDelete("api/wine/{id:int}", (int id) => WineDelete(id));

            return app;
        }
        static IResult WineDelete(int id)
        {
            //soft
            var wineStore = WineStore.wines.SingleOrDefault(x => x.id == id);
            wineStore.isActive = false;

            //hard
            //WineStore.wines.Remove(WineStore.wines.SingleOrDefault(x => x.id == id));

            return Results.NoContent();
        }
    }
}

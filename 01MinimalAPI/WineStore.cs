namespace _01MinimalAPI
{
    public static class WineStore
    {
        public static List<WineModel> wines = new List<WineModel>
        {
            new WineModel { id = 1, name ="Gato", alcohol=11.5, isChilean=true, isActive=true },
            new WineModel { id = 2, name ="Casillero del diablo", alcohol=13.5, isChilean=true, isActive=true },
            new WineModel { id = 3, name ="Misiones de Rengo 1990", alcohol=14 , isChilean=true, isActive=false },
            new WineModel { id = 4, name ="120 ARG", alcohol=14.5, isChilean=false, isActive=true },
        };
    }
}

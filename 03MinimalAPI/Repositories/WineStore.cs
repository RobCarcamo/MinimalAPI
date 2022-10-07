using _03MinimalAPI.Contracts.Data;

namespace _03MinimalAPI.Repositories;

public static class WineStore
{
    public static List<WineDto> wines = new List<WineDto>
    {
        new WineDto { id = 1, name ="Gato", alcohol=11.5, isChilean=true, isActive=true, createDate=DateTime.Today.AddDays(-new Random().Next(100)) },
        new WineDto { id = 2, name ="Casillero del diablo", alcohol=13.5, isChilean=true, createDate=DateTime.Today.AddDays(-new Random().Next(100)) },
        new WineDto { id = 3, name ="Misiones de Rengo 1990", alcohol=14 , isChilean=true, createDate=DateTime.Today.AddDays(-new Random().Next(100)) },
        new WineDto { id = 4, name ="120 ARG", alcohol=14.5, isChilean=false, isActive=true, createDate=DateTime.Today.AddDays(-new Random().Next(100)) },
    };
}

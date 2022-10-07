using _02MinimalAPI.DTO;
using _02MinimalAPI.Models;
using _02MinimalAPI.Repository;
using _02MinimalAPI.Services;
using AutoMapper;
using FluentValidation;
using System.Reflection;

namespace _02MinimalAPI.Controllers;

public static class WineController
{
    // Inicial
    public static IResult GetAll()
    {
        return Results.Ok(WineStore.wines);
    }
    public static IResult Test(IWineService wineService)
    {
        return Results.Ok(wineService.Test());
    }

    //DI: Mapper
    //use DTO
    public static IResult GetAll2(IMapper mapper)
    {
        var wines = mapper.Map<WineDTO>(WineStore.wines);
        return Results.Ok(wines);
    }

    //custom response
    public static IResult GetById(int id, IMapper mapper)
    {
        var wine = WineStore.wines.SingleOrDefault(x => x.id == id);

        if(wine == null)
        {
            Results.NotFound();
        }
        
        return Results.Ok(mapper.Map<WineDTO>(wine));
    }

    //+Validaciones
    public static async Task<IResult> Create (WineCreateDTO wine, IMapper mapper, IValidator<WineCreateDTO> validator) {

        var validationResult = await validator.ValidateAsync(wine);
        if(!validationResult.IsValid)
        {
            return Results.BadRequest(validationResult.Errors);
        }


        var wineModel = mapper.Map<WineModel>(wine);
        wineModel.id = WineStore.wines.Max(x => x.id) +1;
        wineModel.createDate = DateTime.Now;

        WineStore.wines.Add(wineModel);

        return Results.Created($"/api/wine/{wineModel.id}", wineModel);
    }

    //+Filtro
    public static async Task<IResult> Update(int id, WineUpdateDTO wine, IMapper mapper)
    {

        //var validationResult = await validator.ValidateAsync(wine);
        //if (!validationResult.IsValid)
        //{
        //    var errors = validationResult.Errors.Select(x => new { errors = x.ErrorMessage });
        //    return Results.BadRequest(errors);
        //}

        var wineStore = WineStore.wines.SingleOrDefault(x => x.id == id);
        wineStore.name = wine.name;
        wine.isChilean = wine.isChilean;
        wine.isActive = wine.isActive;

        return Results.NoContent();
    }

    public static async Task<IResult> Delete(int id)
    {
        var wineStore = WineStore.wines.SingleOrDefault(x => x.id == id);

        if(wineStore is null)
        {
            return Results.NoContent();
        }


        //soft
        wineStore.isActive = false;

        //hard
        //WineStore.wines.Remove(WineStore.wines.SingleOrDefault(x => x.id == id));

        return Results.NoContent();
    }
}

using _03MinimalAPI.Contracts.Data;
using _03MinimalAPI.Services;
using AutoMapper;
using FluentValidation;
using System.Reflection;
using _03MinimalAPI.Contracts.Responses;
using _03MinimalAPI.Domain;

namespace _03MinimalAPI.Controllers;

public class WineController
{
    public static async Task<IResult> GetAll(IMapper mapper, IWineService wineService)
    {
        var wines = await wineService.GetAllAsync(1, 1);

        var response = new DataResponse<List<Wine>>()
        {
            Success = true,
            Data = wines.ToList()
        };

        return Results.Ok(response);
    }

    ////custom response
    //public IResult GetById(int id)
    //{
    //    var wine = WineStore.wines.SingleOrDefault(x => x.id == id);

    //    if(wine == null)
    //    {
    //        Results.NotFound();
    //    }

    //    return Results.Ok(mapper.Map<WineDTO>(wine));
    //}

    ////+Validaciones
    //public async Task<IResult> Create (WineCreateDTO wine, IValidator<WineCreateDTO> validator) {

    //    var validationResult = await validator.ValidateAsync(wine);
    //    if(!validationResult.IsValid)
    //    {
    //        return Results.BadRequest(validationResult.Errors);
    //    }


    //    var wineModel = mapper.Map<WineModel>(wine);
    //    wineModel.id = WineStore.wines.Max(x => x.id) +1;
    //    wineModel.createDate = DateTime.Now;

    //    WineStore.wines.Add(wineModel);

    //    return Results.Created($"/api/wine/{wineModel.id}", wineModel);
    //}

    ////+Filtro
    //public async Task<IResult> Update(int id, WineUpdateDTO wine, IMapper mapper)
    //{

    //    //var validationResult = await validator.ValidateAsync(wine);
    //    //if (!validationResult.IsValid)
    //    //{
    //    //    var errors = validationResult.Errors.Select(x => new { errors = x.ErrorMessage });
    //    //    return Results.BadRequest(errors);
    //    //}

    //    var wineStore = WineStore.wines.SingleOrDefault(x => x.id == id);
    //    wineStore.name = wine.name;
    //    wine.isChilean = wine.isChilean;
    //    wine.isActive = wine.isActive;

    //    return Results.NoContent();
    //}

    //public async Task<IResult> Delete(int id)
    //{
    //    var wineStore = WineStore.wines.SingleOrDefault(x => x.id == id);

    //    if(wineStore is null)
    //    {
    //        return Results.NoContent();
    //    }


    //    //soft
    //    wineStore.isActive = false;

    //    //hard
    //    //WineStore.wines.Remove(WineStore.wines.SingleOrDefault(x => x.id == id));

    //    return Results.NoContent();
    //}
}

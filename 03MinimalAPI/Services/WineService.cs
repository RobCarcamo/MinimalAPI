using _03MinimalAPI.Contracts.Data;
using _03MinimalAPI.Domain;
using _03MinimalAPI.Repositories;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;

namespace _03MinimalAPI.Services;

public class WineService : IWineService
{
    private readonly IWineRepository wineRepository;
    private readonly IMapper mapper;

    public WineService(IWineRepository wineRepository, IMapper mapper)
    {
        this.wineRepository = wineRepository;
        this.mapper = mapper;
    }

    public Task<bool> CreateAsync(Wine wine)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Wine>> GetAllAsync(int pageIndex, int pageSize)
    {
        return await wineRepository.GetAllAsync(pageIndex, pageSize);
    }

    public Task<Wine> GetAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(Wine wine)
    {
        throw new NotImplementedException();
    }

    //public async Task<bool> CreateAsync(Wine wine)
    //{
    //    var exists = await wineRepository.GetAsync(wine.id);

    //    if(exists is not null)
    //    {
    //        var msg = $"El vino con ID: {wine.id} ya existe";
    //        throw new ValidationException(msg, new[]
    //        {
    //            new ValidationFailure(nameof(Wine), msg)
    //        });
    //    }

    //    var wineDto = mapper.Map<WineDto>(wine);
    //    return await wineRepository.CreateAsync(wineDto);
    //}

    //public async Task<bool> DeleteAsync(int id)
    //{
    //    return await wineRepository.DeleteAsync(id);
    //}

    //public async Task<IEnumerable<Wine>> GetAllAsync(int pageIndex, int pageSize)
    //{
    //    var winesDto = await wineRepository.GetAllAsync(pageIndex, pageSize);

    //    return await Task.FromResult(mapper.Map<IEnumerable<Wine>>(winesDto));
    //}

    //public async Task<Wine> GetAsync(int id)
    //{
    //    var wineDto = await wineRepository.GetAsync(id);

    //    return await Task.FromResult(mapper.Map<Wine>(wineDto));
    //}

    //public async Task<bool> UpdateAsync(Wine wine)
    //{
    //    var wineDto = mapper.Map<WineDto>(wine);
    //    return await wineRepository.UpdateAsync(wineDto);
    //}

}

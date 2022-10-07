using _03MinimalAPI.Contracts.Data;
using _03MinimalAPI.Domain;
using AutoMapper;

namespace _03MinimalAPI.Mappers;

public class WineProfile: Profile
{
    public WineProfile()
    {
        CreateMap<WineDto, Wine>().ReverseMap();
    }
}

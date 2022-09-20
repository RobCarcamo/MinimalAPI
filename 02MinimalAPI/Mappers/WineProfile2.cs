using AutoMapper;

namespace _02MinimalAPI.Mappers;

public class WineProfile2: Profile
{
    public WineProfile2()
    {
        CreateMap<DTO.WineUpdateDTO, Models.WineModel>();
    }
}

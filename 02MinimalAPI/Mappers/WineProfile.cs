using AutoMapper;

namespace _02MinimalAPI.Mappers;

public class WineProfile: Profile
{
    public WineProfile()
    {
        CreateMap<Models.WineModel, DTO.WineDTO>().ReverseMap(); 
        CreateMap<DTO.WineCreateDTO, Models.WineModel>();
    }
}

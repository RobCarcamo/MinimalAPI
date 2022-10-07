using AutoMapper;

namespace _02MinimalAPI.Services;

public class WineService : IWineService
{
    private readonly IMapper mapper;

    public WineService(IMapper mapper)
    {
        this.mapper = mapper;
    }
    public async Task<string> Test()
    {
        return await Task.FromResult("Test");
    }
}

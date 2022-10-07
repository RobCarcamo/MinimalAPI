using _03MinimalAPI.Contracts.Data;
using _03MinimalAPI.Services;
using AutoMapper;

namespace _03MinimalAPI.Repositories
{
    public class WineRepository : IWineRepository
    {
        private readonly IMapper mapper;

        public WineRepository(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public Task<bool> CreateAsync(WineDto wine)
        {
            var wineDto = mapper.Map<WineDto>(wine);

            WineStore.wines.Add(wineDto);

            return Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var wineStore = WineStore.wines.SingleOrDefault(x => x.id == id);

            if (wineStore is null)
            {
                return await Task.FromResult(true);
            }

            //soft
            //wineStore.isActive = false;

            //hard
            WineStore.wines.Remove(wineStore);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<WineDto>> GetAllAsync(int pageIndex, int pageSize)
        {
            return await Task.FromResult(WineStore.wines.Where(wine => wine.isActive));
        }

        public Task<WineDto?> GetAsync(int id)
        {
            var wine = WineStore.wines.SingleOrDefault(x => x.id == id);

            return Task.FromResult(wine);
        }

        public async Task<bool> UpdateAsync(WineDto wine)
        {
            var wineStore = WineStore.wines.SingleOrDefault(x => x.id == wine.id);
            wineStore.name = wine.name;
            wine.isChilean = wine.isChilean;
            wine.isActive = wine.isActive;

            return await Task.FromResult(true);
        }
    }
}

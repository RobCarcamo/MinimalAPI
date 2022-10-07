using _03MinimalAPI.Contracts.Data;

namespace _03MinimalAPI.Repositories;

public interface IWineRepository
{
    Task<bool> CreateAsync(WineDto wine);

    Task<WineDto?> GetAsync(int id);

    Task<IEnumerable<WineDto>> GetAllAsync(int pageIndex, int pageSize);

    Task<bool> UpdateAsync(WineDto wine);

    Task<bool> DeleteAsync(int id);
}

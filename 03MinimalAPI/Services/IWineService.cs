using _03MinimalAPI.Domain;

namespace _03MinimalAPI.Services;

public interface IWineService
{
    Task<bool> CreateAsync(Wine wine);

    Task<Wine> GetAsync(int id);

    Task<IEnumerable<Wine>> GetAllAsync(int pageIndex, int pageSize);

    Task<bool> UpdateAsync(Wine wine);

    Task<bool> DeleteAsync(int id);
}

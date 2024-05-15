using NZWalks.DTOs.Region;
using NZWalks.Models;

namespace NZWalks.Interfaces
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetAsync(Guid id);
        Task<Region?> CreateAsync(CreateRegionDTO model);
        Task<Region?> UpdateAsync(UpdateRegionDTO model, Guid id);
        Task<Region?> DeleteAsync(Guid id);
 
    }
}

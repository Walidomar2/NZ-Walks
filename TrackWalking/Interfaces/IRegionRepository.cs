using NZWalks.DTOs.Region;
using NZWalks.Models;

namespace NZWalks.Interfaces
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetAsync(Guid id);
        Task<Region?> CreateAsync(Region model);
        Task<Region?> UpdateAsync(Region model, Guid id);
        Task<Region?> DeleteAsync(Guid id);
 
    }
}

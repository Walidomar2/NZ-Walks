using NZWalks.DTOs.Region;
using NZWalks.Models;

namespace NZWalks.Interfaces
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync(string? filterOn = null, string? filterQuery = null
                                        , int pageNumber = 1, int pageSize = 1000);
        Task<Region?> GetAsync(Guid id);
        Task<Region?> CreateAsync(Region model);
        Task<Region?> UpdateAsync(Region model, Guid id);
        Task<Region?> DeleteAsync(Guid id);
 
    }
}

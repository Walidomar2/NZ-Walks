using NZWalks.Models;

namespace NZWalks.Interfaces
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync();
        Task<Walk?> CreateAsync(Walk model); 
        Task<Walk?> GetAsync(Guid id);
        Task<Walk?> UpdateAsync(Walk model);

    }
}

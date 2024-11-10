using Microsoft.AspNetCore.Mvc;
using NZWalks.Models;

namespace NZWalks.Interfaces
{
    public interface IWalkRepository
    {
        Task<List<Walk>> GetAllAsync(string? filterOn = null,string? filterQuery = null,
                string? sortBy = null, bool? isAscending = true, int pageNumber = 1, int pageSize = 1000);

        Task<Walk?> CreateAsync(Walk model); 
        Task<Walk?> GetAsync(Guid id);
        Task<Walk?> UpdateAsync(Walk model, Guid id);
        Task<Walk?> DeleteAsync(Guid id);
    }
}

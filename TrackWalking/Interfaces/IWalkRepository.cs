using NZWalks.Models;

namespace NZWalks.Interfaces
{
    public interface IWalkRepository
    {
        Task<Walk?> CreateAsync(Walk model); 
    }
}

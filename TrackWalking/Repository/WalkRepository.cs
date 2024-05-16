using NZWalks.Data;
using NZWalks.Interfaces;
using NZWalks.Models;

namespace NZWalks.Repository
{
    public class WalkRepository : IWalkRepository
    {
        private readonly ApplicationDbContext _context;
        public WalkRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Walk?> CreateAsync(Walk model)
        {
            if (model == null)
                return null;

            await _context.Walks.AddAsync(model);
            await _context.SaveChangesAsync();  
            return model;
        }
    }
}

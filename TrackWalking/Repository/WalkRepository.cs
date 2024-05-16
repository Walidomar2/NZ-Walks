using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Walk>> GetAllAsync()
        {
            return await _context.Walks.Include(x => x.Region).Include(x => x.Difficulty).ToListAsync();
        }

        public async Task<Walk?> GetAsync(Guid id)
        {
            return await _context.Walks.Include(x => x.Region)
                .Include(x => x.Difficulty).FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<Walk?> UpdateAsync(Walk model)
        {
            throw new NotImplementedException();
        }
    }
}

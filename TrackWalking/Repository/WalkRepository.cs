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

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walk = await _context.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null) return null;

            _context.Walks.Remove(walk);
            await _context.SaveChangesAsync();
            return walk;    
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

        public async Task<Walk?> UpdateAsync(Walk model, Guid id)
        {
            var walk = await _context.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walk == null) return null;

            walk.Name = model.Name; 
            walk.LengthInKm = model.LengthInKm;
            walk.Description = model.Description;  
            walk.WalkImageUrl = model.WalkImageUrl;
            walk.DifficultyId = model.DifficultyId;
            walk.RegionId = model.RegionId; 

            await _context.SaveChangesAsync();
            return walk;
        }
    }
}

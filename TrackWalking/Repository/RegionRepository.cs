using Microsoft.EntityFrameworkCore;
using NZWalks.Data;
using NZWalks.DTOs.Region;
using NZWalks.Interfaces;
using NZWalks.Mappers;
using NZWalks.Models;

namespace NZWalks.Repository
{
    public class RegionRepository : IRegionRepository
    {

        private readonly ApplicationDbContext _context;
        public RegionRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Region?> CreateAsync(CreateRegionDTO model)
        {
            if (model == null)
                return null;
            var newRegion = model.FromCreateRegionToRegion();
            await _context.Regions.AddAsync(newRegion);
            await _context.SaveChangesAsync();  

            return newRegion;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }
            _context.Regions.Remove(region);
            await _context.SaveChangesAsync();  
            return region;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await _context.Regions.ToListAsync();
        }

        public async Task<Region?> GetAsync(Guid id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }
            return region;
        }

        public async Task<Region?> UpdateAsync(UpdateRegionDTO model, Guid id)
        {
            var region = await _context.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (region == null)
            {
                return null;
            }

            region.Code = model.Code;
            region.Name = model.Name;
            region.RegionImageUrl = model.RegionImageUrl;

            await _context.SaveChangesAsync();
            return region;
        }
    }
}

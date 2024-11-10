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


        public async Task<Region?> CreateAsync(Region model)
        {
            if (model == null)
                return null;
         
            await _context.Regions.AddAsync(model);
            await _context.SaveChangesAsync();  

            return model;
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

        public async Task<List<Region>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
                                        int pageNumber = 1, int pageSize = 1000)
        {
            var regions =  _context.Regions.AsQueryable();

            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if(filterOn.Equals("Name",StringComparison.OrdinalIgnoreCase))
                {
                    regions = regions.Where(x => x.Name.Contains(filterQuery));
                }
            }

            return await regions.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
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

        public async Task<Region?> UpdateAsync(Region model, Guid id)
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

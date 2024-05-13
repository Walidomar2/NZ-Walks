using Microsoft.EntityFrameworkCore;
using NZWalks.Models;

namespace NZWalks.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbOptions) : base(dbOptions)
        {
        }

        public DbSet<Walk> Walks { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Difficulty> Difficulties { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Region>().HasData(LoadRegions());
        }

        private List<Region> LoadRegions()
        {
            return new List<Region>
            {
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = $"Auckland Region",
                    Code = "AKL",
                    RegionImageUrl = "https://image.pexels.com/test1"
                },
                new Region
                {
                    Id = Guid.NewGuid(),
                    Name = "Wellington Region",
                    Code = "WLG",
                    RegionImageUrl = "https://image.pexels.com/test1"
                }
            };
        }

    }
}

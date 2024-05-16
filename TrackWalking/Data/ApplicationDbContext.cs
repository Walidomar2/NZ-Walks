using Microsoft.EntityFrameworkCore;
using NZWalks.Models;
using static System.Net.WebRequestMethods;

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
            modelBuilder.Entity<Difficulty>().HasData(LoadDifficulties());

        }

        private List<Region> LoadRegions()
        {
            return new List<Region>
            {
                new Region
                {
                    Id = Guid.Parse("99b4a4ae-5d0e-48e8-8f32-5cb071a8e427"),
                    Name = $"Auckland Region",
                    Code = "AKL",
                    RegionImageUrl = "https://image.pexels.com/test1"
                },
                new Region
                {
                    Id = Guid.Parse("015facbf-fde0-47b5-a977-3e62d1d96dad"),
                    Name = "Wellington Region",
                    Code = "WLG",
                    RegionImageUrl = "https://image.pexels.com/test2"
                },
                new Region
                {
                    Id = Guid.Parse("f077a22e-4248-4bf6-b564-c7cf4e250263"),
                    Name = "Southland",
                    Code = "STL",
                    RegionImageUrl = "https://image.pexels.com/test3"
                },
                 new Region
                 {
                    Id = Guid.Parse("906cb139-415a-4bbb-a174-1a1faf9fb1f6"),
                    Name = "Nelson",
                    Code = "NSN",
                    RegionImageUrl = "https://image.pexels.com/test4"
                 },
                 new Region
                 {
                    Id = Guid.Parse("14ceba71-4b51-4777-9b17-46602cf66153"),
                    Name = "Bay Of Plenty",
                    Code = "BOP",
                    RegionImageUrl = "https://image.pexels.com/test5"
                 }
            };
        }

        private List<Difficulty> LoadDifficulties()
        {
            return new List<Difficulty>
            {
               new Difficulty
               {
                   Id = Guid.Parse("08368a4b-28d3-4af7-aaf0-e09fc0d3d62a"),
                   Name = "Easy"
               },
               new Difficulty
               {
                   Id = Guid.Parse("12ea3722-e12f-4d37-8b1e-a3ad6a111575"),
                   Name = "Medium"
               },
               new Difficulty
               {
                   Id = Guid.Parse("644c970c-5fc7-4934-a397-30c1efb92274"),
                   Name = "Hard"
               }
            };
        }



    }
}

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

    }
}

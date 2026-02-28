using Microsoft.EntityFrameworkCore;

namespace PawMatch.Api.Data
{
    public class PawMatchContext : DbContext
    {
        public PawMatchContext(DbContextOptions<PawMatchContext> options) 
            : base(options)
        {
        }

        // TODO: add DbSet properties for your entities
        public DbSet<Dog> Dogs { get; set; } = null!;
        public DbSet<Owner> Owners { get; set; } = null!;
    }
}

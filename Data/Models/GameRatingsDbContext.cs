using System.Data.Entity;

namespace Data.Models
{
    public class GameRatingsDbContext : DbContext
    {
        public virtual DbSet<Developers> Developer { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Genres> Genre { get; set; }
        public virtual DbSet<Publishers> Publisher { get; set; }
        public virtual DbSet<Ratings> Rating { get; set; }
        public virtual DbSet<Platforms> Platform { get; set; }
        public virtual DbSet<Links> Links { get; set; }

        public GameRatingsDbContext() : base(@"Data Source=.\SQLEXPRESS;Initial Catalog=GameRatings;Integrated Security=True")
        {
        }
    }
}
using Data.Models;
using System.Data.Entity;

namespace Data.Interfaces
{
    internal interface IGameRatingsContext
    {
        DbSet<Games> Games { get; set; }
        DbSet<Developers> Developer { get; set; }
        DbSet<Genres> Genre { get; set; }
        DbSet<Links> Links { get; set; }
        DbSet<Platforms> Platform { get; set; }
        DbSet<Publishers> Publisher { get; set; }
        DbSet<Ratings> Rating { get; set; }
    }
}
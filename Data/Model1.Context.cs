﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Der Code wurde von einer Vorlage generiert.
//
//     Manuelle Änderungen an dieser Datei führen möglicherweise zu unerwartetem Verhalten der Anwendung.
//     Manuelle Änderungen an dieser Datei werden überschrieben, wenn der Code neu generiert wird.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GameRatingsEntities : DbContext
    {
        public GameRatingsEntities()
            : base("name=GameRatingsEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Developer> Developer { get; set; }
        public virtual DbSet<Games> Games { get; set; }
        public virtual DbSet<Genre> Genre { get; set; }
        public virtual DbSet<Publisher> Publisher { get; set; }
        public virtual DbSet<Rating> Rating { get; set; }
        public virtual DbSet<Platform> Platform { get; set; }
        public virtual DbSet<Links> Links { get; set; }
    }
}

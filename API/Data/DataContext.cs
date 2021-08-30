using API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        // Heroes' DbSet  and Powers' DbSet
        public DbSet<Hero> Heroes { get; set; }
        public DbSet<Power> Powers { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<HeroPower>()
                .HasKey(hp => new {hp.HeroId, hp.PowerId});
            builder.Entity<HeroPower>()
                .HasOne(hp => hp.Hero)
                .WithMany(hp => hp.Powers)
                .HasForeignKey(hp => hp.PowerId);
            builder.Entity<HeroPower>()
                .HasOne(hp => hp.Power)
                .WithMany(hp => hp.Heroes)
                .HasForeignKey(hp => hp.HeroId);
        }
    }
}
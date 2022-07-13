using Dota2replaysaver.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class MatchDbContext : DbContext
    {
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Replay> Replays { get; set; }
        public MatchDbContext(DbContextOptions<MatchDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Match>(entity =>
            {
                entity.HasIndex(e => e.PlayerID).IsClustered(true);
            });
        }
    }
}

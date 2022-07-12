using Dota2replaysaver.Models;
using Microsoft.EntityFrameworkCore;

namespace DataLayer.Repositories
{
    public class MatchDbContext : DbContext
    {
        public MatchDbContext(DbContextOptions<MatchDbContext> options) : base(options)
        {

        }
        public virtual DbSet<Match> Matches { get; set; }
        public virtual DbSet<Replay> Replays { get; set; }
    }
}

using DataLayer.Repositories;
using Dota2replaysaver.Models;
using Dota2replaysaver.Models.Interfaces;

namespace DataLayer
{
    public class MatchRepository : IMatchRepository
    {
        private readonly MatchDbContext _db;

        public MatchRepository(MatchDbContext db)
        {
            _db = db;
        }
        public List<Match> AddMatches(List<Match> matches)
        {
            _db.Matches.AddRange(matches);
            _db.SaveChanges();
            return matches;
        }

        public List<Match> GetMatches()
        {
            return _db.Matches.ToList();
        }

        public List<Match> GetMatches(long playerId)
        {
            return _db.Matches.Where(p => p.PlayerID == playerId).ToList();
        }
    }
}

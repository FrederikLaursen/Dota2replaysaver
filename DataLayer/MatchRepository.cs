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
        public Match AddMatch(Match newMatch)
        {
            _db.Matches.Add(newMatch);
            _db.SaveChanges();
            return newMatch;
        }
        public List<Match> AddMatches(List<Match> matches)
        {
            _db.Matches.AddRange(matches);
            _db.SaveChanges();
            return matches;
        }

        public Match GetMatch(long id)
        {
            return _db.Matches.Find(id);
        }

        public List<Match> GetMatches()
        {
            return _db.Matches.ToList();
        }

        public List<Match> GetMatches(long playerId)
        {
            return _db.Matches.ToList().Where(p => p.PlayerID == playerId).ToList();
        }

        public bool HasInitialized(long playerId)
        {
            bool doesExist = _db.Matches.Any(p => p.PlayerID == playerId);
            return doesExist;
        }
    }
}

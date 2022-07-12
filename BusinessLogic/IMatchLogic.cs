using Dota2replaysaver.Models;

namespace BusinessLogic
{
    public interface IMatchLogic
    {
        Match AddMatch(Match newMatch);
        Match GetMatch(int id);
        List<Match> GetMatches(int playerId);
        bool HasInitialized(int playerId);
        Task<List<Match>> UpdateMatches(int playerId);
    }
}
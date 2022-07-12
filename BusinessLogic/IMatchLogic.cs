using Dota2replaysaver.Models;

namespace BusinessLogic
{
    public interface IMatchLogic
    {
        List<Match> GetMatches(int playerId);
        Task<List<Match>> UpdateMatches(int playerId);
    }
}
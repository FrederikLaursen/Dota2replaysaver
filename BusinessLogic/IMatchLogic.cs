using Dota2replaysaver.Models;

namespace BusinessLogic
{
    public interface IMatchLogic
    {
        // Match AddMatch(Match newMatch);
        //  Match GetMatch(int id);
          List<Match> GetMatches(int playerId);
        //List<Match> AddMatches(List<Match> matches);
        //   List<Match> AddMatches(List<Match> matches);
      //  bool HasInitialized(int playerId);
        Task<List<Match>> UpdateMatches(int playerId);
    }
}
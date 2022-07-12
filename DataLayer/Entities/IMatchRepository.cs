namespace Dota2replaysaver.Models.Interfaces
{
    public interface IMatchRepository
    {
        List<Match> GetMatches(int playerId);
        List<Match> AddMatches(List<Match> matches);
        Match GetMatch(int id);
        Match AddMatch(Match newMatch);
        bool HasInitialized(int playerId);
    }
}

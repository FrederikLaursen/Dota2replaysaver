namespace Dota2replaysaver.Models.Interfaces
{
    public interface IMatchRepository
    {
        List<Match> GetMatches(long playerId);
        List<Match> AddMatches(List<Match> matches);
    }
}

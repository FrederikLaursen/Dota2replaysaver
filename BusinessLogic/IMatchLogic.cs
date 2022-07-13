using DataLayer.DTOs;
using Dota2replaysaver.Models;

namespace BusinessLogic
{
    public interface IMatchLogic
    {
        List<MatchDTO> GetMatches(int playerId);
        Task<bool> UpdateMatches(int playerId);
    }
}
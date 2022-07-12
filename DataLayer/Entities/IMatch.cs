﻿namespace Dota2replaysaver.Models.Interfaces
{
    public interface IMatch
    {
        List<Match> GetMatches(int playerId);
        Match GetMatch(int id);
        Match AddMatch(Match newMatch);
        bool HasInitialized(int playerId);
    }
}
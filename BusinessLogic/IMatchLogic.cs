﻿using DataLayer.DTOs;
using Dota2replaysaver.Models;

namespace BusinessLogic
{
    public interface IMatchLogic
    {
        Task<List<MatchDTO>> GetMatches(int playerId);
        Task UpdateMatches(int playerId);
        List<Match> FindNew(List<Match> currentMatches, List<Match> newMatches);

    }
}
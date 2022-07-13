using BusinessLogic.Services;
using DataLayer.DTOs;
using Dota2replaysaver.Models;
using Dota2replaysaver.Models.Interfaces;
using System.Text.Json;

namespace BusinessLogic
{
    public class MatchLogic : IMatchLogic
    {
        private readonly IMatchRepository _data;
        private readonly IHttpClientFactory _httpClientFactory;
        public MatchLogic(IMatchRepository data, IHttpClientFactory httpClientFactory)
        {
            _data = data;
            _httpClientFactory = httpClientFactory;
        }

        public List<MatchDTO> GetMatches(int playerId)
        {
            List<MatchDTO> matchList = new List<MatchDTO>();
            var isSuccessfullUpdate = (UpdateMatches(playerId).ConfigureAwait(false).GetAwaiter().GetResult());
            if (isSuccessfullUpdate)
            {
                matchList = _data.GetMatches(playerId).Select(match => new MatchDTO
                {
                    GameId = match.GameId,
                    PlayerID = match.PlayerID,
                    Date = DateTimeOffset.FromUnixTimeSeconds(match.Date)
                }).ToList();

                return matchList;
            }
            else
            {
                //Somekind of error handling?
                return matchList;
            }
        }

        public async Task<bool> UpdateMatches(int playerId)
        {
            List<Match> newMatches = new List<Match>();
            List<Match> currentMatches = new List<Match>();

            //Get current matches
            currentMatches = _data.GetMatches(playerId);

            //Get new matches
            var http = new HttpClientService(_httpClientFactory);
            string rawResult = await http.Get("https://api.opendota.com/api/players/" + playerId + "/matches");

            //try catch? Move to own class?
            if (rawResult != null)
            {
                newMatches = JsonSerializer.Deserialize<List<Match>>(rawResult);
                for (int i = 0; i < newMatches.Count; i++)
                {
                    newMatches[i].PlayerID = playerId;
                }
            }

            newMatches = FindNew(currentMatches, newMatches);
            if (newMatches.Count > 0)
            {
                _data.AddMatches(newMatches);
            }

            return true;
        }

        public List<Match> FindNew(List<Match> currentMatches, List<Match> newMatches)
        {
            List<Match> matchesToBeSaved = new List<Match>();
            matchesToBeSaved = currentMatches.Concat(newMatches).GroupBy(x => x.GameId).Where(x => x.Count() == 1).Select(x => x.FirstOrDefault()).ToList();
            return matchesToBeSaved;
        }
    }
}
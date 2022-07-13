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
            //CLEANUP required
            if (_data.HasInitialized(playerId))
            {
                //try??
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
                //Incase of null dosomething
                matchList = UpdateMatches(playerId).ConfigureAwait(false).GetAwaiter().GetResult().Select(match => new MatchDTO
                {
                    GameId = match.GameId,
                    PlayerID = match.PlayerID,
                    Date = DateTimeOffset.FromUnixTimeSeconds(match.Date)
                }).ToList();

                return matchList;
            }
        }

        public async Task<List<Match>> UpdateMatches(int playerId)
        {
            List<Match> matchList = new List<Match>();
            var http = new HttpClientService(_httpClientFactory);
            string rawResult = await http.Get("https://api.opendota.com/api/players/" + playerId + "/matches");

            //try catch? Move to own class?
            if (rawResult != null)
            {
                matchList = JsonSerializer.Deserialize<List<Match>>(rawResult);
                for (int i = 0; i < matchList.Count; i++)
                {
                    matchList[i].PlayerID = playerId;
                }
            }
            
            _data.AddMatches(matchList);
            return matchList;
        }
    }
}
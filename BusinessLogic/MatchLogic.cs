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

        public async Task<List<MatchDTO>> GetMatches(int playerId)
        {
            List<MatchDTO> matchList = new List<MatchDTO>();
            await UpdateMatches(playerId);

            matchList = _data.GetMatches(playerId).Select(match => new MatchDTO
            {
                GameId = match.GameId,
                PlayerID = match.PlayerID,
                Date = DateTimeOffset.FromUnixTimeSeconds(match.Date)
            }).ToList();

            return matchList;
        }

        private async Task UpdateMatches(int playerId)
        {
            List<Match> newMatches = new List<Match>();
            List<Match> currentMatches = new List<Match>();

            //Get current matches
            currentMatches = _data.GetMatches(playerId);

            //Get new matches
            var http = _httpClientFactory.CreateClient();
            var httpResponseMessage = await http.GetAsync("https://api.opendota.com/api/players/" + playerId + "/matches");

            //try catch? Move to own class?
            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                await httpResponseMessage.Content.ReadAsStreamAsync();

                newMatches = JsonSerializer.Deserialize<List<Match>>(contentStream);
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
        }

        private List<Match> FindNew(List<Match> currentMatches, List<Match> newMatches)
        {
            List<Match> matchesToBeSaved = new List<Match>();
            matchesToBeSaved = newMatches.ExceptBy(currentMatches.Select(x => x.GameId), x => x.GameId).ToList();
            return matchesToBeSaved;
        }

        private List<Match> GetReplay(List<Match> matches)
        {
            return null;
        }
    }
}
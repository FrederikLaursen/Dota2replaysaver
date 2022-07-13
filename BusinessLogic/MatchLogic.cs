using BusinessLogic.Services;
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
        
        public List<Match> GetMatches(int playerId)
        {
            List<Match> matchList = new List<Match>();
            if (_data.HasInitialized(playerId))
            {
                //try??
                matchList = _data.GetMatches(playerId);
                return matchList;
            }
            else
            {
                //Incase of null dosomething
                matchList = UpdateMatches(playerId).ConfigureAwait(false).GetAwaiter().GetResult();
                return matchList;
            }
        }

        public async Task<List<Match>> UpdateMatches(int playerId)
        {
            int userID = 387424;
            List<Match> matchList = new List<Match>();
            var http = new HttpClientService(_httpClientFactory);
            string rawResult = await http.Get("https://api.opendota.com/api/players/" + userID + "/matches");

            //Create JSON Handler
            return matchList;
        }
    }
}
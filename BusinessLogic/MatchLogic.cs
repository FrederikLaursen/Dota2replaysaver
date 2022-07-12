using Dota2replaysaver.Models;
using Dota2replaysaver.Models.Interfaces;
using System.Text.Json;

namespace BusinessLogic
{
    public class MatchLogic : IMatchLogic
    {
        private readonly IMatch _data;

        public MatchLogic(IMatch data)
        {
            _data = data;
        }
        public Match AddMatch(Match newMatch)
        {
            throw new NotImplementedException();
        }

        public Match GetMatch(int id)
        {
            throw new NotImplementedException();
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

        public bool HasInitialized(int playerId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Match>> UpdateMatches(int playerId)
        {
            int userID = 387424;
            List<Match> matchList = new List<Match>();
            using (var httpClient = new HttpClient())
            {
                //Use httpclient interface instead
                using (var response = await httpClient.GetAsync("https://api.opendota.com/api/players/" + userID + "/matches"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        matchList = JsonSerializer.Deserialize<List<Match>>(apiResponse);

                        for (int i = 0; i < matchList.Count; i++)
                        {
                            matchList[i].PlayerID = userID;
                        }
                        _data.AddMatches(matchList);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return matchList;
        }
    }
}
using System.Text.Json.Serialization;

namespace Dota2replaysaver.Models
{
    public class Match
    {
        [JsonPropertyName("match_id")]
        public long Id { get; set; }
        [JsonPropertyName("start_time")]
        public long Date { get; set; }

        public long PlayerID { get; set; }
    }
}

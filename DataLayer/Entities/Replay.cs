using System.Text.Json.Serialization;

namespace Dota2replaysaver.Models
{
    public class Replay
    {
        [JsonPropertyName("match_id")]
        public long Id { get; set; }
        [JsonPropertyName("cluster")]
        public long Cluster { get; set; }
        [JsonPropertyName("replay_salt")]
        public long Replay_salt { get; set; }

    }
}

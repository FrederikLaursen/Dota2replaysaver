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

        //http://replay<cluster>.valve.net/570/<match_id>_<replay_salt>.dem.bz2.

        //http://replay187.valve.net/570/6604695624_898572298.dem.bz2
    }
}

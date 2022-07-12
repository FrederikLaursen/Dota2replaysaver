using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Dota2replaysaver.Models
{
    public class Match
    {
        [Key]
        public long Id { get; set; }
        [JsonPropertyName("match_id")]
        public long GameId { get; set; }
        [JsonPropertyName("start_time")]
        public long Date { get; set; }

        public long PlayerID { get; set; }
    }
}

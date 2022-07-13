using Dota2replaysaver.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.DTOs
{
    public class MatchDTO
    {
        public long GameId { get; set; }
        public DateTimeOffset Date { get; set; }
        public long PlayerID { get; set; }

        public MatchDTO()
        {
           
        }
    }
}

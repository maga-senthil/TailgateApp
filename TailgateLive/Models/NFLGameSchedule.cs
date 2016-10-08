using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class NFLGameSchedule
    {
        [Key]
        public int Id { get; set; }
        public string gameId { get; set; }
        public string gameWeek { get; set; }
        public string gameDate { get; set; }
        public string awayTeam { get; set; }
        public string homeTeam { get; set; }
        public string gameTimeET { get; set; }
        public string tvStation { get; set; }
        public string winner { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class GameWeather
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
        public string stadium { get; set; }
        public string isDome { get; set; }
        public string geoLat { get; set; }
        public string geoLong { get; set; }
        public string low { get; set; }
        public string high { get; set; }
        public string forecast { get; set; }
        public string windChill { get; set; }
        public string windSpeed { get; set; }
        public string domeImg { get; set; }
        public string smallImg { get; set; }
        public string mediumImg { get; set; }
        public string largeImg { get; set; }
    }
}
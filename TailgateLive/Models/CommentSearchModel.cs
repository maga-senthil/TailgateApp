using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class CommentSearchModel
    {
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
        public int NFLGameScheduleId { get; set; }
        public string gameWeek { get; set; }
        public string gameDate { get; set; }
        public string awayTeam { get; set; }
        public string homeTeam { get; set; }
        public string gameTimeET { get; set; }
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        [Display(Name = "Event Title")]
        public string EventTitle { get; set; }
        public DateTime? EventDate { get; set; }
        public string Comments { get; set; }
        public string CommentString { get; set; }
       public IEnumerable<Comment> List_Commments { get; set; }
        public Comment CommentSearch { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class CommentSearchModel
    {
        [Display(Name = "Stadium")]
        public string stadium { get; set; }
        public string isDome { get; set; }
        public string geoLat { get; set; }
        public string geoLong { get; set; }
        [Display(Name = "Low Temperature")]
        public string low { get; set; }
        [Display(Name = "High Temperature")]
        public string high { get; set; }
        [Display(Name = "Forcast")]
        public string forecast { get; set; }
        [Display(Name = "Windchill")]
        public string windChill { get; set; }
        [Display(Name = "Wind Speed")]
        public string windSpeed { get; set; }
        public string domeImg { get; set; }
        public string smallImg { get; set; }
        public string mediumImg { get; set; }
        public string largeImg { get; set; }
        public int NFLGameScheduleId { get; set; }
        [Display(Name = "Game Week")]
        public string gameWeek { get; set; }
        [Display(Name = "Game Date")]
        public string gameDate { get; set; }
        [Display(Name = "Away Team")]
        public string awayTeam { get; set; }
        [Display(Name = "Home Team")]
        public string homeTeam { get; set; }
        [Display(Name = "Game Time ET")]
        public string gameTimeET { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime? EventDate { get; set; }
        [Display(Name = "Comment")]
        public string Comments { get; set; }
        public string CommentString { get; set; }
        public string EventComments { get; set; }
        public IEnumerable<Comment> List_Commments { get; set; }
        public Comment CommentSearch { get; set; }

    }
}
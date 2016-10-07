using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace TailgateLive.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        public string EventTitle { get; set; }
        public DateTime? EventDate { get; set; }
        public int EventRating { get; set; }
        public bool EventStatus { get; set; }       
        public string EventComments { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
<<<<<<< HEAD
=======

>>>>>>> f62ea1441caa9a70b33f696b75cd114f6aed5b93
        public ICollection<User> Users { get; set; }
        [ForeignKey("NFLGameSchedule")]
        public int NFLGameScheduleId { get; set; }
        public NFLGameSchedule NFLGameSchedule { get; set; }
    }
}
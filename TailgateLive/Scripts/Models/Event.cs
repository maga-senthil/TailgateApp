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
<<<<<<< HEAD:TailgateLive/Scripts/Models/Event.cs
        public ICollection<Team> Teams { get; set; }
        public ICollection <User> Users { get; set; }
=======
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public ICollection<User> Users { get; set; }

>>>>>>> 7335c82097cfc9bb8af717933be892f936fcb9f0:TailgateLive/Models/Event.cs

    }
}
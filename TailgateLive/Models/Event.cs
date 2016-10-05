using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class Event
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EventTitle { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }
        [Required]
        public int EventRating { get; set; }
        public bool EventStatus { get; set; }
        [Required]
        public string EventComments { get; set; }
        public ICollection <User> Users { get; set; }
    }
}
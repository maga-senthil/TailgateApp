using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.PostalCode)]
        public int UserZipCode { get; set; }
        [Required]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Must be a natural number")]
        public int UserRating { get; set; }
        [ForeignKey ("ApplicationUsers")]
        public string LoginId { get; set; }
        public ApplicationUser ApplicationUsers { get; set; }
        public ICollection <Event> Events { get;set; }
        public ICollection <Team> Teams { get; set; }


    }
}
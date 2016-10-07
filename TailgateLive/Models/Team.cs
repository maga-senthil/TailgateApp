using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }
        public string Code { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
    }
}
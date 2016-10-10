using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class CommentSearchModel
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; }
        public DateTime? EventDate { get; set; }
        public string Comments { get; set; }
        public string CommentString { get; set; }
       public IEnumerable<Comment> List_Commments { get; set; }
        public Comment CommentSearch { get; set; }

    }
}
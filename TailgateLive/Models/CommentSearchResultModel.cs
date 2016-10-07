using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TailgateLive.Models
{
    public class CommentSearchResultModel
    {
        public string UserName { get; set; }
        public int UserId { get; set; }
        public int EventId { get; set; }
        public string Comments { get; set; }
        public Comment EventCommentSearch { get; set; }
        public IEnumerable<Comment> List_Commments { get; set; }

    }
}
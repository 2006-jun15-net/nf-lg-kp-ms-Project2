using System;
using System.Collections.Generic;

namespace TheHub.Library.Model
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int ReviewId { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        public int Likes { get; set; }
        public DateTime Date { get; set; }
        public List<User> Likers = new List<User>();

    }
}
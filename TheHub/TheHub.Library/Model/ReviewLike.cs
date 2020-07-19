using System;
using System.Collections.Generic;
using System.Text;

namespace TheHub.Library.Model
{
    public class ReviewLike
    {
        public int UserId { get; set; }
        public int ReviewId { get; set; }
        List<User> Likers = new List<User>();
    }
}

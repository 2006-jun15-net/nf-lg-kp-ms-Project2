using System;
using System.Collections.Generic;
using System.Text;

namespace TheHub.Library.Model
{
    public class ReviewLike
    {
        public int UserId { get; set; }
        public int ReviewId { get; set; }

        public List<User> Likers { get; set; }
    }
}

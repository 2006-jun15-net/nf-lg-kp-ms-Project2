using System;
using System.Collections.Generic;

namespace TheHub.DataAccess.Model
{
    public partial class Reviews
    {
        public Reviews()
        {
            ReviewLikes = new HashSet<ReviewLikes>();
        }

        public int ReviewId { get; set; }
        public string Content { get; set; }
        public int MediaId { get; set; }
        public int UserId { get; set; }
        public DateTime? ReviewDate { get; set; }
        public int? Likes { get; set; }
        public int? Rating { get; set; }

        public virtual Media Media { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<ReviewLikes> ReviewLikes { get; set; }
    }
}

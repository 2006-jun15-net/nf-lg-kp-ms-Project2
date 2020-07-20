using System;
using System.Collections.Generic;

namespace TheHub.DataAccess.Model
{
    public partial class Comments
    {
        public Comments()
        {
            CommentLikes = new HashSet<CommentLikes>();
        }

        public int CommentId { get; set; }
        public string Content { get; set; }
        public int ReviewId { get; set; }
        public int UserId { get; set; }
        public DateTime CommentDate { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<CommentLikes> CommentLikes { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TheHub.DataAccess.Model
{
    public partial class CommentLikes
    {
        public int UserId { get; set; }
        public int CommentId { get; set; }

        public virtual Comments Comment { get; set; }
        public virtual Users User { get; set; }
    }
}

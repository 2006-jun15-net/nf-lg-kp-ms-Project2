using System;
using System.Collections.Generic;

namespace TheHub.DataAccess.Model
{
    public partial class ReviewLikes
    {
        public int UserId { get; set; }
        public int ReviewId { get; set; }

        public virtual Reviews Review { get; set; }
        public virtual Users User { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace TheHub.DataAccess.Model
{
    public partial class Following
    {
        public int FollowerId { get; set; }
        public int FollowingId { get; set; }

        public virtual Users FollowingNavigation { get; set; }
    }
}

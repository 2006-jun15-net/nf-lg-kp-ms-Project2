using System;
using System.Collections.Generic;

namespace TheHub.DataAccess.Model
{
    public partial class Users
    {
        public Users()
        {
            CommentLikes = new HashSet<CommentLikes>();
            Comments = new HashSet<Comments>();
            Following = new HashSet<Following>();
            NotificationsReciver = new HashSet<Notifications>();
            NotificationsSender = new HashSet<Notifications>();
            ReviewLikes = new HashSet<ReviewLikes>();
            Reviews = new HashSet<Reviews>();
        }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Bio { get; set; }
        public string Email { get; set; }
        public string Picture { get; set; }

        public virtual ICollection<CommentLikes> CommentLikes { get; set; }
        public virtual ICollection<Comments> Comments { get; set; }
        public virtual ICollection<Following> Following { get; set; }
        public virtual ICollection<Notifications> NotificationsReciver { get; set; }
        public virtual ICollection<Notifications> NotificationsSender { get; set; }
        public virtual ICollection<ReviewLikes> ReviewLikes { get; set; }
        public virtual ICollection<Reviews> Reviews { get; set; }
    }
}

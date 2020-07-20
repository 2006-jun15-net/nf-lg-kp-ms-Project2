using System;
using System.Collections.Generic;

namespace TheHub.DataAccess.Model
{
    public partial class Notifications
    {
        public int NotificationId { get; set; }
        public int PostId { get; set; }
        public bool Status { get; set; }
        public int ReciverId { get; set; }
        public int? SenderId { get; set; }
        public DateTime NotificationDate { get; set; }
        public string NotificationType { get; set; }

        public virtual Users Reciver { get; set; }
        public virtual Users Sender { get; set; }
    }
}

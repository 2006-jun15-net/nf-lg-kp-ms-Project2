using System;

namespace TheHub.Library.Model
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public int ReviewId { get; set; }

        public int ReceiverId { get; set; }

        public int? SenderId { get; set; }

        public bool Status { get; set; }

        public DateTime Date { get; set; }

        public string Type { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheHub.DataAccess.Model;
using TheHub.Library.Interfaces;
using TheHub.Library.Model;

namespace TheHub.DataAccess.Repository
{
    public class NotificationRepository: INotificationRepo
    {
        private readonly Project2Context _context;

        public NotificationRepository(Project2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a new Notification in the database
        /// </summary>
        /// <param name="notification">The Notification</param>
        public void Add(Notification notification)
        {
            var entity = new Notifications
            {
                NotificationId = notification.NotificationId,
                PostId = notification.ReviewId,
                ReciverId = notification.ReceiverId,
                SenderId = notification.SenderId,
                NotificationType = notification.Type,
                NotificationDate = notification.Date,
                Status = notification.Status
            };
            _context.Notifications.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a Notification from the database
        /// </summary>
        /// <param name="id">The Notification ID</param>
        public void DeleteById(int id)
        {
            _context.Notifications.Remove(_context.Notifications.Find(id));
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes all the Notifications for a particular User
        /// </summary>
        /// <param name="id">The User ID</param>
        public void DeleteByUserId(int id)
        {
            var entities = _context.Notifications.Where(n => n.ReciverId == id);
            _context.RemoveRange(entities);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets a Notification by its ID
        /// </summary>
        /// <param name="id">The Notification ID</param>
        /// <returns></returns>
        public Notification GetById(int id)
        {
            var entity = _context.Notifications.Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            return new Notification
            {
                NotificationId = entity.NotificationId,
                ReceiverId = entity.ReciverId,
                SenderId = entity.SenderId,
                Type = entity.NotificationType,
                Date = entity.NotificationDate,
                Status = entity.Status,
                ReviewId = entity.PostId
            };
        }

        /// <summary>
        /// Gets all the Notifications for a particular User
        /// </summary>
        /// <param name="id">The User ID</param>
        /// <returns>The list of Notifications</returns>
        public IEnumerable<Notification> GetByReciverId(int id)
        {
            var entities = _context.Notifications.Where(n => n.ReciverId == id);
            return entities.Select(e => new Notification
            {
                NotificationId = e.NotificationId,
                ReceiverId = e.ReciverId,
                SenderId = e.SenderId,
                Type = e.NotificationType,
                Date = e.NotificationDate,
                Status = e.Status,
                ReviewId = e.PostId
            });
        }
    }
}

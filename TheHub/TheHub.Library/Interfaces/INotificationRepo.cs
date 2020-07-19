using System;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface INotificationRepo
    {
        Notification GetById(int id);

        List<Notification> GetByReciverId(int id);

        void Add(Notification notification);

        void DeleteById(int id);

        void DeleteByUserId(int id);
    }
}

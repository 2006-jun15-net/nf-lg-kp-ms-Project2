using System;

namespace TheHub.Library.Interfaces
{
    public interface INotificationRepo
    {
        Notification GetById(int id);

        Notification GetByReciverId(int id);

        void Add(Notification notifications);

        void DeleteById(int id);

        void DeleteByUserId(int id);
    }
}

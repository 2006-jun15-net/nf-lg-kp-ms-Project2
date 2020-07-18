using System;

namespace TheHub.Library.Interfaces
{
    public interface INotificationRepo
    {
        Notifications GetById(int id);

        Notifications GetByReciverId(int id);

        void Add(Notifications notifications);

        void DeleteById(int id);

        void DeleteByUserId(int id);
    }
}

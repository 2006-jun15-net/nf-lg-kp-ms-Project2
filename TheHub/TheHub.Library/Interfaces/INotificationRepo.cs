﻿using System;
using System.Collections.Generic;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface INotificationRepo
    {
        Notification GetById(int id);

        IEnumerable<Notification> GetByReceiverId(int id);

        void Add(Notification notification);

        void DeleteById(int id);

        void DeleteByUserId(int id);
    }
}

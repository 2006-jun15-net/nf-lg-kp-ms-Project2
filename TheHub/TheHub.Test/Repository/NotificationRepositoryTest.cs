using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheHub.DataAccess.Model;
using TheHub.DataAccess.Repository;
using TheHub.Library.Interfaces;
using TheHub.Library.Model;
using Xunit;

namespace TheHub.Test.Repository
{
    public class NotificationRepositoryTest
    {
        private static readonly Notification notification = new Notification
        {
            Type = "like",
            ReceiverId = 1,
            SenderId = 2,
            Status = true,
            ReviewId = 1
        };

        [Fact]
        public void NotificationRepository_Add_AddsNotification()
        {
            //arrange 
            INotificationRepo nr = GetInMemoryNotificationRepository();

            //act
            nr.Add(notification);
            var savedNotification = nr.GetById(1);

            //assert
            Assert.Equal(1, savedNotification.ReceiverId);
            Assert.Equal(2, savedNotification.SenderId);
            Assert.Equal("like", savedNotification.Type);
            Assert.Equal(1, savedNotification.ReviewId);
            Assert.True(savedNotification.Status);

        }
        [Fact]
        public void NotificationRepository_GetById_ThrowsExceptionWhenIdNotFound()
        {
            //arrange 
            INotificationRepo nr = GetInMemoryNotificationRepository();

            //act
            nr.Add(notification);

            //assert
            Assert.ThrowsAny<ArgumentNullException>(() => nr.GetById(0));
        }

        [Fact]
        public void NotificationRepository_DeleteById_ThrowsExceptionWhenIdNotFound()
        {
            //arrange 
            INotificationRepo nr = GetInMemoryNotificationRepository();


            //assert
            Assert.ThrowsAny<ArgumentNullException>(() => nr.DeleteById(0));
        }

        [Fact]
        public void NotificationRepository_DeleteById_DeletesNotification()
        {
            //arrange 
            INotificationRepo nr = GetInMemoryNotificationRepository();

            //act
            nr.Add(notification);
            nr.DeleteById(1); //NotificationId should be 1

            //assert
            Assert.ThrowsAny<ArgumentNullException>(() => nr.GetById(1));
        }
        [Fact]
        public void NotificationRepository_DeleteByUserId_DeletesNotifications()
        {
            //arrange 
            INotificationRepo nr = GetInMemoryNotificationRepository();
            Notification notification2 = new Notification
            {
                Type = "like",
                ReceiverId = 1,
                SenderId = 3,
                Status = true,
                ReviewId = 2
            };

            //act
            nr.Add(notification);
            nr.Add(notification2);

            nr.DeleteByUserId(1); //both notifications have same receiver id 
            
            //assert
            Assert.ThrowsAny<ArgumentNullException>(() => nr.GetById(1));
            Assert.ThrowsAny<ArgumentNullException>(() => nr.GetById(2));
        }
        [Fact]
        public void NotificationRepository_GetByUserId_ReturnsIEnumerable()
        {
            //arrange 
            INotificationRepo nr = GetInMemoryNotificationRepository();
            Notification notification2 = new Notification
            {
                Type = "like",
                ReceiverId = 1,
                SenderId = 3,
                Status = true,
                ReviewId = 2
            };

            //act
            nr.Add(notification);
            nr.Add(notification2);

            //assert
            Assert.IsAssignableFrom<IEnumerable<Notification>>(nr.GetByReceiverId(1));
        }

        private INotificationRepo GetInMemoryNotificationRepository()
        {
            DbContextOptions<Project2Context> options;
            var builder = new DbContextOptionsBuilder<Project2Context>();
            builder.UseInMemoryDatabase("Project2InMemory");
            options = builder.Options;
            Project2Context project2Context = new Project2Context(options);
            project2Context.Database.EnsureDeleted();
            project2Context.Database.EnsureCreated();
            return new NotificationRepository(project2Context);
        }
    }
}

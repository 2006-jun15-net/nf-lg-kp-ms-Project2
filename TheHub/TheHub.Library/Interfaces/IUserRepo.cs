using System;
using System.Collections.Generic;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface IUserRepo
    {
        User GetById(int id);

        User GetByUserName(string username);

        IEnumerable<User> GetFollowers(int id); 

        IEnumerable<User> GetFollowing(int id); 

        void Add(User user);
        void AddFollower(int followerId, int followingId);

        void Update(User user);

        void Delete(int id);
    }
}

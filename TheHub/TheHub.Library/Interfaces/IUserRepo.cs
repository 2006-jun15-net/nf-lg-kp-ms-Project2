using System;
using System.Collections.Generic;

namespace TheHub.Library.Interfaces
{
    public interface IUserRepo
    {
        User GetById(int id);

        User GetByUserName(string username);

        List<string> GetFollowers(User users); // bcs we want to just return the names of the user

        List<string> GetFollowing(User users); // bcs we want to just return the names of the user

        void Add(User user);

        void Update(User user);

        void Delete(int id);
    }
}

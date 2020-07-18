using System;
using System.Collections.Generic;

namespace TheHub.Library.Interfaces
{
    public interface IUserRepo
    {
        Users GetById(int id);

        Users GetByUserName(string username);

        List<string> GetFollowers(Users users); // bcs we want to just return the names of the user

        List<string> GetFollowing(Users users); // bcs we want to just return the names of the user

        void Add(Users user);

        void Update(Users user);

        void Delete(int id);
    }
}

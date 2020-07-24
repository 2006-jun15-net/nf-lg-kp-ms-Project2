using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TheHub.DataAccess.Model;
using TheHub.Library.Interfaces;
using TheHub.Library.Model;

namespace TheHub.DataAccess.Repository
{
    public class UserRepository : IUserRepo
    {
        private readonly Project2Context _context;

        public UserRepository(Project2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a user to the database
        /// </summary>
        /// <param name="user">The user</param>
        public void Add(User user)
        {
            var entity = new Users
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Password = user.Password,
                Bio = user.Bio,
                Picture = user.Picture,
                Email = user.Email,
                AdminUser = user.AdminUser

            };
            _context.Users.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a user from the database
        /// </summary>
        /// <param name="id">The User ID</param>
        public void Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                throw new ArgumentNullException();
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets a user from the database without the followers or following 
        /// </summary>
        /// <param name="id">The User ID</param>
        /// <returns>The User</returns>
        public User GetById(int id)
        {
            var entity = _context.Users.Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            return new User
            {
                UserId = entity.UserId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                Password = entity.Password,
                Email = entity.Email,
                Bio = entity.Bio,
                Picture = entity.Picture
            };
        }

        /// <summary>
        /// Gets a user from the database without the followers or following
        /// </summary>
        /// <param name="username">The User UserName</param>
        /// <returns>The User</returns>
        public User GetByUserName(string username)
        {
            var entity = _context.Users.FirstOrDefault(u => u.UserName.Equals(username));
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            return new User
            {
                UserId = entity.UserId,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                UserName = entity.UserName,
                Password = entity.Password,
                Email = entity.Email,
                Bio = entity.Bio,
                Picture = entity.Picture
            };
        }

        /// <summary>
        /// Gets the followers of a user
        /// </summary>
        /// <param name="users">The User ID</param>
        /// <returns>The list of Followers</returns>
        public IEnumerable<User> GetFollowers(int id)
        {
            var entities = _context.Following.Where(f => f.FollowingId == id).ToList();
            List<User> followers = new List<User>();
            foreach (var item in entities)
            {
                var follower = _context.Users.Find(item.FollowerId);

                followers.Add(new User
                {
                    FirstName = follower.FirstName,
                    LastName = follower.LastName,
                    UserName = follower.UserName
                });
            }
            return followers;
        }

        /// <summary>
        /// Add a user to following list
        /// </summary>
        /// <param name="followerId"></param>
        /// <param name="followingId"></param>
        public void AddFollower(int followerId, int followingId)
        {
            var entity = new Following
            {
                FollowerId = followerId,
                FollowingId = followingId
            };
            if (_context.Following.FirstOrDefault(c => c.FollowerId == followerId && c.FollowingId == followingId)==null)
            {
                _context.Following.Add(entity);
                _context.SaveChanges();
            }
        }
        /// <summary>
        /// Gets the users that a user follows
        /// </summary>
        /// <param name="users">The User ID</param>
        /// <returns>The list of followed Users</returns>
        public IEnumerable<User> GetFollowing(int id)
        {
            var entity = _context.Users
                .Include(u => u.Following)
                .FirstOrDefault(u => u.UserId == id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            List<User> followedUsers = new List<User>();
            foreach(var item in entities)
            {
                followedUsers.Add(GetById(item.FollowingId));
            }
            return followedUsers;
        }

        /// <summary>
        /// Updates the user profile in the database
        /// </summary>
        /// <param name="user">The updated User</param>
        public void Update(User user)
        {
            var entity = _context.Users.Find(user.UserId);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.UserName = user.UserName;
            entity.Password = user.Password;
            entity.Bio = user.Bio;
            entity.Email = user.Email;
            entity.Picture = user.Picture;
            _context.Users.Update(entity);
            _context.SaveChanges();
        }
    }
}

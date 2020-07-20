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
    class CommentRepository:ICommentRepo
    {
        private readonly Project2Context _context;

        public CommentRepository(Project2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a Comment in the database
        /// </summary>
        /// <param name="comment">The Comment</param>
        public void Add(Comment comment)
        {
            var entity = new Comments
            {
                CommentId = comment.CommentId,
                Content = comment.Content,
                ReviewId = comment.ReviewId,
                UserId = comment.UserId,
                CommentDate = DateTime.Now
            };
            _context.Comments.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a Comment based on its ID
        /// </summary>
        /// <param name="id">The Comment ID</param>
        public void DeleteById(int id)
        {
            _context.Comments.Remove(_context.Comments.Find(id));
            _context.SaveChanges();
        }

        /// <summary>
        /// Get a Comment by its Id with CommentLikes
        /// </summary>
        /// <param name="id">The Comment ID</param>
        /// <returns>The Comment</returns>
        public Comment GetById(int id)
        {
            var entity = _context.Comments
                .Include(c => c.CommentLikes)
                .First(c => c.CommentId == id);
            List<User> likers = new List<User>();
            foreach(var line in entity.CommentLikes)
            {
                var liker = _context.Users.Find(line.UserId);
                likers.Add(new User 
                { 
                    FirstName = liker.FirstName,
                    LastName = liker.LastName,
                    UserName = liker.UserName
                });
            }
            return new Comment
            {
                CommentId = entity.CommentId,
                ReviewId = entity.ReviewId,
                Content = entity.Content,
                UserId = entity.UserId,
                Likes = entity.CommentLikes.Count,
                Date = entity.CommentDate,
                Likers = likers
            };
        }

        /// <summary>
        /// Get all the Comments for a particular Review without CommentLikes
        /// </summary>
        /// <param name="id">The Review ID</param>
        /// <returns>The list of Comments</returns>
        public List<Comment> GetByReviewId(int id)
        {
            var entities = _context.Comments.Where(c => c.ReviewId == id);
            return (List<Comment>)entities.Select(e => new Comment
            {
                CommentId = e.CommentId,
                ReviewId = e.ReviewId,
                Content = e.Content,
                UserId = e.UserId,
                Likes = e.CommentLikes.Count,
                Date = e.CommentDate
            });

        }

        /// <summary>
        /// Updates the content of the Comment
        /// </summary>
        /// <param name="comment">The updated Comment</param>
        public void Update(Comment comment)
        {
            var entity = _context.Comments.Find(comment.CommentId);
            entity.Content = comment.Content;
            entity.CommentDate = DateTime.Now;
            _context.SaveChanges();
        }
    }
}

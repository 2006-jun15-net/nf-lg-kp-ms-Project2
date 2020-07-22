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
    public class ReviewRepository : IReviewRepo
    {
        private readonly Project2Context _context;

        public ReviewRepository(Project2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Creates a review in the database
        /// </summary>
        /// <param name="review">The Review</param>
        public int Add(Review review)
        {
            var entity = new Reviews
            {
                ReviewDate = review.ReviewDate,
                Rating = review.Rating,
                MediaId = review.MediaId,
                UserId = review.UserId,
                Content = review.Content
            };
            _context.Reviews.Add(entity);
            _context.SaveChanges();
            return entity.ReviewId;
        }

        /// <summary>
        /// Deletes a review from the database
        /// </summary>
        /// <param name="id">The Review ID</param>
        public void Delete(int id)
        {
            _context.Reviews.Remove(_context.Reviews.Find(id));
            _context.SaveChanges();
        }

        /// <summary>
        /// Sorts all the reviews of a particular media by date
        /// </summary>
        /// <param name="mediaId">The media Id</param>
        /// <returns>The sorted list of Reviews</returns>
        public IEnumerable<Review> SortByDate(int mediaId)
        {
            var entities = GetByMediaId(mediaId);
            return entities.OrderByDescending(r => r.ReviewDate);
        }

        /// <summary>
        /// Gets a review given the id without the ReviewLikes
        /// </summary>
        /// <param name="id">The Review ID</param>
        /// <returns>The Review</returns>
        public Review GetById(int id)
        {
            var entity = _context.Reviews.Find(id);
            return new Review
            {
                ReviewId = entity.ReviewId,
                ReviewDate = entity.ReviewDate,
                Rating = entity.Rating,
                MediaId = entity.MediaId,
                UserId = entity.UserId,
                Likes = entity.Likes,
                Content = entity.Content
            };
        }

        /// <summary>
        /// Sorts all the reviews of a particular media by like count 
        /// </summary>
        /// <param name="mediaId">The number of likes</param>
        /// <returns>The sorted list of Reviews</returns>
        public IEnumerable<Review> SortByLikeCount(int mediaId)
        {
            var entities = GetByMediaId(mediaId);
            return entities.OrderByDescending(r => r.Likes);   
        }

        /// <summary>
        /// Gets all the reviews for a particular media without the ReviewLikes
        /// </summary>
        /// <param name="id">The Media ID</param>
        /// <returns>The list of Reviews</returns>
        public IEnumerable<Review> GetByMediaId(int id)
        {
            var entities = _context.Reviews.Where(r => r.MediaId == id);
            return entities.Select(e => new Review
            {
                ReviewId = e.ReviewId,
                ReviewDate = e.ReviewDate,
                Rating = e.Rating,
                MediaId = e.MediaId,
                UserId = e.UserId,
                Likes = e.Likes,
                Content = e.Content
            });
        }

        /// <summary>
        /// Sorts all the reviews of a particular media by rating
        /// </summary>
        /// <param name="mediaId">The Media Id</param>
        /// <returns>The sorted list of Reviews</returns>
        public IEnumerable<Review> SortByRating(int mediaId)
        {
            var entities = GetByMediaId(mediaId);
            return entities.OrderByDescending(r => r.Rating);
        }

        /// <summary>
        /// Gets all the Reviews made by a particular user with ReviewLikes
        /// </summary>
        /// <param name="username">The User UserName</param>
        /// <returns>The list of Reviews</returns>
        public IEnumerable<Review> GetByUserId(int id)
        {
            var entities = _context.Reviews
                .Include(r => r.ReviewLikes)
                .Where(r => r.UserId == id);
            List<Review> reviews = new List<Review>();

            foreach(var review in entities)
            {
                List<User> likers = new List<User>();
                foreach (var line in review.ReviewLikes)
                {
                    var liker = _context.Users.Find(line.UserId);
                    likers.Add(new User
                    { 
                        FirstName = liker.FirstName,
                        LastName = liker.LastName,
                        UserName = liker.UserName
                    });
                }
                reviews.Add(new Review
                {
                    ReviewId = review.ReviewId,
                    ReviewDate = review.ReviewDate,
                    Rating = review.Rating,
                    MediaId = review.MediaId,
                    UserId = review.UserId,
                    Likes = review.Likes,
                    Content = review.Content,
                    Likers = likers
                });
            }
            return reviews;
        }

        /// <summary>
        /// Updates a Review's content and rating
        /// </summary>
        /// <param name="reviews">The updated Review</param>
        public void Update(Review review)
        {
            var entity = _context.Reviews.Find(review.ReviewId);
            entity.Content = review.Content;
            entity.ReviewDate = DateTime.Now;
            entity.Rating = review.Rating;
            _context.SaveChanges();
        }

    }
}

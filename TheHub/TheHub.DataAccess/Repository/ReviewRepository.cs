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
    class ReviewRepository : IReviewRepo
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
        public void Add(Review review)
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
        /// Gets all the Reviews after a given date without the ReviewLikes
        /// </summary>
        /// <param name="date">The date</param>
        /// <returns>The list of Reviews</returns>
        public List<Review> GetByDate(DateTime date)
        {
            var entities = _context.Reviews.Where(r => r.ReviewDate >= date.Date);
            return (List<Review>)entities.Select(e => new Review
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
        /// Gets all the Reviews with likes >= the given number of likes without the ReviewLikes
        /// </summary>
        /// <param name="likes">The number of likes</param>
        /// <returns>The Review</returns>
        public Review GetByLikeCount(int likes)
        {
            var entities = _context.Reviews.Where(r => r.Likes >= likes);
            return (Review)entities.Select(e => new Review
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
        /// Gets all the reviews for a particular media without the ReviewLikes
        /// </summary>
        /// <param name="id">The Media ID</param>
        /// <returns>The list of Reviews</returns>
        public List<Review> GetByMediaId(int id)
        {
            var entities = _context.Reviews.Where(r => r.MediaId == id);
            return (List<Review>)entities.Select(e => new Review
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
        /// Gets all the Reviews with a rating >= the given rating without ReviewLikes
        /// </summary>
        /// <param name="rating">The Review Rating</param>
        /// <returns>The list of Reviews</returns>
        public List<Review> GetByRating(int rating)
        {
            var entities = _context.Reviews.Where(r => r.Rating >= rating);
            return (List<Review>)entities.Select(e => new Review
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
        /// Gets all the Reviews made by a particular user with ReviewLikes
        /// </summary>
        /// <param name="username">The User UserName</param>
        /// <returns>The list of Reviews</returns>
        public List<Review> GetByUserId(int id)
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

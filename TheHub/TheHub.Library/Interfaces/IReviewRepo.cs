using System;
using System.Collections.Generic;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface IReviewRepo
    {
        Review GetById(int id);

        IEnumerable<Review> GetByUserId(int id);

        IEnumerable<Review> GetByMediaId(int id);

        IEnumerable<Review> SortByRating(int mediaId);

        IEnumerable<Review> SortByDate(int mediaId);

        int Add(Review review);

        void Update(Review review);

        void Delete(int id);

        void CreateLike(int reviewId, int userId);
    }
}

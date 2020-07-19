using System;
using System.Collections.Generic;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface IReviewRepo
    {
        Review GetById(int id);

        List<Review> GetByUserId(int id);

        List<Review> GetByMediaId(int id);

        List<Review> GetByRating(int rating);

        List<Review> GetByDate(DateTime date);

        List<Review> GetByLikeCount(int likes);

        void Add(Review review);

        void Update(Review review);

        void Delete(int id);
    }
}

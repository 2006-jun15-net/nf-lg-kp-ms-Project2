using System;

namespace TheHub.Library.Interfaces
{
    public interface IReviewRepo
    {
        Review GetById(int id);

        Review GetByUserName(string username);

        Review GetByMediaId(int id);

        Review GetByRating(int rating);

        Review GetByDate(DateTime date);

        Review GetByLikeCount(int likes);

        void Add(Review reviews);

        void Update(Review reviews);

        void UpdateDate(DateTime date);

        void Delete(int id);
    }
}

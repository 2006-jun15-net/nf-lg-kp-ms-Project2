using System;

namespace TheHub.Library.Interfaces
{
    public interface IReviewRepo
    {
        Reviews GetById(int id);

        Reviews GetByUserName(string username);

        Reviews GetByMediaId(int id);

        Reviews GetByRating(int rating);

        Reviews GetByDate(DateTime date);

        Reviews GetByLikeCount(int likes);

        void Add(Reviews reviews);

        void Update(Reviews reviews);

        void UpdateDate(DateTime date);

        void Delete(int id);
    }
}

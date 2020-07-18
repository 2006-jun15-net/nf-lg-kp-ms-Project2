using System;

namespace TheHub.Library.Interfaces
{
    public interface IMediaRepo
    {
        Media GetById(int id);

        Media GetByCategory(string category);

        Media GetByTitle(string title);

        Media GetByGenre(string genre);

        Media GetByRating(int rating);

        Media GetByReviewcount(int reviewCount);

        void Add(Media media);

        void Update(Media media);

        void Delete(int id);
    }
}

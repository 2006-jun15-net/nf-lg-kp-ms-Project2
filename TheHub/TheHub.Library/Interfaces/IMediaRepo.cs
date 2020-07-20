using System;
using System.Collections.Generic;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface IMediaRepo
    {
        Media GetById(int id);

        IEnumerable<Media> GetByCategory(string category);

        Media GetByTitle(string title);

        IEnumerable<Media> GetByGenre(string genre);

        IEnumerable<Media> GetByRating(int rating);

        IEnumerable<Media> GetByReviewcount(int reviewCount);

        void Add(Media media);

        void Update(Media media);

        void Delete(int id);
    }
}

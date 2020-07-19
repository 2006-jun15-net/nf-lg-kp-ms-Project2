using System;
using System.Collections.Generic;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface IMediaRepo
    {
        Media GetById(int id);

        List<Media> GetByCategory(string category);

        Media GetByTitle(string title);

        List<Media> GetByGenre(string genre);

        List<Media> GetByRating(int rating);

        List<Media> GetByReviewcount(int reviewCount);

        void Add(Media media);

        void Update(Media media);

        void Delete(int id);
    }
}

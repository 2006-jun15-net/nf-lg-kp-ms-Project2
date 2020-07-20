using System;
using System.Collections.Generic;
using System.Linq;
using TheHub.DataAccess.Model;
using TheHub.Library.Interfaces;
using Media = TheHub.Library.Model.Media;

namespace TheHub.DataAccess.Repository
{
    public class MediaRepository : IMediaRepo
    {
        private readonly Project2Context _context;

        public MediaRepository(Project2Context context)
        {
            _context = context;
        }

        public void Add(Media media)
        {
            var entity = new Model.Media
            {
                Rating = media.Rating,
                MediaName = media.MediaName,
                Description = media.Description,
                CategoryId = media.CategoryId,
                MediaUrl = media.MediaUrl,
                GenreId = media.GenreId
            };
            _context.Media.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Media.Remove(_context.Media.Find(id));
            _context.SaveChanges();
        }

        public IEnumerable<Media> GetByCategory(string mediaType)
        {
            var entity = _context.Media.Where(m => m.MediaType.Name == mediaType);
            return entity.Select(m => new Media
            {
                MediaId = m.MediaId,
                MediaName = m.MediaName,
                Rating = m.Rating,
                Description = m.Description,
                CategoryId = m.CategoryId,
                MediaUrl = m.MediaUrl,
                GenreId = m.GenreId
            });
        }

        public IEnumerable<Media> GetByGenre(string genre)
        {
            var entity = _context.Media.Where(m => m.Genre.GenreName == genre);
            return entity.Select(m => new Media
            {
                MediaId = m.MediaId,
                MediaName = m.MediaName,
                Rating = m.Rating,
                Description = m.Description,
                CategoryId = m.CategoryId,
                MediaUrl = m.MediaUrl,
                GenreId = m.GenreId
            });
        }

        public Media GetById(int id)
        {
            var entity = _context.Media.Find(id);
            return new Media
            {
               MediaId = entity.MediaId,
               MediaName = entity.MediaName,
               Rating = entity.Rating,
               Description = entity.Description,
               CategoryId = entity.CategoryId,
               MediaUrl = entity.MediaUrl,
               GenreId = entity.GenreId
            };
        }

        public IEnumerable<Media> GetByRating(int rating)
        {
            var entity = _context.Media.Where(m => m.Rating >= rating);
            return entity.Select(m => new Media
            {
                MediaId = m.MediaId,
                MediaName = m.MediaName,
                Rating = m.Rating,
                Description = m.Description,
                CategoryId = m.CategoryId,
                MediaUrl = m.MediaUrl,
                GenreId = m.GenreId
            });
        }

        public IEnumerable<Media> GetByReviewcount(int reviewCount)
        {
            var entity = _context.Media.Where(m => m.Reviews.Count >= reviewCount);
            return entity.Select(m => new Media
            {
                MediaId = m.MediaId,
                MediaName = m.MediaName,
                Rating = m.Rating,
                Description = m.Description,
                CategoryId = m.CategoryId,
                MediaUrl = m.MediaUrl,
                GenreId = m.GenreId
            });
        }

        public Media GetByTitle(string title)
        {
            var entity = _context.Media.First(m => m.MediaName.ToLower().Equals(title.ToLower()));
            return new Media
            {
                MediaId = entity.MediaId,
                MediaName = entity.MediaName,
                Rating = entity.Rating,
                Description = entity.Description,
                CategoryId = entity.CategoryId,
                MediaUrl = entity.MediaUrl,
                GenreId = entity.GenreId
            };
        }

        public void Update(Media media)
        {
            var entity = _context.Media.Find(media.MediaId);
            entity.MediaName = media.MediaName;
            entity.Description = media.Description;
            entity.Rating = media.Rating;
            entity.MediaUrl = media.MediaUrl;
            _context.SaveChanges();
        }
    }
}

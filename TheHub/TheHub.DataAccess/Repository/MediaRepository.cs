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
                Composer = media.Composer,
                Description = media.Description,
                MediaTypesId = media.MediaTypeId,
                MediaUrl = media.MediaUrl,
                GenreId = media.GenreId,
                Approved = media.Approved
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
            var entity = _context.Media.Where(m => m.MediaTypes.MediaTypesName == mediaType);
            return entity.Select(m => new Media
            {
                MediaId = m.MediaId,
                MediaName = m.MediaName,
                Composer = m.Composer,
                Rating = m.Rating,
                Description = m.Description,
                MediaTypeId = m.MediaId,
                MediaUrl = m.MediaUrl,
                GenreId = m.GenreId,
                Approved = m.Approved
            });
        }

        public IEnumerable<Media> GetByGenre(string genre)
        {
            var entity = _context.Media.Where(m => m.Genre.GenreName == genre);
            return entity.Select(m => new Media
            {
                MediaId = m.MediaId,
                MediaName = m.MediaName,
                Composer = m.Composer,
                Rating = m.Rating,
                Description = m.Description,
                MediaTypeId = m.MediaTypesId,
                MediaUrl = m.MediaUrl,
                GenreId = m.GenreId,
                Approved = m.Approved
            });
        }

        public Media GetById(int id)
        {
            var entity = _context.Media.Find(id);
            return new Media
            {
                MediaId = entity.MediaId,
                MediaName = entity.MediaName,
                Composer = entity.Composer,
                Rating = entity.Rating,
                Description = entity.Description,
                MediaTypeId = entity.MediaTypesId,
                MediaUrl = entity.MediaUrl,
                GenreId = entity.GenreId,
                Approved = entity.Approved
            };
        }

        public IEnumerable<Media> GetByRating(int rating)
        {
            var entity = _context.Media.Where(m => m.Rating >= rating);
            return entity.Select(m => new Media
            {
                MediaId = m.MediaId,
                MediaName = m.MediaName,
                Composer = m.Composer,
                Rating = m.Rating,
                Description = m.Description,
                MediaTypeId = m.MediaTypesId,
                MediaUrl = m.MediaUrl,
                GenreId = m.GenreId,
                Approved = m.Approved
            });
        }

        public IEnumerable<Media> GetByReviewcount(int reviewCount)
        {
            var entity = _context.Media.Where(m => m.Reviews.Count >= reviewCount);
            return entity.Select(m => new Media
            {
                MediaId = m.MediaId,
                MediaName = m.MediaName,
                Composer = m.Composer,
                Rating = m.Rating,
                Description = m.Description,
                MediaTypeId = m.MediaTypesId,
                MediaUrl = m.MediaUrl,
                GenreId = m.GenreId,
                Approved = m.Approved
            });
        }

        public Media GetByTitle(string title)
        {
            var entity = _context.Media.First(m => m.MediaName.ToLower().Equals(title.ToLower()));
            return new Media
            {
                MediaId = entity.MediaId,
                MediaName = entity.MediaName,
                Composer = entity.Composer,
                Rating = entity.Rating,
                Description = entity.Description,
                MediaTypeId = entity.MediaTypesId,
                MediaUrl = entity.MediaUrl,
                GenreId = entity.GenreId,
                Approved = entity.Approved
            };
        }

        public void Update(Media media)
        {
            var entity = _context.Media.Find(media.MediaId);
            entity.MediaName = media.MediaName;
            entity.Description = media.Description;
            entity.Composer = media.Composer;
            entity.Rating = media.Rating;
            entity.MediaUrl = media.MediaUrl;
            entity.Approved = media.Approved;
            entity.GenreId = media.GenreId;
            _context.SaveChanges();
        }

       public IEnumerable<Media> GetUnapprovedMedia()
       {
            var entities = _context.Media.Where(m => m.Approved == false);
            return entities.Select(m => new Media
            {
                MediaId = m.MediaId,
                MediaName = m.MediaName,
                Composer = m.Composer,
                Rating = m.Rating,
                Description = m.Description,
                MediaTypeId = m.MediaTypesId,
                MediaUrl = m.MediaUrl,
                GenreId = m.GenreId,
                Approved = m.Approved
            });
        }
    }
}

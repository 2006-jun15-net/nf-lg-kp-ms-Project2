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

        /// <summary>
        /// Creates a new Media in the database
        /// </summary>
        /// <param name="media">The Media</param>
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

        /// <summary>
        /// Deletes a Media from the database
        /// </summary>
        /// <param name="id">The Media Id</param>
        public void Delete(int id)
        {
            var media = _context.Media.Find(id);
            if(media == null)
            {
                throw new ArgumentNullException();
            }
            _context.Media.Remove(media);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets a Media by Category(MediaType)
        /// </summary>
        /// <param name="mediaType">The MediaType</param>
        /// <returns>The list of Media</returns>
        public IEnumerable<Media> GetByMediaType(string mediaType)
        {
            var entity = _context.Media.Where(m => m.MediaTypes.MediaTypesName == mediaType);
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

        /// <summary>
        /// Gets the Media by Genre
        /// </summary>
        /// <param name="genre">The Genre</param>
        /// <returns>The list of Media</returns>
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

        /// <summary>
        /// get medias by composer
        /// </summary>
        /// <param name="composer"></param>
        /// <returns></returns>
        public IEnumerable<Media> GetByComposer(string composer)
        {
            var entity = _context.Media.Where(m => m.Composer == composer);
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

        /// <summary>
        /// Gets the Media by Id
        /// </summary>
        /// <param name="id">The Media Id</param>
        /// <returns>The Media</returns>
        public Media GetById(int id)
        {
            var entity = _context.Media.Find(id);
            if(entity == null)
            {
                throw new ArgumentNullException();
            }
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

        /// <summary>
        /// Gets the Media by Rating
        /// </summary>
        /// <param name="rating">The Rating</param>
        /// <returns>The Media</returns>
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

        /// <summary>
        /// Gets the Media by number of the reviews
        /// </summary>
        /// <param name="reviewCount">The mininum number of Reviews</param>
        /// <returns>The list of Media</returns>
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

        /// <summary>
        /// Gets a Media by title
        /// </summary>
        /// <param name="title">The title</param>
        /// <returns>The Media</returns>
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

        /// <summary>
        /// Updates a Media 
        /// </summary>
        /// <param name="media">The updated Media</param>
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
            entity.MediaTypesId = media.MediaTypeId;
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets the unapproved Media
        /// </summary>
        /// <returns>The unapproved Media</returns>
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

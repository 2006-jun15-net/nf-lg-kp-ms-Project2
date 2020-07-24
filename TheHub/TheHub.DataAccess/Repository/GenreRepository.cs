using System;
using System.Collections.Generic;
using System.Linq;
using TheHub.DataAccess.Model;
using TheHub.Library.Interfaces;
using Genre = TheHub.Library.Model.Genre;

namespace TheHub.DataAccess.Repository
{
    public class GenreRepository : IGenreRepo
    {
        private readonly Project2Context _context;

        public GenreRepository(Project2Context context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a Genre to the database
        /// </summary>
        /// <param name="genre">The Genre</param>
        public void Add(Genre genre)
        {
            var entity = new Model.Genre
            {
                GenreName = genre.GenreName
            };
            _context.Genre.Add(entity);
            _context.SaveChanges();
        }

        /// <summary>
        /// Deletes a Genre from the database
        /// </summary>
        /// <param name="id">The Genre Id</param>
        public void Delete(int id)
        {
            var genre = _context.Genre.Find(id);
            if(genre == null)
            {
                throw new ArgumentNullException();
            }
            _context.Genre.Remove(genre);
            _context.SaveChanges();
        }

        /// <summary>
        /// Gets all the Genres from the database
        /// </summary>
        /// <returns>The Genres</returns>
        public IEnumerable<Genre> GetAll()
        {
            var entity = _context.Genre.ToList();
            return entity.Select(c => new Genre
            {
                GenreId = c.GenreId,
                GenreName = c.GenreName
            });
        }

        /// <summary>
        /// Gets a Genre by Id
        /// </summary>
        /// <param name="id">The Genre Id</param>
        /// <returns></returns>
        public Genre GetById(int id)
        {
            var entity = _context.Genre.Find(id);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            return new Genre
            {
                GenreId = entity.GenreId,
                GenreName = entity.GenreName
            };
        }

        /// <summary>
        /// Updates a Genre
        /// </summary>
        /// <param name="genre">The updated Genre</param>
        public void Update(Genre genre)
        {
            var entity = _context.Genre.Find(genre.GenreId);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }
            entity.GenreName = genre.GenreName;
            _context.SaveChanges();
        }
    }
}

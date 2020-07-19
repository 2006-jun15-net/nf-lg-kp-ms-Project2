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

        public void Add(Genre genre)
        {
            var entity = new Model.Genre
            {
                GenreName = genre.GenreName
            };
            _context.Genre.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Genre.Remove(_context.Genre.Find(id));
            _context.SaveChanges();
        }

        public IEnumerable<Genre> GetAll()
        {
            var entity = _context.Genre.ToList();
            return entity.Select(c => new Genre
            {
                GenreId = c.GenreId,
                GenreName = c.GenreName
            });
        }

        public Genre GetById(int id)
        {
            var entity = _context.Genre.Find(id);
            return new Genre
            {
                GenreId = entity.GenreId,
                GenreName = entity.GenreName
            };
        }

        public void Update(Genre genre)
        {
            var entity = _context.Genre.Find(genre.GenreId);
            entity.GenreName = genre.GenreName;
            _context.SaveChanges();
        }
    }
}

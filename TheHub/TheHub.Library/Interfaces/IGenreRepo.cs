using System;
using System.Collections.Generic;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface IGenreRepo
    {
        Genre GetById(int id);

        IEnumerable<Genre> GetAll();

        void Add(Genre genre);

        void Update(Genre genre);

        void Delete(int id);
    }
}

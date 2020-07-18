using System;
using System.Collections.Generic;
using TheHub.Library.Model;

namespace TheHub.Library.Interfaces
{
    public interface ICategoryRepo
    {
        Category GetById(int id);

        IEnumerable<Category> GetAll();

        void Add(Category category);

        void Update(Category category);

        void Delete(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using TheHub.DataAccess.Model;
using TheHub.Library.Interfaces;
using Category = TheHub.Library.Model.Category;

namespace TheHub.DataAccess.Repository
{
    public class CategoryRepository : ICategoryRepo
    {
        private readonly Project2Context _context;

        public CategoryRepository(Project2Context context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            var entity = new Model.Category
            {
                CategoryName = category.CategoryName
            };
            _context.Category.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Category.Remove(_context.Category.Find(id));
            _context.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            var entity = _context.Category.ToList();
            return entity.Select(c => new Category
            {
                CategoryId = c.CategoryId,
                CaategoryName = c.CategoryName
            });
        }

        public Category GetById(int id)
        {
            var entity = _context.Category.Find(id);
            return new Category
            {
                CategoryId = entity.CategoryId,
                CategoryName = entity.CategoryName
            };
        }

        public void Update(Category category)
        {
            var entity = _context.Category.Find(category.CategoryId);
            entity.CategoryName = category.CategoryName;
            _context.SaveChanges();
        }
    }
}

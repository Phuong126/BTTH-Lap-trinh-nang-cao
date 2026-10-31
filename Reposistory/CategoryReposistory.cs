using System;
using System.Collections.Generic;
using System.Linq;

namespace BTTH8
{
    public class CategoryRepository : DBRepository<Category>
    {
        public CategoryRepository() : base() { }
        public CategoryRepository(QLTVDBContext context) : base(context) { }

        public List<string> GetNames()
        {
            return _context.Categories.OrderBy(c => c.Name).Select(c => c.Name).ToList();
        }

        public override void Add(Category entity)
        {
            if (_context.Categories.Any(c => c.Name == entity.Name))
                throw new Exception("Category is already exists.");
            base.Add(entity);
        }

        public override void Delete(Category entity)
        {
            if (_context.Books.Any(b => b.Category == entity.Name))
                throw new Exception("Cannot delete: category is used by some books.");
            var e = _context.Categories.Find(entity.Name);
            if (e == null) throw new Exception("Category does not exist.");
            base.Delete(e);
        }
    }
}
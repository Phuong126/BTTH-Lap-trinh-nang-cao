using System;
using System.Collections.Generic;

namespace BTTH8.Business
{
    public class CategoryBuss
    {
        private readonly CategoryRepository _repo;

        public CategoryBuss() : this(new CategoryRepository()) { }
        public CategoryBuss(CategoryRepository repo) { _repo = repo; }

        public List<Category> GetAll() => _repo.GetAll();
        public List<string> GetNames() => _repo.GetNames();

        public void Add(Category c)
        {
            if (string.IsNullOrWhiteSpace(c?.Name)) throw new Exception("Tên thể loại không được để trống.");
            c.Name = c.Name.Trim();
            _repo.Add(c);
        }

        public void Update(Category c)
        {
            if (string.IsNullOrWhiteSpace(c?.Name)) throw new Exception("Tên thể loại không được để trống.");
            _repo.Update(c);
        }

        public void Delete(string name) => _repo.Delete(new Category { Name = name });
    }
}
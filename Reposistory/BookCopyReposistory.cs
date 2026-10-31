using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BTTH8.Reposistory
{
    public class BookCopyRepository : DBRepository<BookCopy>
    {
        public BookCopyRepository() : base() { }
        public BookCopyRepository(QLTVDBContext context) : base(context) { }

        public List<BookCopy> GetByBookId(string bookId)
        {
            return _context.BookCopies.AsNoTracking()
                .Where(c => c.BookId == bookId)
                .OrderBy(c => c.BookCopyID).ToList();
        }

        // Thêm "count" bản sao mới, đánh số tiếp theo số lớn nhất hiện có.
        // Đọc số lớn nhất + chèn nằm chung một transaction (Serializable) để hai lần nhập cùng lúc không trùng mã.
        public List<BookCopy> AddCopies(string bookId, int count)
        {
            return ExecuteInTransaction(() =>
            {
                if (!_context.Books.Any(b => b.Id == bookId))
                    throw new Exception("Book does not exist.");

                var prefix = bookId + ".";
                int max = _context.BookCopies
                    .Where(c => c.BookId == bookId)
                    .Select(c => c.BookCopyID).ToList()
                    .Select(id => int.TryParse(id.Substring(prefix.Length), out var n) ? n : 0)
                    .DefaultIfEmpty(0).Max();

                var list = new List<BookCopy>();
                for (int i = 1; i <= count; i++)
                {
                    list.Add(new BookCopy
                    {
                        BookId = bookId,
                        BookCopyID = BookCopy.MakeId(bookId, max + i),
                        Status = CopyStatus.Available,
                        PhysicalCondition = CopyCondition.New
                    });
                }
                _context.BookCopies.AddRange(list);
                Save();
                return list;
            }, IsolationLevel.Serializable);
        }

        public void UpdateCopy(string copyId, string status, string condition)
        {
            var c = _context.BookCopies.Find(copyId);
            if (c == null) throw new Exception("Copy does not exist.");
            c.Status = status;
            c.PhysicalCondition = condition;
            Save();
        }

        public void DeleteCopy(string copyId)
        {
            var c = _context.BookCopies.Find(copyId);
            if (c == null) throw new Exception("Copy does not exist.");
            if (c.Status == CopyStatus.Borrowed)
                throw new Exception("Cannot delete: this copy is being borrowed.");
            _context.BookCopies.Remove(c);
            Save();
        }
    }
}
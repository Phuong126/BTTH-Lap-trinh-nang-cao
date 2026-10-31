using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BTTH8
{
    public class BookRepository
    {
        private readonly QLTVDBContext _context;

        public BookRepository() : this(new QLTVDBContext()) { }

        // Nhận context dùng chung để nhiều repository nằm trong cùng một transaction
        public BookRepository(QLTVDBContext context) { _context = context; }

        private IQueryable<Book> BooksWithCopies() =>
            _context.Books.AsNoTracking().Include(b => b.BookCopies);

        private static List<Book> FillCopyCount(List<Book> books)
        {
            foreach (var b in books) b.NumberOfCopies = b.BookCopies.Count;
            return books;
        }

        private void Save()
        {
            try { _context.SaveChanges(); }
            finally { _context.ChangeTracker.Clear(); }
        }

        public List<Book> GetAllBooks()
        {
            return FillCopyCount(BooksWithCopies().OrderByDescending(b => b.Title).ToList());
        }

        public List<Book> GetBooksByCategory(string category)
        {
            return FillCopyCount(BooksWithCopies()
                .Where(b => b.Category == category)
                .OrderByDescending(b => b.Title).ToList());
        }

        public Book GetBookById(string id)
        {
            var b = BooksWithCopies().FirstOrDefault(x => x.Id == id);
            if (b != null) b.NumberOfCopies = b.BookCopies.Count;
            return b;
        }

        public List<Book> SearchBooksByTitle(string keyword)
        {
            return FillCopyCount(BooksWithCopies()
                .Where(b => b.Title.Contains(keyword))
                .OrderBy(b => b.Title).ToList());
        }

        // Tìm theo mã / tên / tác giả, có thể lọc thêm theo thể loại (null hoặc rỗng = tất cả)
        public List<Book> Search(string keyword, string category)
        {
            var q = BooksWithCopies();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                keyword = keyword.Trim();
                q = q.Where(b => b.Id.Contains(keyword) || b.Title.Contains(keyword) || b.Author.Contains(keyword));
            }
            if (!string.IsNullOrWhiteSpace(category))
                q = q.Where(b => b.Category == category);
            return FillCopyCount(q.OrderByDescending(b => b.Title).ToList());
        }

        public void addBook(Book book)
        {
            if (_context.Books.Any(b => b.Id == book.Id))
                throw new Exception("Book is already exists.");
            if (!_context.Categories.Any(c => c.Name == book.Category))
                throw new Exception("Category does not exist");

            book.BookCopies = new List<BookCopy>();
            for (int i = 1; i <= book.NumberOfCopies; i++)
            {
                book.BookCopies.Add(new BookCopy
                {
                    BookId = book.Id,
                    BookCopyID = BookCopy.MakeId(book.Id, i),
                    Status = CopyStatus.Available,
                    PhysicalCondition = CopyCondition.New
                });
            }
            _context.Books.Add(book);
            Save();
        }

        public void deleteBook(Book book)
        {
            var existingBook = _context.Books.Include(b => b.BookCopies).FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null)
                throw new Exception("Book does not exist.");
            if (existingBook.BookCopies.Any(bc => bc.Status == CopyStatus.Borrowed))
                throw new Exception("Cannot delete: some copies are being borrowed.");
            _context.BookCopies.RemoveRange(existingBook.BookCopies);
            _context.Books.Remove(existingBook);
            Save();
        }

        public Boolean updateBook(Book book)
        {
            var existingBook = _context.Books.Find(book.Id);
            if (existingBook == null)
                throw new Exception("Book does not exist.");
            if (!_context.Categories.Any(c => c.Name == book.Category))
                throw new Exception("Category does not exist");

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.Publisher = book.Publisher;
            existingBook.Category = book.Category;
            existingBook.Price = book.Price;
            existingBook.PublishYear = book.PublishYear;
            Save();
            return true;
        }
    }
}
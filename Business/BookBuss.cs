using System;
using System.Collections.Generic;

namespace BTTH8.Business
{
    public class BookBuss
    {
        private readonly BookRepository _repo;

        public BookBuss() : this(new BookRepository()) { }
        public BookBuss(BookRepository repo) { _repo = repo; }

        public List<Book> GetAll() => _repo.GetAllBooks();

        public List<Book> Search(string keyword, string category) => _repo.Search(keyword, category);

        public Book GetById(string id) => _repo.GetBookById(id);

        public void Add(Book b)
        {
            Validate(b, isNew: true);
            _repo.addBook(b);
        }

        public void Update(Book b)
        {
            Validate(b, isNew: false);
            _repo.updateBook(b);
        }

        public void Delete(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) throw new Exception("Chưa chọn đầu sách.");
            _repo.deleteBook(new Book { Id = id });
        }

        private static void Validate(Book b, bool isNew)
        {
            if (b == null) throw new Exception("Dữ liệu không hợp lệ.");
            b.Id = b.Id?.Trim();
            b.Title = b.Title?.Trim();
            b.Author = b.Author?.Trim();
            if (string.IsNullOrEmpty(b.Id)) throw new Exception("Mã sách không được để trống.");
            if (b.Id.Contains(".")) throw new Exception("Mã sách không được chứa dấu chấm.");
            if (string.IsNullOrEmpty(b.Title)) throw new Exception("Tên sách không được để trống.");
            if (string.IsNullOrEmpty(b.Author)) throw new Exception("Tác giả không được để trống.");
            if (string.IsNullOrWhiteSpace(b.Category)) throw new Exception("Chưa chọn thể loại.");
            if (b.Price < 0) throw new Exception("Giá sách không được âm.");
            if (b.PublishYear != 0 && (b.PublishYear < 1000 || b.PublishYear > DateTime.Now.Year))
                throw new Exception("Năm xuất bản không hợp lệ.");
            if (isNew && b.NumberOfCopies < 1) throw new Exception("Số bản sao phải >= 1.");
        }
    }
}
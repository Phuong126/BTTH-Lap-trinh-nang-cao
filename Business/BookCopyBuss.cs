using System;
using System.Collections.Generic;
using BTTH8.Reposistory;

namespace BTTH8.Business
{
    public class BookCopyBuss
    {
        private readonly BookCopyRepository _repo;

        public BookCopyBuss() : this(new BookCopyRepository()) { }
        public BookCopyBuss(BookCopyRepository repo) { _repo = repo; }

        public List<BookCopy> GetByBook(string bookId) => _repo.GetByBookId(bookId);

        public void AddCopies(string bookId, int count)
        {
            if (string.IsNullOrWhiteSpace(bookId)) throw new Exception("Chưa chọn đầu sách.");
            if (count < 1) throw new Exception("Số bản sao nhập thêm phải >= 1.");
            _repo.AddCopies(bookId, count);
        }

        public void Update(string copyId, string status, string condition)
        {
            if (string.IsNullOrWhiteSpace(copyId)) throw new Exception("Chưa chọn bản sao.");
            if (Array.IndexOf(CopyStatus.All, status) < 0) throw new Exception("Trạng thái không hợp lệ.");
            if (Array.IndexOf(CopyCondition.All, condition) < 0) throw new Exception("Tình trạng vật lý không hợp lệ.");
            _repo.UpdateCopy(copyId, status, condition);
        }

        public void Delete(string copyId)
        {
            if (string.IsNullOrWhiteSpace(copyId)) throw new Exception("Chưa chọn bản sao.");
            _repo.DeleteCopy(copyId);
        }
    }
}
using BTTH8.Reposistory;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace BTTH8.Business
{
    // Dòng hiển thị cho lưới bản sao (đã chuyển sang tiếng Việt)
    public class CopyRow
    {
        public string BookCopyID { get; set; }
        public string Status { get; set; }              // giá trị gốc: Available...
        public string StatusText { get; set; }          // "Sẵn sàng"
        public string PhysicalCondition { get; set; }   // giá trị gốc: New...
        public string ConditionText { get; set; }       // "Mới"
    }

    // Lớp nghiệp vụ tổng hợp cho form "Quản lý đầu sách và bản sao".
    // Toàn bộ repository dùng CHUNG một QLTVDBContext, nhờ đó mọi thao tác ghi dữ liệu
    // được bọc trong một transaction: thành công hết (Commit) hoặc hoàn tác hết (Rollback).
    public class ManageBookBuss
    {
        public const string AllCategoriesText = "-- Tất cả thể loại --";
        public const string CopiesHint = "Chọn một bản sao để cập nhật trạng thái, tình trạng hoặc xóa.";

        private readonly QLTVDBContext _db;
        private readonly BookBuss _bookBuss;
        private readonly BookCopyBuss _copyBuss;
        private readonly CategoryBuss _categoryBuss;

        public ManageBookBuss()
        {
            _db = new QLTVDBContext();
            _bookBuss = new BookBuss(new BookRepository(_db));
            _copyBuss = new BookCopyBuss(new BookCopyRepository(_db));
            _categoryBuss = new CategoryBuss(new CategoryRepository(_db));
        }

        // =====================================================================
        //  TRANSACTION
        // =====================================================================
        // Chạy "action" trong transaction: lỗi ở bất kỳ bước nào thì Rollback toàn bộ rồi ném lại lỗi.
        // Nếu đang trong transaction khác thì tham gia luôn (không tạo lồng).
        private void InTransaction(Action action, IsolationLevel level = IsolationLevel.ReadCommitted)
        {
            if (_db.Database.CurrentTransaction != null)
            {
                action();
                return;
            }

            using (var tx = _db.Database.BeginTransaction(level))
            {
                try
                {
                    action();
                    tx.Commit();
                }
                catch
                {
                    tx.Rollback();
                    _db.ChangeTracker.Clear();   // bỏ các thay đổi còn dở trong bộ nhớ
                    throw;
                }
            }
        }

        // =====================================================================
        //  THỂ LOẠI
        // =====================================================================
        // Cho ComboBox thể loại trong form nhập (không có mục "Tất cả")
        public List<string> GetCategoryNames() => _categoryBuss.GetNames();

        // Cho ComboBox lọc: mục đầu tiên là "-- Tất cả thể loại --"
        public List<string> GetFilterItems()
        {
            var list = new List<string> { AllCategoriesText };
            list.AddRange(_categoryBuss.GetNames());
            return list;
        }

        // =====================================================================
        //  ĐẦU SÁCH
        // =====================================================================
        // keyword: mã / tên / tác giả. category: null, rỗng hoặc "-- Tất cả thể loại --" = không lọc.
        // Sắp xếp theo tên sách giảm dần như giao diện.
        public List<Book> GetBooks(string keyword = null, string category = null)
        {
            if (string.IsNullOrWhiteSpace(category) || category == AllCategoriesText)
                category = null;
            return _bookBuss.Search(keyword, category)
                            .OrderByDescending(b => b.Title, StringComparer.CurrentCultureIgnoreCase)
                            .ToList();
        }

        public Book GetBook(string bookId) => _bookBuss.GetById(bookId);

        // Thêm đầu sách + tự sinh bản sao B006.001, B006.002... (Sẵn sàng / Mới)
        public void AddBook(Book book) => InTransaction(() => _bookBuss.Add(book));

        public void UpdateBook(Book book) => InTransaction(() => _bookBuss.Update(book));

        // Xoá đầu sách kèm toàn bộ bản sao (lỗi nếu còn bản đang mượn)
        public void DeleteBook(string bookId) => InTransaction(() => _bookBuss.Delete(bookId));

        // Lưu chỉnh sửa đầu sách và nhập thêm bản sao trong CÙNG một transaction.
        // Nếu nhập bản sao lỗi thì phần sửa thông tin sách cũng bị hoàn tác.
        public void UpdateBookAndAddCopies(Book book, int extraCopies)
        {
            InTransaction(() =>
            {
                _bookBuss.Update(book);
                if (extraCopies > 0) _copyBuss.AddCopies(book.Id, extraCopies);
            }, IsolationLevel.Serializable);
        }

        // =====================================================================
        //  BẢN SAO
        // =====================================================================
        public List<CopyRow> GetCopies(string bookId)
        {
            if (string.IsNullOrWhiteSpace(bookId)) return new List<CopyRow>();
            return _copyBuss.GetByBook(bookId).Select(c => new CopyRow
            {
                BookCopyID = c.BookCopyID,
                Status = c.Status,
                StatusText = CopyStatus.ToVietnamese(c.Status),
                PhysicalCondition = c.PhysicalCondition,
                ConditionText = CopyCondition.ToVietnamese(c.PhysicalCondition)
            }).ToList();
        }

        // "Nhập bổ sung bản sao" / "Nhập thêm bản sao": đánh số nối tiếp số lớn nhất hiện có.
        // Serializable để hai lần nhập cùng lúc không sinh trùng mã.
        public void AddCopies(string bookId, int count)
            => InTransaction(() => _copyBuss.AddCopies(bookId, count), IsolationLevel.Serializable);

        public void UpdateCopy(string copyId, string status, string condition)
            => InTransaction(() => _copyBuss.Update(copyId, status, condition));

        public void DeleteCopy(string copyId)
            => InTransaction(() => _copyBuss.Delete(copyId));

        // Xóa nhiều bản sao: hoặc xóa hết, hoặc không xóa bản nào
        // (ví dụ có một bản đang mượn thì toàn bộ bị hoàn tác).
        public void DeleteCopies(IEnumerable<string> copyIds)
        {
            var ids = (copyIds ?? Enumerable.Empty<string>()).ToList();
            InTransaction(() =>
            {
                foreach (var id in ids) _copyBuss.Delete(id);
            });
        }

        // =====================================================================
        //  CHUỖI HIỂN THỊ THEO GIAO DIỆN
        // =====================================================================
        public int CountCopies(string bookId) => GetCopies(bookId).Count;

        // "Danh sách bản sao của sách B006 (5 bản sao)"
        public string CopiesTitle(string bookId)
            => $"Danh sách bản sao của sách {bookId} ({CountCopies(bookId)} bản sao)";

        // "Đã tải 16 đầu sách lúc 13:38:30"
        public string LoadedMessage(int count)
            => $"Đã tải {count} đầu sách lúc {DateTime.Now:HH:mm:ss}";

        // Số bản đang sẵn sàng / đang mượn của một đầu sách
        public (int available, int borrowed) GetCopyStats(string bookId)
        {
            var list = GetCopies(bookId);
            return (list.Count(c => c.Status == CopyStatus.Available),
                    list.Count(c => c.Status == CopyStatus.Borrowed));
        }

        // Việt hoá thông báo lỗi từ tầng repository
        public static string TranslateError(string m) => m switch
        {
            "Book is already exists." => "Mã sách đã tồn tại.",
            "Book does not exist." => "Đầu sách không tồn tại.",
            "Category does not exist" => "Thể loại không tồn tại.",
            "Category is already exists." => "Thể loại đã tồn tại.",
            "Cannot delete: category is used by some books." => "Không thể xóa: thể loại đang được sử dụng.",
            "Cannot delete: some copies are being borrowed." => "Không thể xóa: có bản sao đang được mượn.",
            "Cannot delete: this copy is being borrowed." => "Không thể xóa: bản sao đang được mượn.",
            "Copy does not exist." => "Bản sao không tồn tại.",
            _ => m
        };
    }
}
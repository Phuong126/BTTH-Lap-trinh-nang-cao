using System;
using System.Collections.Generic;

namespace BTTH8
{
    public class Book
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }      // Nhà xuất bản
        public string Category { get; set; }       // tên thể loại (khoá ngoại -> Category.Name)
        public decimal Price { get; set; }         // Giá sách
        public int PublishYear { get; set; }       // Năm xuất bản
        public int NumberOfCopies { get; set; }    // không lưu DB: số bản sao cần tạo khi thêm / số bản sao hiện có khi đọc

        public virtual List<BookCopy> BookCopies { get; set; } = new List<BookCopy>();
    }
}
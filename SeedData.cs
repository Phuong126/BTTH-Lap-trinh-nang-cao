using System;
using System.Collections.Generic;
using System.Linq;

namespace BTTH8
{
    // Dữ liệu mẫu: 4 thể loại + 16 đầu sách (B001..B016) kèm bản sao.
    // Chỉ chèn khi bảng tương ứng còn trống, nên chạy nhiều lần không bị trùng.
    public static class SeedData
    {
        public static void Run(QLTVDBContext db)
        {
            if (!db.Categories.Any())
            {
                db.Categories.AddRange(
                    new Category { Name = "Văn học", Description = "Tiểu thuyết, truyện ngắn, thơ" },
                    new Category { Name = "Lịch sử", Description = "Sách lịch sử, địa lý, văn hóa" },
                    new Category { Name = "Kinh tế", Description = "Kinh tế, quản trị, tài chính" },
                    new Category { Name = "Khoa học tự nhiên", Description = "Toán, lý, hóa, sinh, môi trường" });
                db.SaveChanges();
            }

            if (db.Books.Any()) return;

            //            Id      Tên sách                                         Thể loại             Tác giả              NXB                   Giá      Năm   Bản sao
            var rows = new (string, string, string, string, string, decimal, int, int)[]
            {
                ("B001", "Những người khốn khổ ở xóm nhỏ",               "Văn học",           "Nguyễn Thanh Hà",   "NXB Văn học",        95000,  2018, 4),
                ("B002", "Hoa nở trên đồng cỏ",                          "Văn học",           "Lê Minh Châu",      "NXB Kim Đồng",       88000,  2019, 3),
                ("B003", "Thơ tình chọn lọc",                            "Văn học",           "Hoàng Thu Hương",   "NXB Hội Nhà văn",    72000,  2017, 3),
                ("B004", "Việt Nam sử lược",                             "Lịch sử",           "Trần Trọng Kim",    "NXB Văn hóa",       150000,  2016, 4),
                ("B005", "Lịch sử thế giới cận đại",                     "Lịch sử",           "Vũ Đức Anh",        "NXB Giáo dục",      165000,  2021, 3),
                ("B006", "Tuyển tập truyện ngắn quê hương",              "Văn học",           "Trần Ngọc Lan",     "NXB Văn học",       110000,  2020, 5),
                ("B007", "Tìm hiểu lịch sử Việt Nam thời Trần",          "Lịch sử",           "Đặng Quốc Hùng",    "NXB Giáo dục",      135000,  2019, 4),
                ("B008", "Kinh tế học vi mô căn bản",                    "Kinh tế",           "Phạm Văn Đức",      "NXB Kinh tế Quốc dân", 185000, 2022, 5),
                ("B009", "Marketing hiện đại cho doanh nghiệp nhỏ",      "Kinh tế",           "Ngô Thị Mai",       "NXB Lao động",      120000,  2021, 3),
                ("B010", "Vật lý đại cương tập 1",                       "Khoa học tự nhiên", "Bùi Quang Huy",     "NXB Đại học Quốc gia", 160000, 2018, 4),
                ("B011", "Hóa học hữu cơ nâng cao",                      "Khoa học tự nhiên", "Đinh Thị Hoa",      "NXB Khoa học và Kỹ thuật", 175000, 2020, 3),
                ("B012", "Sinh học và môi trường",                       "Khoa học tự nhiên", "Phan Văn Bình",     "NXB Đại học Sư phạm", 140000, 2019, 4),
                ("B013", "Toán rời rạc và ứng dụng",                     "Khoa học tự nhiên", "Lý Hoàng Nam",      "NXB Giáo dục",      130000,  2017, 3),
                ("B014", "Quản trị doanh nghiệp hiện đại",               "Kinh tế",           "Lê Thị Thanh",      "NXB Tài chính",     175000,  2022, 4),
                ("B015", "Tài chính cá nhân thực hành",                  "Kinh tế",           "Đỗ Minh Quân",      "NXB Lao động",      130000,  2023, 4),
                ("B016", "Địa lý văn hóa các vùng miền",                 "Lịch sử",           "Trương Thị Lan",    "NXB Văn hóa",       115000,  2018, 3),
            };

            foreach (var r in rows)
            {
                var book = new Book
                {
                    Id = r.Item1,
                    Title = r.Item2,
                    Category = r.Item3,
                    Author = r.Item4,
                    Publisher = r.Item5,
                    Price = r.Item6,
                    PublishYear = r.Item7
                };
                for (int i = 1; i <= r.Item8; i++)
                {
                    book.BookCopies.Add(new BookCopy
                    {
                        BookId = book.Id,
                        BookCopyID = BookCopy.MakeId(book.Id, i),
                        Status = CopyStatus.Available,
                        PhysicalCondition = CopyCondition.New
                    });
                }
                db.Books.Add(book);
            }

            // Vài bản sao khác trạng thái để thử các chức năng cập nhật / xóa
            db.SaveChanges();
            var b15 = db.BookCopies.Find("B015.001");
            if (b15 != null) { b15.Status = CopyStatus.Borrowed; b15.PhysicalCondition = CopyCondition.Good; }
            var b04 = db.BookCopies.Find("B004.002");
            if (b04 != null) { b04.PhysicalCondition = CopyCondition.Damaged; }
            var b08 = db.BookCopies.Find("B008.005");
            if (b08 != null) { b08.Status = CopyStatus.Lost; }
            db.SaveChanges();
        }
    }
}
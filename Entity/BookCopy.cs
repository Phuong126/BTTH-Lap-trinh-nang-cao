using System;

namespace BTTH8
{
    public class BookCopy
    {
        public string BookCopyID { get; set; }          // dạng "MaSach.001"
        public string BookId { get; set; }
        public string Status { get; set; }              // Available, Borrowed, Lost
        public string PhysicalCondition { get; set; }   // New, Good, Damaged

        public virtual Book Book { get; set; }

        public static string MakeId(string bookId, int index) => $"{bookId}.{index:D3}";
    }

    public static class CopyStatus
    {
        public const string Available = "Available";   // Sẵn sàng
        public const string Borrowed = "Borrowed";     // Đang mượn
        public const string Lost = "Lost";             // Mất

        public static readonly string[] All = { Available, Borrowed, Lost };

        public static string ToVietnamese(string s) => s switch
        {
            Available => "Sẵn sàng",
            Borrowed => "Đang mượn",
            Lost => "Mất",
            _ => s
        };
    }

    public static class CopyCondition
    {
        public const string New = "New";
        public const string Good = "Good";
        public const string Damaged = "Damaged";

        public static readonly string[] All = { New, Good, Damaged };

        public static string ToVietnamese(string s) => s switch
        {
            New => "Mới",
            Good => "Tốt",
            Damaged => "Hư hỏng",
            _ => s
        };
    }
}
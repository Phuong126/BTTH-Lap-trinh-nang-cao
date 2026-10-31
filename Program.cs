using System;
using System.Windows.Forms;

namespace BTTH8
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();   // .NET 6+; với .NET Framework dùng Application.EnableVisualStyles()

            try
            {
                using (var db = new QLTVDBContext())
                {
                    db.Database.EnsureCreated();     // tạo database + bảng nếu chưa có
                    SeedData.Run(db);                // thêm dữ liệu mẫu nếu bảng còn trống
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không kết nối được cơ sở dữ liệu:\n" + (ex.InnerException?.Message ?? ex.Message) +
                                "\n\nKiểm tra lại chuỗi kết nối trong QLTVDBContext.cs",
                                "Lỗi kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(new FrmQuanLySach());
        }
    }
}
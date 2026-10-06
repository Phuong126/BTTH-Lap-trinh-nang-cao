using System;
using System.Collections.Generic;
using System.Text;

namespace QuanLySinhVien
{
    public partial class frmQLSV
    {
    private List<LopHoc> danhSachLop = new List<LopHoc>();
    private List<SinhVien> danhSachSinhVien = new List<SinhVien>();
    public frmQLSV()
    {
        InitializeComponent();
    }
    if (errors.Count == 0)
    {
        svb.AddSinhVien(sv);
    }
    else
    {
        string errorMessage = string.Join("\n", errors);
        MessageBox.Show(errorMessage, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace QuanLySinhVien
{
    class LopHoc
    {
        [Required(ErrorMessage = "Mã sinh viên là bắt buộc")]
        public string maSV { get; set; }
        [Required(ErrorMessage = "Tên lớp là bắt buộc")]
        public string lop { get; set; }

    }
}

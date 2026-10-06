using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLySinhVien.Data.Entity;

namespace BTTH3.Data.DAL
{
    public class SinhVienDAL
    {
        List<SinhVien> sinhViens = new List<SinhVien>();
        public SinhVienDAL()
        {
            sinhViens.Add(new SinhVien
            {
                MaSV = "SV0001",
                HoTen = "Nguyễn Văn A",
                NgaySinh = new DateTime(2000, 1, 1),
                GioiTinh = "Nam",
                MaLop = "CSE0001"
            });
            sinhViens.Add(new SinhVien
            {
                MaSV = "SV0002",
                HoTen = "Trần Thị B",
                NgaySinh = new DateTime(2000, 2, 2),
                GioiTinh = "Nữ",
                MaLop = "CSE0002"
            });
            sinhViens.Add(new SinhVien
            {
                MaSV = "SV0003",
                HoTen = "Lê Văn C",
                NgaySinh = new DateTime(2000, 3, 3),
                GioiTinh = "Nam",
                MaLop = "CSE0003"
            });
        }
        public List<SinhVien> GetAllSinhVien()
        {
            return sinhViens;
        }
        public void AddSinhVien(SinhVien sv)
        {
            sinhViens.Add(sv);
        }
        public void UpdateSinhVien(SinhVien sv)
        {
            SinhVien sve = sinhViens.FirstOrDefault(s => s.MaSV == sv.MaSV);
            if (sve != null)
            {
                sve.HoTen = sv.HoTen;
                sve.NgaySinh = sv.NgaySinh;
                sve.GioiTinh = sv.GioiTinh;
                sve.MaLop = sv.MaLop;
            }

        }
        public void DeleteSinhVien(string maSV)
        {
            SinhVien sv = sinhViens.FirstOrDefault(s => s.MaSV == maSV);
            if (sv != null)
            {
                sinhViens.Remove(sv);
            }
        }
        public SinhVien GetSinhVienById(string maSV)
        {
            return sinhViens.FirstOrDefault(s => s.MaSV == maSV);
        }
    }
}

using BTTH3.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH3.BUL
{
    public class SinhVienBUL
    {
        SinhVienDAL svd;
        public SinhVienBUL()
        {
            svd = new SinhVienDAL();

        }   
        public void addSinhVien(SinhVien sv)
            {
                //Kiem tra sinh vien phai hop le
                if (sv.IsValid().Count() > 0)
                {
                    throw new Exception("Sinh vien khong hop le");
                }
                //Ma  sinh vien chua ton tai
                if (sv != null)
                {
                    throw new Exception("Ma sinh vien da ton tai");
                }
                svd.addSinhVien(sv);
        }
    }

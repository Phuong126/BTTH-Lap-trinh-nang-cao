using BTTH1.Hinh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH1.Hinh
{
    internal class HinhTron : IHinh
    {
        private double banKinh;
        public double BanKinh
        {
            get { return banKinh; }
            set
            {
                if (value < 0)
                    throw new Exception("Ban kinh khong duoc am");
                banKinh = value;
            }
        }
        public HinhTron()
        {
            BanKinh = 0;
        }
        public double getDienTich()
        {
            try
            {
                return Math.PI * BanKinh * BanKinh;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public double getChuVi()
        {
            try
            {
                return 2 * Math.PI * BanKinh;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void nhapThongTin()
        {
            while (true)
            {
                Console.Write("Nhap ban kinh: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    try
                    {
                        BanKinh = value;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Nhap sai dinh dang, vui long nhap lai");
                }
            }
        }
        public void Print()
        {
            Console.WriteLine("Dien tich = " + getDienTich());
            Console.WriteLine("Chu vi = " + getChuVi());
        }

    }
}

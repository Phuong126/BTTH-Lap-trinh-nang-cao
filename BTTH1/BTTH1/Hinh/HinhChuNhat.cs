using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH1.Hinh
{
    public class HinhChuNhat : IHinh
    {
        private double chieuDai;
        private double chieuRong;
        public double ChieuRong
        {
            get { return chieuRong; }
            set
            {
                if (chieuRong < 0)
                    throw new Exception("Chieu rong khong duoc am");
                chieuRong = value;
            }
        }
        public double ChieuDai
        {
            get { return chieuDai; }
            set
            {
                if (chieuDai < 0)
                    throw new Exception("Chieu dai khong duoc am");
                chieuDai = value;
            }
        }
        public HinhChuNhat()
        {
            chieuDai = 1;
            chieuRong = 1;
        }
        public double getDienTich()
        {
            try
            {
                return ChieuDai * ChieuRong;
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
                return (ChieuDai + ChieuRong) * 2;
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
                Console.Write("Nhap chieu dai: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    try
                    {
                        ChieuDai = value;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Nhap sai dinh dang vui long nhap lai");
                }
            }
            while (true)
            {
                Console.Write("Nhap chieu rong: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    try
                    {
                        ChieuRong = value;
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
                else
                {
                    Console.WriteLine("Nhap sai dinh dang vui long nhap lai");
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

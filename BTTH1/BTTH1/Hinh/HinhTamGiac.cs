using BTTH1.Hinh;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTTH1.Hinh
{
    internal class HinhTamGiac : IHinh

    {
        private double canhA;
        private double canhB;
        private double canhC;

        public double CanhA
        {
            get { return canhA; }
            set
            {
                if (value < 0)
                    throw new Exception("Canh A khong duoc am");
                canhA = value;
            }
        }
        public double CanhB
        {
            get { return canhB; }
            set
            {
                if (value < 0)
                    throw new Exception("Canh B khong duoc am");
                canhB = value;
            }
        }
        public double CanhC
        {
            get { return canhC; }
            set
            {
                if (value < 0)
                    throw new Exception("Canh C khong duoc am");
                canhC = value;
            }
        }
        public void isTamGiac()
        {
            if (CanhA + CanhB <= CanhC || CanhA + CanhC <= CanhB || CanhB + CanhC <= CanhA)
                throw new Exception("Khong phai la tam giac");
        }
        public HinhTamGiac()
        {
            CanhA = 0;
            CanhB = 0;
            CanhC = 0;
        }
        public double getDienTich()
        {
            try
            {
                isTamGiac();
                double p = (CanhA + CanhB + CanhC) / 2;
                return Math.Sqrt(p * (p - CanhA) * (p - CanhB) * (p - CanhC));
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
                isTamGiac();
                return CanhA + CanhB + CanhC;
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
                Console.Write("Nhap canh A: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    try
                    {
                        CanhA = value;
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
                Console.Write("Nhap canh B: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    try
                    {
                        CanhB = value;
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
                Console.Write("Nhap canh C: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    try
                    {
                        CanhC = value;
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

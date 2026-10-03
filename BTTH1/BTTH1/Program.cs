using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BTTH1.Hinh;

namespace BTTH1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IHinh hinh;

            hinh = new HinhTron();
            hinh.nhapThongTin();
            hinh.Print();

            hinh = new HinhChuNhat();
            hinh.nhapThongTin();
            hinh.Print();

            hinh = new HinhTamGiac();
            hinh.nhapThongTin();
            hinh.Print();


            /*
            int a;
            Console.Write("Nahp a :");
            a = Convert.ToInt32(Console.ReadLine());
            int b;
            Console.Write("Nhap b: ");
            while(true)
                try
                {
                    b = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Nhap sai dinh dang vui long nhap lai");
                }
            //Kieu duoc xac dinh luc dich
            int c;
            while(true)
            {
                Console.Write("Nhap c: ");
                if (int.TryParse(Console.ReadLine(), out c))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Nhap sai dinh dang vui long nhap lai");
                }
            }
            //Khai bao bien kieu duoc xac dinh luc runtime
            //Kieu du lieu khong doi
            var sum = a + b + c;
            //Kieu du lieu thay doi duoc
            dynamic sum1 = a + b + c;
            sum1 = 0.9;
            sum1 = "fjisjgsi";

            const int max = 9;
            */
        }
    }
}

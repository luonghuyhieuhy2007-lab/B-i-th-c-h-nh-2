using System;

namespace Bài_4
{
    // Tạo lớp đa thức
    class DaThuc
    {
        // Khai báo bậc của đa thức
        private int n;

        // Mảng chứa các hệ số
        private int[] a;

        // Khởi tạo không tham số
        public DaThuc()
        {
            this.n = 0;
            this.a = null;
        }

        // Khởi tạo có một tham số
        public DaThuc(int n)
        {
            this.n = n;
            this.a = new int[n + 1];
        }

        // Phương thức nhập đa thức
        public void Nhap()
        {
            Console.Write("Nhap bac cua da thuc: ");
            this.n = int.Parse(Console.ReadLine());

            this.a = new int[n + 1];

            for (int i = 0; i <= n; i++)
            {
                Console.Write("Nhap he so a[{0}]: ", i);
                this.a[i] = int.Parse(Console.ReadLine());
            }
        }

        // Phương thức hiển thị đa thức
        public void HienThi()
        {
            for (int i = n; i >= 0; i--)
            {
                if (a[i] == 0)
                    continue;

                if (i != n && a[i] > 0)
                    Console.Write(" + ");

                if (a[i] < 0)
                    Console.Write(" - ");

                int heSo = Math.Abs(a[i]);

                if (i == 0)
                    Console.Write(heSo);
                else if (i == 1)
                    Console.Write(heSo + "x");
                else
                    Console.Write(heSo + "x^" + i);
            }

            Console.WriteLine();
        }

        // Phương thức cộng hai đa thức
        public DaThuc Cong(DaThuc p)
        {
            int bacMax = Math.Max(this.n, p.n);

            DaThuc kq = new DaThuc(bacMax);

            for (int i = 0; i <= bacMax; i++)
            {
                int a1 = i <= this.n ? this.a[i] : 0;
                int a2 = i <= p.n ? p.a[i] : 0;

                kq.a[i] = a1 + a2;
            }

            return kq;
        }

        // Phương thức trừ hai đa thức
        public DaThuc Tru(DaThuc p)
        {
            int bacMax = Math.Max(this.n, p.n);

            DaThuc kq = new DaThuc(bacMax);

            for (int i = 0; i <= bacMax; i++)
            {
                int a1 = i <= this.n ? this.a[i] : 0;
                int a2 = i <= p.n ? p.a[i] : 0;

                kq.a[i] = a1 - a2;
            }

            return kq;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Tạo đa thức thứ nhất
            DaThuc p1 = new DaThuc();

            Console.WriteLine("Nhap da thuc thu nhat:");
            p1.Nhap();

            // Tạo đa thức thứ hai
            DaThuc p2 = new DaThuc();

            Console.WriteLine("\nNhap da thuc thu hai:");
            p2.Nhap();

            // Hiển thị hai đa thức
            Console.Write("\nDa thuc thu nhat: ");
            p1.HienThi();

            Console.Write("Da thuc thu hai: ");
            p2.HienThi();

            // Cộng hai đa thức
            DaThuc tong = p1.Cong(p2);

            Console.Write("\nTong hai da thuc: ");
            tong.HienThi();

            // Trừ hai đa thức
            DaThuc hieu = p1.Tru(p2);

            Console.Write("Hieu hai da thuc: ");
            hieu.HienThi();

            Console.ReadKey();
        }
    }
}
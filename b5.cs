using System;

namespace Bài_5
{
    // Tạo lớp Date
    class Date
    {
        // Khai báo ngày, tháng, năm
        private int month;
        private int day;
        private int year;

        // Khởi tạo mặc định theo ngày hệ thống
        public Date()
        {
            DateTime ngayHT = DateTime.Today;

            this.month = ngayHT.Month;
            this.day = ngayHT.Day;
            this.year = ngayHT.Year;
        }

        // Khởi tạo có 3 tham số
        public Date(int month, int day, int year)
        {
            DateTime ngay = new DateTime(year, month, day);

            this.month = month;
            this.day = day;
            this.year = year;
        }

        // Phương thức nhập ngày tháng năm
        public void Nhap()
        {
            while (true)
            {
                try
                {
                    Console.Write("Nhap ngay: ");
                    this.day = int.Parse(Console.ReadLine());

                    Console.Write("Nhap thang: ");
                    this.month = int.Parse(Console.ReadLine());

                    Console.Write("Nhap nam: ");
                    this.year = int.Parse(Console.ReadLine());

                    // Kiểm tra ngày tháng năm hợp lệ
                    DateTime ngay = new DateTime(year, month, day);

                    break;
                }
                catch
                {
                    Console.WriteLine("Ngay thang nam khong hop le! Nhap lai!");
                }
            }
        }

        // Phương thức in ngày tháng năm
        public void HienThi()
        {
            Console.WriteLine("Ngay thang nam: {0:MM-dd-yy}",
                new DateTime(year, month, day));
        }

        // Phương thức tăng ngày lên 1
        public void NextDay()
        {
            DateTime ngay = new DateTime(year, month, day);

            ngay = ngay.AddDays(1);

            this.day = ngay.Day;
            this.month = ngay.Month;
            this.year = ngay.Year;
        }

        // Phương thức tính khoảng cách ngày đến hiện tại
        public int KhoangCachNgay()
        {
            DateTime ngayBatDau = new DateTime(year, month, day);

            DateTime ngayHienTai = DateTime.Today;

            return (ngayHienTai - ngayBatDau).Days;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Tạo đối tượng Date theo ngày hệ thống
            Date ngayHT = new Date();

            Console.WriteLine("Ngay hien tai:");
            ngayHT.HienThi();

            // Nhập ngày bắt đầu
            Date ngayBatDau = new Date();

            Console.WriteLine("\nNhap ngay bat dau:");
            ngayBatDau.Nhap();

            // Hiển thị ngày đã nhập
            Console.WriteLine("\nNgay bat dau:");
            ngayBatDau.HienThi();

            // Tính khoảng cách ngày
            Console.WriteLine("\nKhoang cach den ngay hien tai: {0} ngay",
                ngayBatDau.KhoangCachNgay());

            // Tăng ngày lên 1
            Console.WriteLine("\nSau khi tang 1 ngay:");
            ngayBatDau.NextDay();
            ngayBatDau.HienThi();

            Console.ReadKey();
        }
    }
}
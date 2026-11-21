using System;
using System.Text;

namespace Bài_1
{
    // Tạo lớp Stack
    class Stack
    {
        // Tạo mảng lưu hệ số 16
        private char[] HeSo16;

        // Tạo phần tử đỉnh Stack
        private int Top;

        // Khai báo dung lượng chứa
        private int ToiDa;

        // Khởi tạo có tham số
        public Stack(int ToiDa)
        {
            this.ToiDa = ToiDa > 0 ? ToiDa : 64;
            this.HeSo16 = new char[this.ToiDa];
            this.Top = -1;
        }

        // Kiểm tra Stack rỗng
        public bool KiemTraRong()
        {
            return this.Top == -1;
        }

        // Kiểm tra Stack đầy
        public bool KiemTraDay()
        {
            return this.Top == this.ToiDa - 1;
        }

        // Thêm kí tự vào đỉnh Stack
        public bool ThemKiTu(char ch)
        {
            if (KiemTraDay())
            {
                return false;
            }

            this.Top++;
            this.HeSo16[this.Top] = ch;
            return true;
        }

        // Lấy và xóa kí tự ở đỉnh Stack
        public char LayVaXoa()
        {
            if (KiemTraRong())
            {
                throw new InvalidOperationException("Stack rỗng! Không thể lấy phần tử.");
            }

            char value = this.HeSo16[this.Top];
            this.Top--;
            return value;
        }

        // Xóa dữ liệu hiện tại
        public void Xoa()
        {
            this.Top = -1;
        }
    }

    // Tạo lớp Hexa
    class Hexa
    {
        // Khởi tạo số nguyên n
        private int n;

        // Đối tượng lưu hệ số 16
        private Stack s;

        // Kết quả sau khi chuyển thành công
        private string KetQua;

        // Khởi tạo mặc định
        public Hexa() : this(0, 64)
        {
        }

        // Khởi tạo có tham số
        public Hexa(int n, int StackToiDa)
        {
            this.n = n;
            this.s = new Stack(StackToiDa);
            this.KetQua = string.Empty;
        }

        // Chuyển số dư thành kí tự hệ 16
        private char ChuyenDoiHeSo16(int du)
        {
            if (du >= 0 && du <= 9)
            {
                return (char)('0' + du);
            }

            return (char)('A' + (du - 10));
        }

        // Nhập số nguyên
        public void Nhap()
        {
            while (true)
            {
                Console.Write("Nhập số nguyên dương cơ số 10: ");

                string input = Console.ReadLine();

                int value;

                if (int.TryParse(input, out value) && value >= 0)
                {
                    this.n = value;
                    break;
                }

                Console.WriteLine("Giá trị không hợp lệ! Vui lòng nhập lại!");
            }
        }

        // Chuyển hệ số 10 sang hệ 16
        public void ChuyenCoSo()
        {
            // Xóa Stack để làm rỗng
            this.s.Xoa();

            this.KetQua = string.Empty;

            // Gán n cho biến tạm
            int tam = this.n;

            if (tam == 0)
            {
                this.s.ThemKiTu('0');
            }
            else
            {
                while (tam > 0)
                {
                    int du = tam % 16;

                    char kyTu = ChuyenDoiHeSo16(du);

                    if (!this.s.ThemKiTu(kyTu))
                    {
                        throw new InvalidOperationException("Stack đã đầy!");
                    }

                    tam /= 16;
                }
            }

            // Lấy phần tử ra khỏi Stack theo nguyên tắc LIFO
            char[] buffer = new char[this.s.KiemTraRong() ? 1 : 64];

            int index = 0;

            while (!this.s.KiemTraRong())
            {
                buffer[index] = this.s.LayVaXoa();
                index++;
            }

            this.KetQua = new string(buffer, 0, index);
        }

        // Hiển thị kết quả
        public void HienThi()
        {
            Console.WriteLine("Hệ số 10: {0}", this.n);
            Console.WriteLine("Hệ số 16: {0}", this.KetQua);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Hỗ trợ hiển thị tiếng Việt
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            Hexa converter = new Hexa();

            converter.Nhap();

            converter.ChuyenCoSo();

            converter.HienThi();

            Console.ReadKey();
        }
    }
}
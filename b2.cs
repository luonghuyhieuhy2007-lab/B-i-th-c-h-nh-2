using System;

namespace Bài_2
{
    // Tạo lớp phân số
    class PS
    {
        // Khai báo tử số
        private int TuSo;

        // Khai báo mẫu số
        private int MauSo;

        // Khởi tạo mặc định phân số bằng 0
        public PS()
        {
            this.TuSo = 0;
            this.MauSo = 1;
        }

        // Khởi tạo có 2 tham số
        public PS(int TuSo, int MauSo)
        {
            if (MauSo == 0)
                throw new ArgumentException("Mẫu số không được bằng 0!");

            this.TuSo = TuSo;
            this.MauSo = MauSo;

            ChuanHoa();
        }

        // Khởi tạo từ một đối tượng phân số khác
        public PS(PS ps)
        {
            this.TuSo = ps.TuSo;
            this.MauSo = ps.MauSo;
        }

        // Phương thức tìm UCLN (private)
        private int TimUCLN(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (b != 0)
            {
                int tam = a % b;
                a = b;
                b = tam;
            }

            return a;
        }

        // Phương thức chuẩn hóa phân số
        public void ChuanHoa()
        {
            int ucln = TimUCLN(TuSo, MauSo);

            if (ucln != 0)
            {
                TuSo /= ucln;
                MauSo /= ucln;
            }

            // Đưa dấu âm lên tử số
            if (MauSo < 0)
            {
                TuSo = -TuSo;
                MauSo = -MauSo;
            }
        }

        // Phương thức cộng hai phân số
        public PS Cong(PS ps)
        {
            int tu = this.TuSo * ps.MauSo
                   + ps.TuSo * this.MauSo;

            int mau = this.MauSo * ps.MauSo;

            return new PS(tu, mau);
        }

        // Phương thức trừ hai phân số
        public PS Tru(PS ps)
        {
            int tu = this.TuSo * ps.MauSo
                   - ps.TuSo * this.MauSo;

            int mau = this.MauSo * ps.MauSo;

            return new PS(tu, mau);
        }

        // Phương thức nhân hai phân số
        public PS Nhan(PS ps)
        {
            int tu = this.TuSo * ps.TuSo;
            int mau = this.MauSo * ps.MauSo;

            return new PS(tu, mau);
        }

        // Phương thức chia hai phân số
        public PS Chia(PS ps)
        {
            if (ps.TuSo == 0)
                throw new DivideByZeroException("Không thể chia cho phân số 0!");

            int tu = this.TuSo * ps.MauSo;
            int mau = this.MauSo * ps.TuSo;

            return new PS(tu, mau);
        }

        // Phương thức so sánh hai phân số (private)
        private bool SoSanh(PS ps)
        {
            return (long)this.TuSo * ps.MauSo
                == (long)ps.TuSo * this.MauSo;
        }

        // Phương thức kiểm tra hai phân số bằng nhau
        public bool KiemTraBangNhau(PS ps)
        {
            return SoSanh(ps);
        }

        // Phương thức in phân số
        public void HienThi()
        {
            Console.WriteLine("{0}/{1}", this.TuSo, this.MauSo);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // Tạo hai phân số
            PS ps1 = new PS(2, 3);
            PS ps2 = new PS(4, 6);

            Console.WriteLine("Phan so thu nhat:");
            ps1.HienThi();

            Console.WriteLine("Phan so thu hai:");
            ps2.HienThi();

            // Cộng
            Console.Write("Cong: ");
            PS tong = ps1.Cong(ps2);
            tong.HienThi();

            // Trừ
            Console.Write("Tru: ");
            PS hieu = ps1.Tru(ps2);
            hieu.HienThi();

            // Nhân
            Console.Write("Nhan: ");
            PS tich = ps1.Nhan(ps2);
            tich.HienThi();

            // Chia
            Console.Write("Chia: ");
            PS thuong = ps1.Chia(ps2);
            thuong.HienThi();

            // Kiểm tra bằng nhau
            if (ps1.KiemTraBangNhau(ps2))
            {
                Console.WriteLine("Hai phan so bang nhau!");
            }
            else
            {
                Console.WriteLine("Hai phan so khong bang nhau!");
            }

            Console.ReadKey();
        }
    }
}
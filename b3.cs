using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Bài_3
{
    //tạo lớp queue
    class Queue
    {
        //khai báo mảng chứa phần tử
        private int[] phantu;
        //vị trí phần tử đầu
        private int dau;
        //vị trí phần tử cuối
        private int cuoi;
        //khởi tạo queue có tối đa n phần tử
        public Queue(int n)
        {
            phantu = new int[n];
            dau = 0;
            cuoi = 0;
        }

        //kiêm tra rỗng
        public bool KiemTraRong()
        {
            return dau == cuoi;
        }

        //kiểm tra đầy
        public bool KiemTraDay()
        {
            return cuoi >= phantu.Length;
        }

        //thêm phần tử vào queue
        public void Push(int x)
        {
            if (KiemTraDay())
            {
                Console.WriteLine("Queue đầy! Không thể thêm nữa.");
                return;
            }
            phantu[cuoi] = x;
            cuoi++;
        }

        //lấy phần tử ra
        public int Pop()
        {
            if (KiemTraRong())
            {
                throw new InvalidCastException("Queue rỗng!");
            }
            int x = phantu[dau];
            dau++;
            return x;
        }

        //hiển thị
        public void HienThi()
        {
            if (KiemTraRong())
            {
                Console.WriteLine("Queue rỗng!");
                return;
            }
            Console.WriteLine("Các phần tử trong Queue: ");
            for (int i = dau; i < cuoi; i++)
            {
                Console.WriteLine(phantu[i]+" ");
            }
            Console.WriteLine();
        }
        
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.UTF8;
            Console.OutputEncoding = Encoding.Unicode;
            //khởi tạo queue 5 phần tử
            Queue q = new Queue(5);

            q.Push(10);
            q.Push(20);
            q.Push(30);
            q.Push(40);

            q.HienThi();

            Console.WriteLine("Phần tử lấy ra: "+ q.Pop());
            q.HienThi();

            q.Push(50);
            q.HienThi();
            Console.ReadKey();
        }
    }
}

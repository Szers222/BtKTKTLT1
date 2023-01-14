using System.Net.NetworkInformation;

namespace bai_kiem_tra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int num;
            int[] arr;
            string nhap;
            int timSoMax;
            int nhapX;
            int[] themMotPhanTu;
            int soNguyenToDauTien;
            do
            {
                Console.WriteLine("Nhap kich thuoc mang:");
                nhap = Console.ReadLine();
                int.TryParse(nhap, out num);
            } while (num < 1 || num > 50);
            //Nhap mang
            arr = NhapMang(num);

            //Xuat mang
            Console.WriteLine("Mang vua nhap la:");
            XuatMang(arr);

            //Tim gia tri lon nha trong mang
            timSoMax = TimSoMax(arr);
            Console.WriteLine($"\nSo lon nha trong mang la: {timSoMax}");

           

            //Them mot phan tu dau mang:
            nhapX = NhapX();
            themMotPhanTu = ThemMotPhanTuDauMang(arr, nhapX);
            Console.WriteLine("\nMang da duoc them vao 1 phan tu vi tri dau tien:");
            XuatMang(themMotPhanTu);

            //So Nguyen To Dau Tien
            soNguyenToDauTien = TimSoNguyenToDauTien(themMotPhanTu);
            Console.WriteLine($"\nSo Nguyen To Dau Tien la : {soNguyenToDauTien}");

        }
        static int[] NhapMang(int arrLength)
        {
            int[] result = new int[arrLength];
            string nhap;
            for (int i = 0; i < arrLength; i++)
            {
                do
                {
                    Console.Write($"So phan tu thu {i}  : ");
                    nhap = Console.ReadLine();
                } while (!int.TryParse(nhap, out result[i]));
            }
            return result;
        }
        static void XuatMang(int[] arr)
        {
            foreach (int item in arr)
            {
                Console.Write(item + "\t");
            }
        }
        static int TimSoMax(int[] arr)
        {
            int result = int.MinValue;
            foreach (int item in arr)
            {
                if (item > result)
                {
                    result = item;
                }
            }
            return result;
        }
        static int[] ThemMotPhanTuDauMang(int[] arr, int num)
        {
            int[] result = new int[0];
            bool isFirst = true;
            foreach (int item in arr)
            {
                if (isFirst)
                {
                    Array.Resize(ref result, result.Length + 1);
                    result[result.Length - 1] = num;
                    isFirst = false;
                }
                Array.Resize(ref result, result.Length + 1);
                result[result.Length - 1] = item;
            }
            return result;
        }
        static int NhapX()
        {
            int result;
            string nhap;
            do
            {
                Console.WriteLine("\nNhap X:");
                nhap = Console.ReadLine();
            } while (!int.TryParse(nhap, out result));
            return result;
        }
        static bool KiemTraSoNguyenTo(int num)
        {
            bool result = num > 1;

            for (int i = 2; i < num; i++)
            {
                if (num % i == 0)
                {
                    result = false;
                }
            }
            return result;
        }
        static int TimSoNguyenToDauTien(int[] arr)
        {
            int result = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (KiemTraSoNguyenTo(arr[i]))
                {
                    result = arr[i];
                    break;
                }
            }
            return result;
        }
    }
}
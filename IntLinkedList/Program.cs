using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntLinkedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IntLinkedList   intList  = new IntLinkedList();
            intList.Input();
            Console.WriteLine("Gia tri trong danh sach vua nhap la: ");
            intList.Output();

            //Console.WriteLine();
            //Console.WriteLine("So luong phan tu: " + intList.DemSL());

            //Console.WriteLine();
            //Console.WriteLine("Phan tu lon nhat: " + intList.TimMax().Data);

            //Console.WriteLine();
            //Console.Write("Nhap gia tri x: ");
            //int x = int.Parse(Console.ReadLine());
            //Console.WriteLine("Phan tu node co gia tri x la(neu khong co tra ve first): " + intList.TimX(x).Data);

            //Console.WriteLine();
            //Console.WriteLine("Cac node chan: ");
            //intList.InChan();

            //Console.WriteLine();
            //Console.WriteLine("So luong phan tu le: " + intList.DemLe());
            //Console.WriteLine("Trung binh cong cac node le: " + intList.TBLe());

            //Console.WriteLine();
            //IntNode p = new IntNode(2);
            //IntNode newNode = new IntNode(10);
            //intList.InsertAfterP(p, newNode);

            //Console.WriteLine();
            //Console.WriteLine("test thu hoan vi");
            //intList.HoanVi(p, newNode);

            //Console.WriteLine();
            //intList.InsertBeforeP(p, newNode);

            //intList.DaoNguoc();

            //Console.WriteLine();
            //intList.ChenXsauY(1000, 4);
            //intList.Output();

            //Console.WriteLine();
            //intList.ChenXtruocMin(2000);

            intList.XoaMin();
            

        }
    }
}

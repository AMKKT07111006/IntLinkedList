using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IntLinkedList
{
    public class IntLinkedList
    {
        private IntNode first = null;   
        private IntNode last = null;

        public IntNode Firs 
        { 
            get { return first; } 
            set { first = value; }
        }

        public IntNode Last
        {
            get { return last; }
            set {  last = value; }
        }

        public IntLinkedList() { }
        public IntLinkedList(IntNode first, IntNode last)
        {
            this.first = first;
            this.last = last;
        }

        public bool IsEmpty()
        {
            return first == null;
        }

        public void InsertFirst(IntNode newNode)
        {
            if(IsEmpty())
            {
                first = last = newNode;
            }
            else
            {
                newNode.Next = first;
                first = newNode;
            }
        }

        public void InsertLast(IntNode newNode)
        {
            if (IsEmpty())
            {
                first = last = newNode;
            }
            else
            {
                last.Next = newNode;
                last = newNode;
            }
        }

        public void Input()
        {      
            do
            {
                Console.Write("Nhap vo so nguyen duong (Nhap 0 se ket thuc): ");
                int x = int.Parse(Console.ReadLine());
                if (x <= 0)
                {
                    break;
                }
                else
                {
                    IntNode newNode = new IntNode(x);
                    InsertFirst(newNode);
                }
            } while (true);
        }
   
        public void Output()
        {
            IntNode p = first;
            while (p != null)
            {
                Console.Write(p.Data + "->");
                p = p.Next;
            }
            Console.WriteLine(" ");
        }

        public int DemSL()
        {
            int dem = 0;
            IntNode p = first;
            while (p != null)
            {
                dem++;
                p = p.Next;
            }
            return dem;
        }

        public IntNode TimMax()
        {
            IntNode max = first;
            IntNode p = first.Next;
            while (p != null)
            {
                if(max.Data < p.Data )               
                    max = p;
                p = p.Next;               
            }
            return max;
        }

        public IntNode TimX(int x)
        {          
            IntNode p = first.Next;
            while (p != null)
            {
                if (p.Data == x)
                    return p;
                p = p.Next;
            }
            return first;
        }

        public void InChan()
        {
            IntNode p = first;
            while (p != null)
            {
                if(p.Data % 2 == 0)
                {
                    Console.Write(p.Data + " ");
                }           
                p = p.Next; 
            }
            Console.WriteLine(" ");
        }

        public int DemLe()
        {
            int dem = 0;
            IntNode p = first;
            while (p != null)
            {
                if (p.Data % 2 != 0)
                    dem++;
                p = p.Next;
            }
            return dem;
        }

        public double TBLe()
        {
            IntNode p = first;
            double tb = 0;
            int sum = 0;
            while (p != null)
            {
                if (p.Data % 2 != 0)
                {
                    sum = sum + p.Data;
                    tb = sum / DemLe();
                }
                p = p.Next;
            }
            return tb;
        }

        //Chen newNode vao sau node p
        public void InsertAfterP(IntNode p, IntNode newNode)
        {            
            if(p == last)
            {
                InsertLast(newNode);
            }
            else
            {              
                newNode.Next = p.Next;
                p.Next = newNode;             
            }            
        }

        //Chen newNode vao truoc node p
        public void HoanVi(IntNode a, IntNode b)
        {
            int tam = a.Data;
            a.Data = b.Data;
            b.Data = tam;
            Console.WriteLine(a.Data + " " + b.Data);
        }
        public void InsertBeforeP(IntNode p, IntNode newNode)
        {
            InsertAfterP(p, newNode);
            HoanVi(p, newNode);
        }

        public void DaoNguoc()
        {
            IntNode p = first;
            IntNode prev = null; //Node truoc p
            IntNode countinue = null; //Node sau p

            while(p != null)
            {
                countinue= p.Next;
                p = prev.Next;
                prev = p.Next;

                Console.Write(p.Data + "->");
                p = p.Next;
            }              
        }

        //Chèn sau ptu nhỏ nhất
        public IntNode TimMin()
        {
            IntNode min = first;
            IntNode p = first.Next;
            while (p != null)
            {
                if (min.Data > p.Data)
                    min = p;
                p = p.Next;
            }
            return min;
        }

        public void ChenSauMin(int x)
        {
            IntNode min = TimMin();
            InsertAfterP(min, new IntNode(x));
        }

        //Chèn thêm x vào sau ptu mang giá trị y
        //Hàm tìm Y đã có(TimX())
        public void ChenXsauY(int x, int y)
        {
            IntNode pY = TimX(y);
            if (pY == null)
                InsertFirst(new IntNode(x));
            else
                InsertAfterP(pY, new IntNode(x));
        }

        //Chèn X trước giá trị Min
        public void ChenXtruocMin(int x)
        {
            IntNode min = TimMin();
            InsertBeforeP(min, new IntNode(x));
        }

        //Xóa node
        //Trường hợp lưu ý: Node cần xóa là Last
        public IntNode TimpTruoc(IntNode p)
        {
            IntNode pTruoc = new IntNode();

            if (p == first)
                return null;
            else
            {
                pTruoc = first;
                while(pTruoc.Next != null)
                {
                    pTruoc = pTruoc.Next;
                }    
            }
            return pTruoc;                
        }

        //Trường hợp lưu ý: Chỉ có 1 node (First = Last)
        public void XoaP(IntNode p)
        {
            if (first == last)
                first = last = null;
            else if(p == last)
            {
                IntNode pTruoc = TimpTruoc(p);
                pTruoc.Next = null;
                last = pTruoc; //Cập nhật lại last sau khi xóa 
            }    
            else
            {
                IntNode pSau1 = p.Next;
                IntNode pSau2 = pSau1.Next;

                p.Data = pSau1.Data;
                p.Next = pSau2;
                p = pSau1;
            }    
            p = null;
        }

        //Xóa node có giá trị X xuất hiện đầu tiên trong ds
        public bool XoaNodeX(int x)
        {
            IntNode pX = TimX(x);

            if (pX == null)
                return false;
            else
                XoaP(pX);
            return true;
        }

        //Xóa node Min
        public void XoaMin()
        {
            IntNode min = TimMin();

            XoaP(min);           
        }

        //Sắp xếp Selection Sort
        //Tìm Min từ p đến cuối
        public IntNode TimMin(IntNode p)
        {
            IntNode min = p;
            IntNode q = p.Next;

            while (q != null)
            {
                if (min.Data > q.Data)
                {
                    min = q;
                    q = q.Next;
                }
            }
            return min;
        }
        public void SelectionSort()
        {
            IntNode p = first;
            while (p != null)
            {
                IntNode pMin = TimMin(p);
                HoanVi(p, pMin);
                p = p.Next;
            }
        }
        }
}

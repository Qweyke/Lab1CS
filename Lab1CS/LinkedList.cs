using System;
using System.Diagnostics;
using System.Reflection;


namespace Lab1CS
{
    public class ChainList
    {
        public class Node //private?
        {
            public int Data
            {
                set; get;
            }
            public Node Next
            {
                set; get;
            }
            public Node(int data)
            {
                Data = data;
                Next = null;
            }
        }

        Node head = null;
        int count = 0; // 0 pos 1 elem

        public Node Find(int posit)
        {
            if (posit >= count) return null;

            int i = 0;
            Node P = head;

            while (P != null && i < posit)
            {
                P = P.Next;
                i++;
            }

            if (i == count) return P;
            else return null;
        }
        public void Addit(int value)
        {
            if (head == null)
            {
                head = new Node(value);
            }

            else
            {
                Node last = Find(count - 1);
                last.Next = new Node(value);

            }
            count++;
        }
        public void Insert(int posit, int value)
        {
            if (posit < 0 || posit > count)
            {
                throw new ArgumentOutOfRangeException($"Invalid position {posit} for insertion");
            }

            if (posit <= count && head != null)
            {
                Node prev = Find(posit - 1);
                Node old_next = prev.Next;
                Node new_next = new Node(value);
                prev.Next = new_next;
                new_next.Next = old_next;
                count++;
            }
            else if (head == null)
            {
                head = new Node(value);
                count++;
            }

        }
        public void Delete(int posit)
        {
            if (posit < 0 || posit >= count)
            {
                throw new ArgumentOutOfRangeException($"Invalid position {posit} for deletion");
            }

            if (posit < count && posit > 0)
            {
                Node prev = Find(posit - 1);
                Node GoodBye = Find(posit);
                prev.Next = GoodBye.Next;
                count--;
            }
            else if (posit == 0 && head != null)
            {
                head = null;
                count--;
            }
        }
        public void Clr()
        {
            while (count != 0)
            {
                Node vanished = Find(count - 1);
                vanished.Next = null;
                count--;
            }
            head = null;
        }
        public int Count
        {
            get { return count; }
        }

        public int this[int i]
        {
            get
            {
                if (count <= i || i < 0)
                {
                    throw new IndexOutOfRangeException($"There is no index {i} in list");
                }

                Node th = Find(i);

                return th.Data;
            }

            set
            {
                if (count <= i || i < 0)
                {
                    throw new IndexOutOfRangeException($"There is no index {i} in list");
                }

                Node th = Find(i);
                th.Data = value;
            }
        }
        public void Shw()
        {
            Node cur = head;
            while (cur != null)
            {
                Console.Write($"{cur.Data} ");
                cur = cur.Next;
            }
        }
    }
}

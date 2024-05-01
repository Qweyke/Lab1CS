using System;
using System.Collections.Generic;

namespace Lab1CS
{
    public class DoublyList
    {
        public class Node
        {
            public Node Prev
            {
                set; get;
            }
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
                Prev = null;
                Data = data;
                Next = null;
            }
        }

        readonly CompanionList<Node> cmpn = new CompanionList<Node>();

        Node head = null;
        int count = 0; 

        public const int interval = 50; // each 50-th elem
        public const int interval_pos = 49; // each 50-th elem position

        public Node Find(int posit)
        {
            if (posit >= count || head == null) return null;

            else if (posit == 0 && count != 0) return head;
            
            else
            {
                int cmpn_index = posit / interval;
                int left_end = cmpn.GetPos(cmpn_index); // position of the closest interval
                Node target = cmpn[left_end]; // closest left-side interval L...r

                if (cmpn_index + 1 < cmpn.Count) // if right end exists 
                {
                    int mid_point = (left_end + (left_end + interval)) / 2;
                    if (cmpn_index == 0) mid_point = interval_pos / 2;

                    if (posit > mid_point) // closest is right end - backward mov
                    {
                        int right_end = cmpn.GetPos(cmpn_index + 1);
                        target = cmpn[right_end];
                        for (int i = right_end; i > posit; i--) 
                        {
                            target = target.Prev;
                        }
                        return target;                       
                    }
                }

                for (int i = left_end; i < posit; i++) // forward movement if no right end or left is closest
                {
                    target = target.Next;
                }
                return target;
            }             
        }
        public void Add(int value)
        {
            if (head == null)
            {
                head = new Node(value);
                cmpn.Append(head, count);
                count++;
            }

            else
            {
                Node last = Find(count - 1);
                Node newbie = new Node(value) { Prev = last };
                last.Next = newbie;
                count++;
                if (count % interval == 0)
                {
                    cmpn.Append(newbie, count - 1);
                }
                if (count % interval == 1)
                {
                    cmpn[(count - 2)] = newbie.Prev;
                }
            }
        }
        public void Insert(int value, int posit)
        {
            if (posit == 0 && posit == count ) Add(value); // head != null??

            else if (posit == count) Add(value);

            else if (posit < count)
            {
                
            }
        }
        public void Delete(int posit)
        {
            
            if (posit == 0 && count == 1)
            {
                head = null;
                count--;
                cmpn.Delete(posit);
            }

            else if (posit == 0 && posit < count)
            {
                //Shift(posit);
                head = head.Next;
                head.Prev = null;
                count--;
            }

            else if (posit > 0 && posit < count)
            {              
                Node prev = Find(posit - 1);
                //Erase(posit);
                Node current = prev.Next;
                prev.Next = current.Next;

                if (current.Next != null)
                {
                    Node next = current.Next;
                    next.Prev = prev;
                }
                count--;
            }         
        }
        public void Clear()
        {
            head = null;
            count = 0;
        }
        public int Count
        {
            get { return count; }
        }

        public int this[int i]
        {
            get
            {
                if (i >= count || i < 0) return 0;

                Node shw = Find(i);
                return shw.Data;
            }

            set
            {
                if (i >= count || i < 0) return;

                Node st = Find(i);
                st.Data = value;
            }
        }
        public void Show()
        {
            Node cur = head;
            if (cur != null)
            {
                while (cur.Next != null)
                {
                    Console.Write($"{cur.Data}; ");
                    cur = cur.Next;
                }
                Console.Write($"{cur.Data}. ");
            }
            else Console.WriteLine("Нет элементов в DoublyLinked листе");
        }

        /*private void Shift(int pos_e)
        {
            int after = pos_e / interval;
            for (int i = after; i < ; i++) { }
        }*/
    }
}

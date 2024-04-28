using System;

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

        readonly BrwsList<Node> brwsr = new BrwsList<Node>();
        Node head = null;
        int count = 0; // pos < cnt if head != null
        readonly int finder = 50;

        public Node Find(int posit)
        {
            if (posit >= count || head == null) return null; //if no el rtrn nthng

            else
            {

            }
        }
        public void AddDb(int value)
        {
            if (head == null)
            {
                head = new Node(value);
                brwsr.Add(head);
                count++;
            }

            else
            {
                Node last = Find(count - 1);
                Node fresh = new Node(value) { Prev = last };
                last.Next = fresh; 
                count++;
                if (count % finder == 0)
                {
                    brwsr.Add(fresh);
                } 
            }

        }
        public void Insert(int value, int posit)
        {
            if (posit == count && posit == 0) AddDb(value);

            else if (posit == count) AddDb(value);

            else if (posit < count)
            {
                if (posit == 0)
                {
                    Node old = Find(posit);
                    head = new Node(value) { Next = old };
                    old.Prev = head;
                    count++;

                    brwsr[0] = head;
                    for (int i = 1; i < brwsr.Count; i++)                    
                    {
                        Node temp = brwsr[i];
                        brwsr[i] = temp.Prev;
                    }

                    if (count % finder == 0)
                    {
                        brwsr.Add(null);
                        Node fresh = Find(count * finder);
                        brwsr[brwsr.Count - 1] = fresh;
                    }
                }

                else
                {
                    Node prev = Find(posit - 1);
                    Node old = Find(posit);
                    Node insr = new Node(value) { Next = old, Prev = prev };
                    prev.Next = insr;
                    old.Prev = insr;
                    count++;

                    if (count % finder == 0)
                    {
                        brwsr.Add(null);
                        for (int i = (posit / finder) + 1; i < brwsr.Count - 1; i++)
                        {
                            Node temp = brwsr[i];
                            brwsr[i] = temp.Prev;
                        }
                        Node fresh = Find(count * finder);
                        brwsr[brwsr.Count - 1] = fresh;
                    }

                    else 
                    for (int i = (posit / finder) + 1; i < brwsr.Count; i++)
                    {
                        Node temp = brwsr[i];
                        brwsr[i] = temp.Prev;
                    }
                }
            }
        }
        public void Delete(int posit)
        {
            if (posit < count && posit > 0)
            {
                Node prev = Find(posit - 1);
                Node current = prev.Next;
                prev.Next = current.Next;
                if (current.Next != null)
                {
                    Node next = current.Next;
                    next.Prev = prev;
                }
                count--;
            }

            else if (posit == 0 && posit < count)
            {                    
                head = head.Next;
                if (head.Next != null)
                {
                    Node next = head.Next;
                    next.Prev = head;
                }                    
                count--;
            }

            else if (posit == 0 && count == 1)
            {
                head = null;
                count--;
            }
        }
        public void Clear()
        {
            head = null;
            count = 0;
            brwsr.Clr();
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
    }
}

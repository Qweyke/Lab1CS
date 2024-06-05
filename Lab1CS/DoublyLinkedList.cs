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
        Node tail = null;
        
        int count = 0; 

        public const int interval = 50; // each 50-th elem
        public const int interval_pos = 49; // each 50-th elem position

        public Node Find(int posit)
        {
            if (posit >= count || head == null) return null;

            else if (posit == 0 && count != 0) return head;

            else
            {
                int closest_direction = cmpn.FindClosest(posit); // direction depends on the sign 
                int closest_pos = Math.Abs(closest_direction); // pos without sign
                Node target_el = cmpn.GetNode(closest_pos); // closest el

                if (closest_direction < 0)
                {
                    for (int i = closest_pos; i > posit; i--)
                    {
                        target_el = target_el.Prev;
                    }
                }
                else
                {
                    for (int i = closest_pos; i < posit; i++)
                    {
                        target_el = target_el.Next;
                    }               
                }
                return target_el;
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
                if ((count - 1) % interval == 0)
                {
                    cmpn.SetNode(newbie.Prev, (count - 2));
                }
            }
        }
        public void Insert(int value, int posit)
        {           
            if (posit == count) Add(value);
            else if (posit < count)
            {
                if ((count + 1) % interval == 0) // check for new elem in cmpn
                {
                    tail = Find(count - 1);
                }

                if (posit == 0)
                {
                    head = new Node(value) { Next = head };
                    head.Next.Prev = head;
                    cmpn[0] = head;
                    ShiftForward(posit);
                    count++;
                }
                else
                {
                    Node prev = Find(posit - 1);
                    Node curr = Find(posit);
                    Node insr = new Node(value) { Next = curr, Prev = prev };
                    prev.Next = insr;
                    curr.Prev = insr;

                    if ((posit + 2) % interval == 0 && count >= posit + 2) // update 49 if pos 48 e.g. 
                    {
                        cmpn.SetNode(curr.Next, posit + 1); // 
                    }

                    if (posit % interval == 0) // no update in shift // 50 pos
                    {
                        cmpn.SetNode(prev, posit - 1);
                    }

                    if ((posit + 1) % interval == 0) //if posit == 49 
                    {
                        if (count == (posit + 1))
                        {
                            cmpn.SetNode(insr, posit);
                            count++;
                            tail = null;
                            return;
                        }
                        cmpn.SetNode(curr, posit); // 48 to 49 place 
                    }
                    ShiftForward(posit);
                    count++;
                }
            }
        }
        private void ShiftForward(int posit)
        {
            int shift_index = (posit / interval) + 1; // 1 index after shift

            for (int i = shift_index; i < cmpn.Count; i++)
            {
                cmpn[i] = cmpn[i].Prev;
            }

            if ((count + 1) % interval == 0) // add elem in companion 
            {
                cmpn.Append(tail, count);
            }             
        }
        public void Delete(int posit)
        {
            
            if (posit == 0 && count == 1)
            {
                head = null;
                cmpn.Delete(0);
                count--;
            }

            else if (posit == 0 && posit < count)
            {
                head = head.Next;
                head.Prev = null;
                cmpn[0] = head;
                Shift(posit);
                count--;
            }

            else if (posit > 0 && posit < count)
            {              
                Node deleted = Find(posit);               
                Node previous = deleted.Prev;
                previous.Next = deleted.Next;
                if (previous.Next != null)
                {
                    Node new_current = previous.Next;
                    new_current.Prev = previous;

                    if ((posit + 2) % interval == 0 && count >= posit + 2) // update 49 if pos 48 e.g. // good
                    {
                        cmpn.SetNode(new_current, posit + 1); // 48 to 49 place
                    }
                    if ((posit + 1) % interval == 0) //if posit == 49 // good
                    {
                        cmpn.SetNode(previous, posit); // 48 to 49 place 
                    }
                }            
                if (posit % interval == 0) // update 49 if pos 50 e.g. // good
                {
                    cmpn.SetNode(previous, posit - 1);
                }

                if ((posit + 1) % interval == 0 && count == (posit + 1)) // if pos 49 , 149 etc
                {
                    cmpn.Delete(cmpn.Find(posit));
                    count--;
                    return;
                }
                Shift(posit);
                count--;
            }         
        }       
        private void Shift(int posit)
        {
            int shift_index = (posit / interval) + 1; // 1 index after shift
                                                      
            if (count % 50 == 0) // delete elem in companion 
            {
                cmpn.Delete(cmpn.Count - 1);
            }

            for (int i = shift_index; i < cmpn.Count; i++)
            {
                cmpn[i] = cmpn[i].Next;
            }
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
        public void Clear()
        {
            head = null;
            cmpn.Clear();
            count = 0;
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

using System;
using System.Xml;

namespace Lab1CS
{
    class CompanionList<T>
    {       
        public struct Element
        {
            public T Node { get; set; }
            public int Pos { get; set; }
            public Element(T node, int pos)
            {
                Node = node;
                Pos = pos; 
            }
        }

        const int interval = DoublyList.interval;
        int cnt = 0;
        Element[] buf = null;
        int size = 1;


        private int Find(int pos) 
        {
            int mid = cnt / 2; 
            bool found = false;
            while (!found)
            {
                if (buf[mid].Pos == pos) found = true;
                else if (pos > mid)
                {
                    mid = (mid + cnt) / 2;
                }
                else mid /= 2;
            }
            return mid;
        }
        public CompanionList()
        {
            buf = new Element[size];
        }
        public T this[int index]
        {
            get
            {
                if (index == 0) return buf[index].Node; 

                else if (index < cnt * interval)
                {
                    return buf[Find(index)].Node;
                }
                else return default; 
            }

            set
            {
                buf[Find(index)].Node = value;
                buf[Find(index)].Pos = index;
            }
        }
        public int GetPos(int pos)
        {
            return buf[pos].Pos;
        }

        private void Expand()
        {
            size *= 2;
            Array.Resize(ref buf, size);            
        }
        public void Append(T elem, int pos)
        {
            if (cnt >= size) Expand();
            buf[cnt] = new Element(elem, pos);
            cnt++;
        }     
        public void Delete(int pos) 
        {
            int index = Find(pos);
            if (index == cnt - 1) 
            {
                buf[index] = default;
                cnt--;
            }
            else Console.WriteLine("Wrong del comp");
        }
        public void Clear()
        {
            for (int i = 0; i < cnt; i++)
            {
                buf[i] = default;
            }
            cnt = 0;
        }
       
    }
}

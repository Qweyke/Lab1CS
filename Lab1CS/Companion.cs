using System;
using System.Reflection;
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
        public int Find(int pos) 
        {
            if (pos == 0) return 0;
            else
            {
                int low = 0;
                int high = cnt - 1;
                while (low <= high)
                {
                    int mid = low + (high - low) / 2;
                    if (buf[mid].Pos == pos)
                    {
                        return mid;
                    }
                    else if (buf[mid].Pos < pos)
                    {
                        low = mid + 1;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }
            throw new IndexOutOfRangeException("trouble in find companion");
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

                else if (index < cnt)
                {
                    return buf[index].Node;
                }
                else throw new IndexOutOfRangeException("Indexator trouble"); 
            }

            set
            {
                if (index < cnt)
                { 
                    buf[index].Node = value;
                }
                else throw new IndexOutOfRangeException("Indexator set pos trouble");
            }
        }
        public int GetPos(int pos)
        {
            return buf[pos].Pos;
        }
        public T GetNode(int pos)
        {
            return buf[Find(pos)].Node;
        }
        public void SetNode(T node, int pos)
        {
            buf[Find(pos)].Node = node;
            buf[Find(pos)].Pos = pos;
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
        public void Delete(int index) 
        {           
            if (index == cnt - 1) 
            {
                buf[index] = default;
                cnt--;
            }
            else throw new IndexOutOfRangeException("not last el was deleted");
        }
        public int Count
        {
            get { return cnt; }
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

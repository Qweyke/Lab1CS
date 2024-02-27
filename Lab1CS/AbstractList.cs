using System;

namespace Lab1CS
{
    class ArrList
    {
        int cnt = 0;
        int[] buf = null;
        int size = 1;
        public void Init()
        {
            buf = new int[size];
        }

        private void Expd()
        {
            size *= 2;
            Array.Resize(ref buf, size);
        }

        public void Add(int val)
        {
            if (cnt >= size) { Expd(); }
            buf[cnt] = val;
            cnt++;

        }
        public void Ins(int val, int pos)
        {

            if (pos < 0 || pos > cnt)
            {
                throw new ArgumentOutOfRangeException($"Invalid position {pos} for insertion");
            }

            if (pos <= cnt && pos >= 0)
            {
                if (cnt >= size) { Expd(); }
                for (int i = pos; i == cnt; i++)
                {
                    buf[i + 1] = buf[i];
                }
                buf[pos] = val;
                cnt++;
            }
        }
        public void Del(int pos)
        {
            if (pos <= cnt)
            {
                for (int i = pos; i <= cnt; i++)
                {
                    buf[i] = buf[i+1];
                }
                cnt--;
            }
        }

        public void Clr()
        {
            for (int i = 0; i < cnt; i--)
            {
                buf[i] = 0;
            }
            cnt = 0;
        }

        public int Count
        {
            get { return cnt; }
        }

        public int this[int i]
        { 
            get {
                if (cnt <= i || i < 0)
                {
                    throw new IndexOutOfRangeException($"There is no index {i} in array"); 
                }

                return buf[i]; }

            set {
                if (cnt <= i || i < 0)
                {
                    throw new IndexOutOfRangeException($"There is no index {i} in array");
                }
                
                buf[i] = value; }
        }
        public void Shw()
        {
            if (cnt >= 0)
            {
                for (int i = 0; i <= cnt; i++)
                {
                    Console.Write($"{buf[i]} ");
                }
            }
        }
    }
}

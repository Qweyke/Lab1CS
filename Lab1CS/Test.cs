using System;
using System.Runtime.InteropServices;

namespace Lab1CS
{
    class Test
    {
        static void Main(string[] args)
        {

            ArrList abstr = new ArrList();
            ChainList chain = new ChainList();
            DoublyList doubly = new DoublyList();

            Random rnd = new Random();

            int iter = 2000;                              
            
            for (int i = 0; i < iter; i++)
            {
                int ops = rnd.Next(5);
                int value = rnd.Next(100);
                int pos = rnd.Next(2000);

                switch (ops)
                {
                    case 0:

                        abstr.Add(value);
                        chain.Addit(value);
                        doubly.AddDb(value);
                        break;

                    case 2:

                        abstr.Del(pos);
                        chain.Delete(pos);
                        break;
                    
                    case 1:
                                               
                        abstr.Ins(value, pos);
                        chain.Insert(value, pos);
                        doubly.Insert(value, pos);

                        break;

                    /*case 3:
                        //Console.WriteLine("clr");
                        abstr.Clr();
                        chain.Clear();
                        break;*/
                    
                    case 4:
                       
                        abstr[pos] = value;
                        chain[pos] = value;
                        break;
                }
            }

            bool check = false;

            for (int i = 0; i < abstr.Count; i++) 
            {
                if (abstr[i] != chain[i] && abstr[i] != doubly[i] && chain[i] != doubly[i])
                //if (abstr[i] != chain[i])
                {
                    Console.WriteLine("Элементы не сошлись");
                    Console.WriteLine($"{abstr[i]}, {chain[i]}, {i}");
                    check = true;
                } 
            }
            if (check == false) Console.WriteLine("Успешно\n");

            Console.WriteLine($"Arr cnt = {abstr.Count}, Chain cnt = {chain.Count}, Doubly cnt = {doubly.Count}\n");

            abstr.Shw();
            Console.WriteLine("\n\n");
            chain.Show();
            Console.WriteLine("\n\n");
            doubly.Show();

            Console.WriteLine("\n\nНажмите любую клавишу");
            Console.ReadKey();
        }


    }
}

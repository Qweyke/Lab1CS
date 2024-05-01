using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

namespace Lab1CS
{
    class Test
    {
        static void Main(string[] args)
        {

            ArrayList abstr = new ArrayList();
            ChainList chain = new ChainList();
            DoublyList doubly = new DoublyList();

            Random rnd = new Random();

            int iter = 20000;                              
            
            for (int i = 0; i < iter; i++)
            {
                int ops = rnd.Next(2);
                int value = rnd.Next(100);
                int pos = rnd.Next(2000);

                switch (ops)
                {
                    case 0:

                        abstr.Add(value);
                        chain.Addit(value);
                        doubly.Add(value);
                        break;

                    case 1:

                        abstr.Del(pos);
                        chain.Delete(pos);
                        doubly.Delete(pos);
                        //Checker();
                        break;
                    
                    case 2:
                                               
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
            /*for (int i = 0; i < iter; i++)
            {               
                int pos = rnd.Next(200);
                abstr.Del(pos);
                chain.Delete(pos);
                doubly.Delete(pos);
                //Checker();
            }*/
            void Checker()
            {
                bool check = true;
                bool checker = true;

                for (int i = 0; i < abstr.Count; i++)
                {
                    if (abstr[i] == chain[i] && abstr[i] == doubly[i] && chain[i] == doubly[i]) check = true;
                    else
                    {
                        
                        check = false;
                        checker = false;
                        Console.WriteLine($"Не сошлись [{i}] у chain = {chain[i]}, у doubly = {doubly[i]}\n");
                        //throw new IndexOutOfRangeException("Не сошлись");
                    }
                }
                if (checker == true) Console.WriteLine("Успешно\n");
                else Console.WriteLine("Ошибка\n");
            }
            Checker();

            Console.WriteLine($"Arr cnt = {abstr.Count}, Chain cnt = {chain.Count}, Doubly cnt = {doubly.Count}\n");

            //abstr.Shw();
            //Console.WriteLine("\n\n");
            chain.Show();
            Console.WriteLine("\n\n");
            doubly.Show();

            Console.WriteLine("\n\nНажмите любую клавишу");
            Console.ReadKey();
        }


    }
}

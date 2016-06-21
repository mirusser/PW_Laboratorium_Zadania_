using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PW_9_1
{
    class Program
    {
        static Thread[] tablicaWatkow;

        static void Metoda()
        {
            ThreadLocal<int> licznik = new ThreadLocal<int>();

            while (true)
            {
                BezparametrowaMetoda(ref licznik);
                Thread.Sleep(1000);
            }
        }

        static void BezparametrowaMetoda(ref ThreadLocal<int> licznik)
        {
            licznik.Value++;
            Console.WriteLine("Watek: {0} licznik: {1}",int.Parse(Thread.CurrentThread.Name), licznik.Value);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Liczba watków [int]: ");
            tablicaWatkow = new Thread[Convert.ToInt32(Console.ReadLine())];

            for (int i = 0; i < tablicaWatkow.Length; i++)
            {
                tablicaWatkow[i] = new Thread(Metoda);
                tablicaWatkow[i].Start();
                tablicaWatkow[i].Name = i.ToString();
            }

            for (int i = 0; i < tablicaWatkow.Length; i++)
            {
                tablicaWatkow[i].Join();
            }

            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace PW_1_3
{
    class Program
    {
        #region Pola klasy
        static int[,] graf;
        static int bok_grafu;
        static int liczba_krawedzi = 0;
        #endregion

        #region Metody liczące krawędzie
        public static void sekwencyjne_liczenie()
        {
            int k = 0;
            for (int i = 0; i < bok_grafu - 1; i++)
            {
                for (int j = i + 1; j < bok_grafu; j++)
                {
                    if (graf[i, j] == 1)
                        k++;
                }
            }
            Console.WriteLine("Liczba krawędzi liczona sekwencyjnie wynosi: {0}", k);
        }

        public static void współbieżne_liczenie()
        {
            int x = int.Parse(Thread.CurrentThread.Name);
            for (int i = 0; i < bok_grafu; i++)
                liczba_krawedzi += graf[i, x];
        }
        #endregion

        #region Metody tworzące graf
        public static void Utworz_Graf()
        {
            graf = new int[bok_grafu, bok_grafu];
            Random random = new Random();

            for (int i = 0; i < bok_grafu; i++)
            {
                for (int j = i + 1; j < bok_grafu; j++)
                {
                    graf[i, j] = random.Next(0, 2);
                    graf[j, i] = graf[i, j];
                }
            }

            for (int i = 0; i < bok_grafu; i++)
                graf[i, i] = 0;

            RysujGraf();
        }

        public static void RysujGraf()
        {
            for (int i = 0; i < bok_grafu; i++)
            {
                for (int j = 0; j < bok_grafu; j++)
                {
                    Console.Write(graf[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        #endregion

        #region Metoda Main
        static void Main(string[] args)
        {
            Console.Write("Podaj bok grafu [liczba całkowita]: ");
            bok_grafu = Convert.ToInt32(Console.ReadLine());
            Utworz_Graf();

            Stopwatch stoper_sekwencyjnie = new Stopwatch();
            Stopwatch stoper_wspolbieznie = new Stopwatch();

            stoper_sekwencyjnie.Start();
            sekwencyjne_liczenie();
            stoper_sekwencyjnie.Stop();

            Console.WriteLine("Czas liczenia krawędzi sekwencyjnie: {0}", stoper_sekwencyjnie.ElapsedMilliseconds + " ms");

            Thread[] tablicaWatkow = new Thread[bok_grafu];
            for (int i = 0; i < bok_grafu; i++)
            {
                tablicaWatkow[i] = new Thread(new ThreadStart(współbieżne_liczenie));
                tablicaWatkow[i].Name = i.ToString();
            }

            stoper_wspolbieznie.Start();
            for (int i = 0; i < bok_grafu; i++)
            {

                tablicaWatkow[i].Start();
            }

            for (int i = 0; i < bok_grafu; i++)
            {

                tablicaWatkow[i].Join();
            }

            stoper_wspolbieznie.Stop();

            Console.WriteLine("Ilosc krawedzi liczona współbieżnie: " + liczba_krawedzi / 2);
            Console.WriteLine("Czas liczenia krawędzi współbieżnie: " + stoper_wspolbieznie.ElapsedMilliseconds + " ms");

            Console.ReadLine();
        }
        #endregion
    }
}
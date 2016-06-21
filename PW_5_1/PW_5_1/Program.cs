using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace PW_5_1
{
    class Program
    {
        #region Pola klasy
        private static int[,] graf;
        private static int bok_grafu;
        private static volatile int[,] tablicaPermutacji; //poziomo (pierwszy index) to numer watku, pionowo (drugi index) permutacja dla danego watku
        static Thread[] tablicaWatkow;
        static volatile int szerokoscGrafu;
        #endregion

        #region Silinia
        public static int Silnia(int n)
        {
            int result = 1;
            if (n == 0 || n == 1)
            {
                return result;
            }
            else
            {
                for (int i = 2; i <= n; i++)
                {
                    result *= i;
                }
                return result;
            }
        }
        #endregion

        #region Wyliczenie Szerokosci Grafu Dla Jednej Permutacji
        static void NajmniejszaSzerokosc(int odleglosc)
        {
            if (odleglosc < szerokoscGrafu)
            {
                szerokoscGrafu = odleglosc;
            }
        }
        static void NajwieszkaBezwzglednaRoznicaMiedzyEtykietamiWierzcholkow()
        {
            int odleglosc, najlepszaOdleglosc = 1;

            for (int i = 0; i < bok_grafu - 1; i++)
                for (int j = i + 1; j < bok_grafu; j++) if (graf[i,j] == 1)
                    {
                        odleglosc = 
                        Math.Abs(tablicaPermutacji[int.Parse(Thread.CurrentThread.Name),i] - tablicaPermutacji[int.Parse(Thread.CurrentThread.Name), j]);

                        if (odleglosc > najlepszaOdleglosc)
                        {
                            najlepszaOdleglosc = odleglosc;
                        }
                    }
            NajmniejszaSzerokosc(najlepszaOdleglosc);
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

        #region Metoda wyliczajaca wszystkie permutacje dla watku, oraz szerokosc grafu dla jednego watku
        static void PermutacjaWatek()
        {
            PierwszaPermutacjaDlaWatku();
            for (int i = 0; i < (Silnia((bok_grafu-1))-1) ; i++)
            {
                NextPermutation<int>(tablicaPermutacji);
            }

            NajwieszkaBezwzglednaRoznicaMiedzyEtykietamiWierzcholkow();
        }
        #endregion

        #region Generowanie pierwszej (startowej) permutacji dla watku
        static void PierwszaPermutacjaDlaWatku()
        {
            int numerWatku = int.Parse(Thread.CurrentThread.Name);
            tablicaPermutacji[numerWatku,0] = numerWatku;
            int buffor = 0;

            if (numerWatku > 1)
            {
                for (int i = 1; i < bok_grafu; i++)
                {
                    if (buffor == numerWatku)
                    {
                        buffor++;
                    }
                    Monitor.Enter(tablicaPermutacji);
                    tablicaPermutacji[numerWatku,i] = buffor;
                    Monitor.Exit(tablicaPermutacji);
                    buffor++;
                }
            }
            if(numerWatku==0)
            {
                for (int i = 1; i < bok_grafu; i++)
                {
                    Monitor.Enter(tablicaPermutacji);
                    tablicaPermutacji[numerWatku,i] = i;
                    Monitor.Exit(tablicaPermutacji);
                }
            }
            if (numerWatku == 1)
            {
                for (int i = 1; i < bok_grafu; i++)
                {
                    if(i==1)
                    {
                        Monitor.Enter(tablicaPermutacji);
                        tablicaPermutacji[numerWatku,i] = i-1;
                        Monitor.Exit(tablicaPermutacji);
                    }
                    else
                    {
                        Monitor.Enter(tablicaPermutacji);
                        tablicaPermutacji[numerWatku,i] = i;
                        Monitor.Exit(tablicaPermutacji);
                    }
                }
            }

            //Wyswietlenie startowej permutacji:

            /*Console.Write("Watek nr: " + numerWatku + " Początek permutacji: ");
            for (int i = 0; i < bok_grafu; i++)
            {
                Console.Write(tablicaPermutacji[numerWatku,i] + " ");
            }
            Console.WriteLine();*/
        }
        #endregion

        #region Generowanie kolejnej permutacji
        public static bool NextPermutation<T>(T[,] tab) where T : IComparable<T>
        {
            T[] elements = new T[bok_grafu];
            for (int i = 0; i < bok_grafu; i++)
            {
                elements[i] = tab[int.Parse(Thread.CurrentThread.Name), i];
            }
            // More efficient to have a variable instead of accessing a property
            var count = elements.Length;

            // Indicates whether this is the last lexicographic permutation
            var done = true;

            // Go through the array from last to first
            for (var i = count - 1; i > 1; i--)
            {
                var curr = elements[i];

                // Check if the current element is less than the one before it
                if (curr.CompareTo(elements[i - 1]) < 0)
                {
                    continue;
                }

                // An element bigger than the one before it has been found,
                // so this isn't the last lexicographic permutation.
                done = false;

                // Save the previous (bigger) element in a variable for more efficiency.
                var prev = elements[i - 1];

                // Have a variable to hold the index of the element to swap
                // with the previous element (the to-swap element would be
                // the smallest element that comes after the previous element
                // and is bigger than the previous element), initializing it
                // as the current index of the current item (curr).
                var currIndex = i;

                // Go through the array from the element after the current one to last
                for (var j = i + 1; j < count; j++)
                {
                    // Save into variable for more efficiency
                    var tmp = elements[j];

                    // Check if tmp suits the "next swap" conditions:
                    // Smallest, but bigger than the "prev" element
                    if (tmp.CompareTo(curr) < 0 && tmp.CompareTo(prev) > 0)
                    {
                        curr = tmp;
                        currIndex = j;
                    }
                }

                // Swap the "prev" with the new "curr" (the swap-with element)
                elements[currIndex] = prev;
                elements[i - 1] = curr;

                // Reverse the order of the tail, in order to reset it's lexicographic order
                for (var j = count - 1; j > i; j--, i++)
                {
                    var tmp = elements[j];
                    elements[j] = elements[i];
                    elements[i] = tmp;
                }

                // Break since we have got the next permutation
                // The reason to have all the logic inside the loop is
                // to prevent the need of an extra variable indicating "i" when
                // the next needed swap is found (moving "i" outside the loop is a
                // bad practice, and isn't very readable, so I preferred not doing
                // that as well).
                break;
            }
            /*foreach (var item in elements)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();*/
            // Return whether this has been the last lexicographic permutation.
            for (int i = 0; i < bok_grafu; i++)
            {
                tab[int.Parse(Thread.CurrentThread.Name), i] = elements[i];
            }
            return done;
        }
        #endregion

        #region Main
        static void Main(string[] args)
        {
            Console.WriteLine("Podaj długość boku grafu [int]: ");
            bok_grafu = Convert.ToInt32(Console.ReadLine());

            Utworz_Graf();
            szerokoscGrafu = bok_grafu - 1;

            tablicaPermutacji = new int[bok_grafu, bok_grafu];
            tablicaWatkow = new Thread[bok_grafu];

            Stopwatch stoper = new Stopwatch();
            stoper.Start();

            Parallel.For(0, bok_grafu, i =>
             {
                 tablicaWatkow[i] = new Thread(new ThreadStart(PermutacjaWatek));
                 tablicaWatkow[i].Name = i.ToString();
                 tablicaWatkow[i].Start();
             });
            Parallel.For(0, bok_grafu, i =>
            {
                tablicaWatkow[i].Join();
            });

            stoper.Stop();

            Console.WriteLine("\nWyliczenie zajelo: {0} ms", stoper.ElapsedMilliseconds);
            Console.WriteLine("Szerokość grafu wynosi: {0}", szerokoscGrafu);
            Console.ReadLine();
        }
        #endregion
    }
}

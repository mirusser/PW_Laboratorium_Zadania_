using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PW_2_1
{
    class Program
    {
        #region Variables
        public volatile static int[] table;
        static Thread[] countElementsInTableThread;
        static volatile int sumOfElementsInTable;
        #endregion

        #region Count sum of elements in a table
        static void CountElementsInTableForOddLengthOfTable()
        {
            int fromWhichElementStart = int.Parse(Thread.CurrentThread.Name);

            Monitor.Enter(table);
            sumOfElementsInTable += table[fromWhichElementStart];
            Monitor.Exit(table);
            Thread.CurrentThread.Abort();
        }

        static void CountElementsInTableForEvenLengthOfTable()
        {
            int fromWhichElementStart = (int.Parse(Thread.CurrentThread.Name) * 2);
            int whichElementToStop = (++fromWhichElementStart);
            fromWhichElementStart--;

            while (fromWhichElementStart<= whichElementToStop)
            {
                Monitor.Enter(table);
                sumOfElementsInTable += table[fromWhichElementStart];
                Monitor.Exit(table);
                fromWhichElementStart++;
            }

            Thread.CurrentThread.Abort();
        }
        #endregion

        #region Generate Table
        static void CreateTable() //i wyświetl tablicę przy okazji
        {
            Console.WriteLine("Podaj długość tablicy [int]: ");
            table = new int[Convert.ToInt32(Console.ReadLine())];

            Console.WriteLine("Twoja tablica wygląda następująco: ");
            for (int i = 0; i < table.Length; i++)
            {
                Random random = new Random();
                table[i] = random.Next(-100,101);
                Console.Write(table[i] + " ");
                Thread.Sleep(15); //czekanie ponieważ bez tego wszystkie elementy w tablicy mają tą samą wartość
            }

            Console.WriteLine("\nNaciśnij dowolny klawisz by kontynuować...");
            Console.ReadLine();
        }
        #endregion

        #region Main
        static void Main(string[] args)
        {
            CreateTable();
            if (table.Length % 2 ==0)
            {
                countElementsInTableThread = new Thread[(table.Length / 2)];

                for (int i = 0; i < (table.Length/2); i++)
                {
                    countElementsInTableThread[i] = new Thread(new ThreadStart(CountElementsInTableForEvenLengthOfTable));
                    countElementsInTableThread[i].Name = i.ToString();
                    countElementsInTableThread[i].Start();
                }
                for (int i = 0; i < (table.Length / 2); i++)
                {
                    countElementsInTableThread[i].Join();
                }
            }
            else
            {
                countElementsInTableThread = new Thread[table.Length];
                for (int i = 0; i < table.Length; i++)
                {
                    countElementsInTableThread[i] = new Thread(new ThreadStart(CountElementsInTableForOddLengthOfTable));
                    countElementsInTableThread[i].Name = i.ToString();
                    countElementsInTableThread[i].Start();
                }
                for (int i = 0; i < table.Length; i++)
                {
                    countElementsInTableThread[i].Join();
                }
            }

            Thread.Sleep(3000);
            if (!Monitor.IsEntered(sumOfElementsInTable))
            {
                Console.WriteLine("Suma elementów w tablicy: {0}", sumOfElementsInTable);
            }
            Console.WriteLine("\nNaciśnij dowolny klawisz by kontynuować...");
            Console.ReadLine();
        }
        #endregion
    }
}

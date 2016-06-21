using System;
using System.Threading;

namespace PW_1_2
{
    class Program
    {
        static void Metoda()
        {
            Thread.CurrentThread.Suspend();

            //watek musi być uśpiony/zawieszony bądź robić cokolwiek, ponieważ inaczej, 
            //zaraz po zakończeniu tej metody jest usuwany/zatrzymywany
        }


        static void Main()
        {
            int liczba_wątków = 0;

            Console.WriteLine("Zaczynam tworzenie wątków.");
            DateTime start = DateTime.Now;
            while (true)
            {
                Thread thread = new Thread(Metoda);
                try
                {
                    thread.Start();
                    liczba_wątków++;
                }
                catch
                {
                    DateTime end = DateTime.Now;
                    Console.WriteLine("Czas potrzebny na utworzenie wszystkich wątków: {0}", (end-start));
                    Console.WriteLine("liczba_wątków wątków: {0}", liczba_wątków);
                    break;
                }
            }
            Console.WriteLine("Utworzono maksymalną ilość wątków.");
            Console.ReadLine();//By zobaczyć wynik działania programu
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading;

namespace PW_1_1
{
    class Program
    {
        //Pusta metoda, ponieważ wątek musi coć wykonywać
        static void Metoda()
        {

        }

        static void Main(string[] args)
        {
            List<Thread> Lista_watkow = new List<Thread>();
            List<TimeSpan> Lista_czasow = new List<TimeSpan>();

            //Tworzenie tysiąca wątków, tak duża liczba by pomiar był wiarygodny
            for (int i = 0; i < 1000; i++)
            {
                DateTime początek = DateTime.Now;

                Thread thread = new Thread(new ThreadStart(Metoda));
                thread.Start();
                DateTime koniec = DateTime.Now;
                Lista_czasow.Add(koniec - początek); //Dodanie wyliczonego czasu tworzenia jednego wątku na listę

                Lista_watkow.Add(thread);
                Console.WriteLine("Wątek " + i + " utworzył się w czasie " + Lista_czasow[i]);
            }

            TimeSpan _suma = new TimeSpan();
            foreach (TimeSpan bufor in Lista_czasow)
            {
                _suma += bufor;
            }
            int suma = (_suma.Seconds * 1000 + _suma.Milliseconds);
            double srednia = (double)suma / 1000.0;

            Console.WriteLine("Średnio jeden wątek tworzył się więc " + srednia + " ms.");
            Console.ReadLine(); //ReadLine by można było zobaczyć w konsoli wynik działania programu
        }
    }
}

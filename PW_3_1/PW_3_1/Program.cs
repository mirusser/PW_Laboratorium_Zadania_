using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace PW_3_1
{
    class PasswordGenerator
    {
        #region String Generator/Password Generator
        public static string RandomString(int range)
        {
            var chars = "abcdefghijklmnopqrstuwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                             Enumerable.Repeat(chars, range)
                            .Select(s => s[random.Next(s.Length)])
                            .ToArray());
            return result;
        }
        #endregion
    }

    class Consumer_Producer : PasswordGenerator
    {
        #region Variables
        public static string ConsumerPassword;
        public static Thread consumerThread;
        public static Thread producerThread;
        volatile static object buffer;
        volatile static bool foundPassword;
        #endregion

        #region Constructor
        public Consumer_Producer()
        {
            buffer = null;
            foundPassword = false;
            ConsumerPassword = RandomString(8);
            Console.WriteLine("Consumer Password: {0}", ConsumerPassword);

            consumerThread = new Thread(new ThreadStart(TakeFromBuffor));
            producerThread = new Thread(new ThreadStart(InsertIntoBuffor));

            producerThread.Start();
            consumerThread.Start();
        }
        #endregion

        #region Consumer method
        public static void TakeFromBuffor()
        {
            while (true)
            {

                if (buffer != null)
                {
                    Monitor.Enter(buffer);
                    Console.WriteLine("Consumer reads from a buffer");
                    Console.WriteLine("Content of a buffer: {0} \n", buffer);
                    if (buffer.ToString() == ConsumerPassword)
                    {
                        Console.WriteLine("Password was found");
                        Console.WriteLine("The Password is: {0}", buffer);
                        Monitor.Exit(buffer);
                        buffer = null;
                        foundPassword = true;
                        consumerThread.Abort();
                    }
                    Monitor.Exit(buffer);
                    buffer = null;

                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Consumer: Empty Buffor");
                    Thread.Sleep(1000);
                }

            }
        }
        #endregion

        #region Producer method
        public static void InsertIntoBuffor()
        {
            while (true)
            {
                if(foundPassword==true)
                {
                    producerThread.Abort();
                    break;
                }

                if (buffer == null)
                {
                    buffer = RandomString(8);
                    Console.WriteLine("Producer writes to a buffer");
                    Console.WriteLine("Content of a buffer: {0} \n", buffer);

                    Thread.Sleep(1000);
                }
                else
                {
                    Console.WriteLine("Producer: Buffor is not empty");
                    Thread.Sleep(1000);
                }

            }
        }
        #endregion
    }
    class Program
    {
        #region Main
        static void Main(string[] args)
        {
            Consumer_Producer consumer_producer = new Consumer_Producer();
            Console.ReadLine();
        }
        #endregion
    }
}

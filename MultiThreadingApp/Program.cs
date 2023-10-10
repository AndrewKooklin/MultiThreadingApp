using System;
using System.Threading;

namespace MultiThreadingApp
{
    class Program
    {
        public static Thread threadOne;
        public static Thread threadTwo;
        public static Random random = new Random();

        static void Main(string[] args)
        {
            threadOne = new Thread(InfoFromOneThread);
            threadOne.Name = "One";

            threadTwo = new Thread(InfoFromTwoThread);
            threadTwo.Name = "Two";

            threadOne.Start();
            threadTwo.Start();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }

        private static void InfoFromOneThread()
        {
            for(int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Hello from one thread with name : \"{threadOne.Name}\"" +
                                  $" and Id : {threadOne.ManagedThreadId}");

                Thread.Sleep(random.Next(1000, 2000));
            }
            
        }

        private static void InfoFromTwoThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;

                Console.WriteLine($"Hello from two thread with name : \"{threadTwo.Name}\"" +
                                  $" and Id : {threadTwo.ManagedThreadId}");

                Thread.Sleep(random.Next(1000, 2000));
            }
        }
    }
}

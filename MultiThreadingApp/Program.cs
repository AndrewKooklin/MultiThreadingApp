using System;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadingApp
{
    class Program
    {
        public static Thread threadOne;
        public static Thread threadTwo;
        public static Thread threadThree;
        public static Random random = new Random();

        static async Task Main(string[] args)
        {
            threadOne = new Thread(InfoFromOneThread);
            threadOne.Name = "One";

            threadTwo = new Thread(InfoFromTwoThread);
            threadTwo.Name = "Two";

            threadThree = new Thread(InfoFromThreeThread);
            threadThree.Name = "Three";

            threadOne.Start();
            threadTwo.Start();
            await PrintDataAsync();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Hello World!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.ReadLine();
        }

        private static void InfoFromOneThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine($"Hello from one thread with name : \"{threadOne.Name}\"" +
                                  $" and Id : {threadOne.ManagedThreadId}");

                Console.ForegroundColor = ConsoleColor.Gray;

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
                Console.ForegroundColor = ConsoleColor.Gray;

                Thread.Sleep(random.Next(1000, 2000));
            }
        }

        private static void InfoFromThreeThread()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.Magenta;

                Console.WriteLine($"Hello from two thread with name : \"{threadThree.Name}\"" +
                                  $" and Id : {threadThree.ManagedThreadId}");

                Console.ForegroundColor = ConsoleColor.Gray;

                Thread.Sleep(random.Next(1000, 2000));
            }
        }

        private static async Task PrintDataAsync()
        {
            Task task = Task.Factory.StartNew(InfoFromThreeThread);
            await task;
        }
    }
}

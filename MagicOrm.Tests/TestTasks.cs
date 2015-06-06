using System;
using System.Threading;

namespace MagicOrm.Tests
{
    public class TestTasks
    {
        public void Task1()
        {
            Console.WriteLine("task1.");
            Thread.Sleep(1000);
            Console.WriteLine("task1 completed.");
        }

        public void Task2(int x)
        {
            if (x < 2000)
            {
                x += 2000;
            }
            Console.WriteLine("task2.");
            Thread.Sleep(x);
            Console.WriteLine("task2 completed.");
        }

        public int Task3(int x)
        {
            if (x < 2000)
            {
                x += 2000;
            }
            Console.WriteLine("task3.");
            Thread.Sleep(x);
            Console.WriteLine("task3 completed.");
            return x;
        }
    }
}

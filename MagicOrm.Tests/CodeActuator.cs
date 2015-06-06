using System;
using System.Diagnostics;

namespace MagicOrm.Tests
{
    public static class CodeActuator
    {
        public static void RunCode(Action action, int executeCount = 1)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < executeCount; i++)
            {
                action();
            }
            stopwatch.Stop();
            Console.WriteLine(stopwatch.ElapsedMilliseconds);
        }
    }

}

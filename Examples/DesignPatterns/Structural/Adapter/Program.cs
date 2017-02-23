using System;

namespace Adapter
{
    internal class Program
    {
        private static void Main()
        {
            var target = new Adapter();
            target.Request();

            Console.ReadKey();
        }
    }
}
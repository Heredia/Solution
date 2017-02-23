using System;

namespace Proxy
{
    internal class Program
    {
        private static void Main()
        {
            var proxy = new Proxy();
            proxy.Request();

            Console.ReadKey();
        }
    }
}
using System;

namespace Facade
{
    internal class Program
    {
        private static void Main()
        {
            var facade = new Facade();

            facade.Method1();
            facade.Method2();

            Console.ReadKey();
        }
    }
}
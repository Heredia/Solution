using System;

namespace Prototype
{
    internal class Program
    {
        private static void Main()
        {
            var concretePrototypeA1 = new ConcretePrototypeA("I");
            var concretePrototypeA2 = (ConcretePrototypeA)concretePrototypeA1.Clone();
            Console.WriteLine($"Cloned: {concretePrototypeA2.Id}");

            var concretePrototypeB1 = new ConcretePrototypeB("II");
            var concretePrototypeB2 = (ConcretePrototypeB)concretePrototypeB1.Clone();
            Console.WriteLine($"Cloned: {concretePrototypeB2.Id}");

            Console.ReadKey();
        }
    }
}
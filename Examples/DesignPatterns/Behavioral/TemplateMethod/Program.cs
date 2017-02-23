using System;

namespace TemplateMethod
{
    internal class Program
    {
        private static void Main()
        {
            var abstractClassA = new ConcreteClassA();
            abstractClassA.TemplateMethod();

            var abstractClassB = new ConcreteClassB();
            abstractClassB.TemplateMethod();

            Console.ReadKey();
        }
    }
}
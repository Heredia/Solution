using System;

namespace AbstractFactory
{
    internal class Program
    {
        private static void Main()
        {
            var concreteFactoryA = new ConcreteFactoryA();
            var clientA = new Client(concreteFactoryA);
            clientA.Run();

            var concreteFactoryB = new ConcreteFactoryB();
            var clientB = new Client(concreteFactoryB);
            clientB.Run();

            Console.ReadKey();
        }
    }
}
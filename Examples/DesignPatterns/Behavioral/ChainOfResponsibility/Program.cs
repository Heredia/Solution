using System;

namespace ChainOfResponsibility
{
    internal class Program
    {
        private static void Main()
        {
            var concreteHandlerA = new ConcreteHandlerA();
            var concreteHandlerB = new ConcreteHandlerB();
            var concreteHandlerC = new ConcreteHandlerC();

            concreteHandlerA.SetSuccessor(concreteHandlerB);
            concreteHandlerB.SetSuccessor(concreteHandlerC);

            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20 };

            foreach (var request in requests)
            {
                concreteHandlerA.HandleRequest(request);
            }

            Console.ReadKey();
        }
    }
}
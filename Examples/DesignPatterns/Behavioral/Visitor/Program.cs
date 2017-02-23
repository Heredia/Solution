using System;

namespace Visitor
{
    internal class Program
    {
        private static void Main()
        {
            var objectStructure = new ObjectStructure();
            objectStructure.Attach(new ConcreteElementA());
            objectStructure.Attach(new ConcreteElementB());

            var concreteVisitorA = new ConcreteVisitorA();
            var concreteVisitorB = new ConcreteVisitorB();

            objectStructure.Accept(concreteVisitorA);
            objectStructure.Accept(concreteVisitorB);

            Console.ReadKey();
        }
    }
}
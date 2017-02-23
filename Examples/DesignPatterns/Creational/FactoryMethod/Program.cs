using System;

namespace FactoryMethod
{
    internal class Program
    {
        private static void Main()
        {
            var creators = new Creator[] { new ConcreteCreatorA(), new ConcreteCreatorB() };

            foreach (var creator in creators)
            {
                var product = creator.FactoryMethod();
                Console.WriteLine($"{product.GetType().Name} created.");
            }

            Console.ReadKey();
        }
    }
}
using System;

namespace Builder
{
    internal class Program
    {
        private static void Main()
        {
            var director = new Director();

            var builderA = new ConcreteBuilderA();
            var builderB = new ConcreteBuilderB();

            director.Construct(builderA);
            var productA = builderA.GetResult();
            productA.Show();

            director.Construct(builderB);
            var productB = builderB.GetResult();
            productB.Show();

            Console.ReadKey();
        }
    }
}
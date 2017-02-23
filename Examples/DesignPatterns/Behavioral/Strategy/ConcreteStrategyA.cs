using System;

namespace Strategy
{
    internal class ConcreteStrategyA : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyA.AlgorithmInterface()");
        }
    }
}
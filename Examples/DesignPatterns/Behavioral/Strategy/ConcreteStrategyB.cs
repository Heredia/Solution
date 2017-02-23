using System;

namespace Strategy
{
    internal class ConcreteStrategyB : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyB.AlgorithmInterface()");
        }
    }
}
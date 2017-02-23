using System;

namespace Strategy
{
    internal class ConcreteStrategyC : Strategy
    {
        public override void AlgorithmInterface()
        {
            Console.WriteLine("ConcreteStrategyC.AlgorithmInterface()");
        }
    }
}
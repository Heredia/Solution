using System;

namespace Decorator
{
    internal class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
            AddedBehavior();
            Console.WriteLine("ConcreteDecoratorB.Operation()");
        }

        private void AddedBehavior()
        {
            Console.WriteLine("ConcreteDecoratorB.AddedBehavior()");
        }
    }
}
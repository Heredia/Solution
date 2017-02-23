using System;

namespace Mediator
{
    internal class ConcreteColleagueA : Colleague
    {
        public ConcreteColleagueA(Mediator mediator) : base(mediator)
        {
        }

        public void Send(string message)
        {
            Mediator.Send(message, this);
        }

        public void Notify(string message)
        {
            Console.WriteLine("ColleagueA gets message: " + message);
        }
    }
}
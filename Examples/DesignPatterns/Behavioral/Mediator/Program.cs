using System;

namespace Mediator
{
    internal class Program
    {
        private static void Main()
        {
            var mediator = new ConcreteMediator();

            var concreteColleagueA = new ConcreteColleagueA(mediator);
            var concreteColleagueB = new ConcreteColleagueB(mediator);

            mediator.ColleagueA = concreteColleagueA;
            mediator.ColleagueB = concreteColleagueB;

            concreteColleagueA.Send("How are you?");
            concreteColleagueA.Send("Fine, thanks");

            Console.ReadKey();
        }
    }
}
using System;
using System.Collections;

namespace Interpreter
{
    internal class Program
    {
        private static void Main()
        {
            var context = new Context();

            var list = new ArrayList
            {
                new TerminalExpression(),
                new NonterminalExpression(),
                new TerminalExpression(),
                new TerminalExpression()
            };

            foreach (AbstractExpression exp in list)
            {
                exp.Interpret(context);
            }

            Console.ReadKey();
        }
    }
}
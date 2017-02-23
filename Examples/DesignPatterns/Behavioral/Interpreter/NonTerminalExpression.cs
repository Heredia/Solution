using System;

namespace Interpreter
{
    internal class NonterminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Nonterminal.Interpret()");
        }
    }
}
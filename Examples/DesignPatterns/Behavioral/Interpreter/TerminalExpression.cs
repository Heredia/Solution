using System;

namespace Interpreter
{
    internal class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Terminal.Interpret()");
        }
    }
}
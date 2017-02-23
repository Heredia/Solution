using System;

namespace TemplateMethod
{
    internal abstract class AbstractClass
    {
        public abstract void PrimitiveOperation1();

        public abstract void PrimitiveOperation2();

        public void TemplateMethod()
        {
            PrimitiveOperation1();
            PrimitiveOperation2();
            Console.WriteLine(string.Empty);
        }
    }
}
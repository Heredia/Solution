namespace Visitor
{
    internal abstract class Visitor
    {
        public abstract void VisitConcreteElementA(ConcreteElementA concreteElementA);

        public abstract void VisitConcreteElementB(ConcreteElementB concreteElementB);
    }
}
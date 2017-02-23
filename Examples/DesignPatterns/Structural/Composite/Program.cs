using System;

namespace Composite
{
    internal class Program
    {
        private static void Main()
        {
            var root = new Composite("Root");
            root.Add(new Leaf("Leaf A"));
            root.Add(new Leaf("Leaf B"));

            var comp = new Composite("Parent A");
            comp.Add(new Leaf("Child A1"));
            comp.Add(new Leaf("Child A2"));

            root.Add(comp);
            root.Add(new Leaf("Leaf C"));

            var leaf = new Leaf("Leaf D");
            root.Add(leaf);
            root.Remove(leaf);

            root.Display(1);

            Console.ReadKey();
        }
    }
}
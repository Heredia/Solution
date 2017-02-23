using System;

namespace Flyweight
{
    internal class Program
    {
        private static void Main()
        {
            var extrinsicstate = 100;

            var flyweightFactory = new FlyweightFactory();

            var flyweightX = flyweightFactory.GetFlyweight("X");
            flyweightX.Operation(--extrinsicstate);

            var flyweightY = flyweightFactory.GetFlyweight("Y");
            flyweightY.Operation(--extrinsicstate);

            var flyweightZ = flyweightFactory.GetFlyweight("Z");
            flyweightZ.Operation(--extrinsicstate);

            var unsharedConcreteFlyweight = new UnsharedConcreteFlyweight();
            unsharedConcreteFlyweight.Operation(--extrinsicstate);

            Console.ReadKey();
        }
    }
}
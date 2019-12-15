using System.Collections.Generic;

namespace AlgrythmStrategy2
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ProportionalPainter> painters = new ProportionalPainter[10];

            IPainter painterFastest = CompositePainterFactories.CreateFastestSelector(painters);

            IPainter painterGroup = CompositePainterFactories.CombineProportional(painters);

        }
    }
}

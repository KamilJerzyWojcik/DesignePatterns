using System;
using System.Collections.Generic;

namespace UntanglingStructureCollectionObject
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ProportionalPainter> painters = new ProportionalPainter[10];

            IPainter painterFastest = CompositePainterFactories.CreateFastestSelector(painters);

            IPainter painterGroup = CompositePainterFactories.CreateGroup(painters);
        }
    }
}

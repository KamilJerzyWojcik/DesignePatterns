﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrythmStrategy2
{
    public class CompositePainterFactories
    {
        public static IPainter CreateCheapestSelector(IEnumerable<IPainter> painters) =>
            new CompositePainter<IPainter>(painters,
                (sqMeters, sequence) =>
                    new Painters(sequence)
                    .GetAvailable()
                    .GetCheapestOne(sqMeters));


        public static IPainter CreateFastestSelector(IEnumerable<IPainter> painters) =>
            new CompositePainter<IPainter>(painters,
                (sqMeters, sequence) =>
                    new Painters(sequence)
                        .GetAvailable()
                        .GetFastestOne(sqMeters));


        public static IPainter CombineProportional(IEnumerable<ProportionalPainter> painters) =>
            new CombiningPainter<ProportionalPainter>(
                painters, // what combine
                new ProportionalPaintingScheduler()); // how combine
    }
}

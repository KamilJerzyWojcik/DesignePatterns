using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorytmIntoStrategy
{
    public class Painters
    {
        private IEnumerable<IPainter> _containedPainters { get; }

        public Painters(IEnumerable<IPainter> painters)
        {
            _containedPainters = painters.ToList();
        }

        public Painters GetAvailable() =>
            new Painters(_containedPainters.Where(painter => painter.IsAvailable));

        public IPainter GetCheapestOne(double sqMeters) =>
            _containedPainters.WithMinimum(painter => painter.EstimateCompensation(sqMeters));

        public IPainter GetFastestOne(double sqMeters) =>
            _containedPainters.WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorytmIntoStrategy
{
    public class CompositePainter<TPainter> : IPainter
        where TPainter: IPainter
    {
        public static IEnumerable<TPainter> _painters { get; set; }

        public bool IsAvailable => _painters.Any(painter => painter.IsAvailable);

        public Func<double, IEnumerable<TPainter>, IPainter> _reduce { get; set; }


        public CompositePainter(IEnumerable<TPainter> painters,
                                Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            _painters = painters.ToList();
            _reduce = reduce;
        }

        public CompositePainter(IEnumerable<TPainter> painters)
        {
            _painters = painters.ToList();
        }


        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            _reduce(sqMeters, _painters).EstimateTimeToPaint(sqMeters);


        public double EstimateCompensation(double sqMeters) =>
            _reduce(sqMeters, _painters).EstimateCompensation(sqMeters);
    }
}

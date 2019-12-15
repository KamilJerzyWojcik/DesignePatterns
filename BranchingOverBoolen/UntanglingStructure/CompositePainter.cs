using System;
using System.Collections.Generic;
using System.Linq;

namespace UntanglingStructureCollectionObject
{
    public class CompositePainter<TPainter> : IPainter
        where TPainter: IPainter
    {
        private IEnumerable<TPainter> _painters { get; }

        public bool IsAvailable => _painters.Any(painter => painter.IsAvailable);

        private Func<double, IEnumerable<TPainter>, IPainter> _reduce { get; }


        public CompositePainter(IEnumerable<TPainter> painters,
                                Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            _painters = painters.ToList();
            _reduce = reduce;
        }


        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            _reduce(sqMeters, _painters).EstimateTimeToPaint(sqMeters);


        public double EstimateCompensation(double sqMeters) =>
            _reduce(sqMeters, _painters).EstimateCompensation(sqMeters);
    }
}

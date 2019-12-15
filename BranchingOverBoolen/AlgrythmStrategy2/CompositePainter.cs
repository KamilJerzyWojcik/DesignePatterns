using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrythmStrategy2
{
    public class CompositePainter<TPainter> : IPainter
        where TPainter : IPainter
    {
        private IEnumerable<TPainter> _painters { get; }

        public bool IsAvailable => _painters.Any(painter => painter.IsAvailable);

        protected Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; set; }


        public CompositePainter(IEnumerable<TPainter> painters,
                                Func<double, IEnumerable<TPainter>, IPainter> reduce = null)
        {
            _painters = painters.ToList();
            Reduce = reduce;
        }


        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            Reduce(sqMeters, _painters).EstimateTimeToPaint(sqMeters);


        public double EstimateCompensation(double sqMeters) =>
            Reduce(sqMeters, _painters).EstimateCompensation(sqMeters);
    }
}

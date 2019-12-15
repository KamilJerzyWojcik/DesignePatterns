using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgorytmIntoStrategy
{
    public class CombiningPainter<TPainter> : CompositePainter<IPainter>
        where TPainter: IPainter
    {
        private IPainterSchleduler<TPainter> Scheduler { get; }

        public IEnumerable<IPainter> availablePainters = _painters.Where(painters => painter.IsAvailable);

        public CombiningPainter(IEnumerable<ProportionalPainter> painters,
                                   IPainterSchleduler<TPainter> scheduler)
            : base(painters)
        {
            base._reduce = this.Combine;
            Scheduler = scheduler;
        }

        private IPainter Combine(double sqMeters, IEnumerable<ProportionalPainter> painters)
        {
            TimeSpan time = EstimationTime(sqMeters, painters);

            IEnumerable<PaintingTask<IPainter>> schedule = Scheduler.Schedule(sqMeters, availablePainters);

            TimeSpan time = schedule.Max(task => task.Painter.EstimateTimeToPaint(task.squereMeters));

            double cost = schedule.Sum(touple => touple.Item1.EstimateCompensation(touple.Item2));


        double cost =
                painters
                    .Where(painter => painter.IsAvailable)
                    .Select(painter =>
                        painter.EstimateCompensation(sqMeters) /
                        painter.EstimateTimeToPaint(sqMeters).TotalHours *
                        time.TotalHours)
                    .Sum();

            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };
        }

    }
}


//(double sqMeters, IEnumerable<ProportionalPainter> painters)
//        {
//            return TimeSpan.FromHours(
//                           1 /
//                           painters
//                               .Where(painter => painter.IsAvailable)
//                               .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
//                               .Sum()
//                   );
//        }
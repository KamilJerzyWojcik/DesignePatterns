using System;
using System.Collections.Generic;
using System.Linq;

namespace AlgrythmStrategy2
{
    class CombiningPainter<TPainter> : CompositePainter<TPainter>
        where TPainter : IPainter
    {
        private IPaintingScheduler<TPainter> Scheduler { get; }

        public CombiningPainter(IEnumerable<TPainter> painters,
            IPaintingScheduler<TPainter> scheduler) 
            : base(painters)
        {
            base.Reduce = Combine;
            this.Scheduler = scheduler;
        }

        private IPainter Combine(double sqMeters, IEnumerable<TPainter> painters)
        {
            // step 1
            IEnumerable<TPainter> avaliablePainters = painters.Where(painter => painter.IsAvailable);

            // step 2
            IEnumerable<PaintingTask<TPainter>> schedule = Scheduler.Schedule(sqMeters, avaliablePainters);

            // step 3
            TimeSpan time = schedule.Max(task => task.Painter.EstimateTimeToPaint(task.SquereMeters));

            // step 4
            double cost = schedule.Sum(task => task.Painter.EstimateCompensation(task.SquereMeters));

            // step 5
            return new ProportionalPainter()
            {
                TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                DollarsPerHour = cost / time.TotalHours
            };

        }
    }
}

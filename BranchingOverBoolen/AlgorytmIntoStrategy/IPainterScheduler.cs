using System;
using System.Collections.Generic;

namespace AlgorytmIntoStrategy
{
    public interface IPainterSchleduler<TPainter> where TPainter: IPainter
    {
        IEnumerable<PaintingTask<TPainter>> Schedule(double sqMeters, IEnumerable<TPainter> painters);
    }
}

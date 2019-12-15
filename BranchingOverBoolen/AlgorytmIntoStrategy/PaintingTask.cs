using System;
namespace AlgorytmIntoStrategy
{
    public class PaintingTask<TPainter> where TPainter: IPainter
    {
        public TPainter Painter { get; }

        public double squereMeters { get; }

        public PaintingTask(TPainter painter, double sqMeters)
        {
            Painter = painter;
            squereMeters = sqMeters;
        }
    }
}

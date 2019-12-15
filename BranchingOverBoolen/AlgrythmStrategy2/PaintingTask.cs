using System;
using System.Collections.Generic;
using System.Text;

namespace AlgrythmStrategy2
{
    public class PaintingTask<TPainter> where TPainter : IPainter
    {
        public TPainter Painter { get; }

        public double SquereMeters { get; }

        public PaintingTask(TPainter painter, double sqMeters)
        {
            this.Painter = painter;
            this.SquereMeters = sqMeters;
        }
    }
}

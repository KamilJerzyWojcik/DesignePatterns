using System;

namespace AlgrythmStrategy2
{
    public interface IPainter
    {
        bool IsAvailable { get; }

        TimeSpan EstimateTimeToPaint(double sqMeters);

        double EstimateCompensation(double sqMeters);
    }
}

using System;
namespace UntanglingStructureCollectionObject
{
    public interface IPainter
    {
        bool IsAvailable { get; }

        TimeSpan EstimateTimeToPaint(double sqMeters);

        double EstimateCompensation(double sqMeters);
    }
}

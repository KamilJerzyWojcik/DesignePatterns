﻿using System;

namespace AlgrythmStrategy2
{
    public class ProportionalPainter : IPainter
    {
        public TimeSpan TimePerSqMeter { get; set; }

        public double DollarsPerHour { get; set; }

        public bool IsAvailable => true;


        public TimeSpan EstimateTimeToPaint(double sqMeters) =>
            TimeSpan.FromHours(TimePerSqMeter.TotalHours * sqMeters);

        public double EstimateCompensation(double sqMeters) =>
            EstimateTimeToPaint(sqMeters).TotalHours * DollarsPerHour;

    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Domain
{
    public interface IBowlingCalculator
    {
        int[] CalulatePoints(BaseFrame firstFrame);
    }

    public class BowlingCalculator : IBowlingCalculator
    {
        public int[] CalulatePoints(BaseFrame firstFrame)
        {
            var points = new List<int>();

            for (BaseFrame currentFrame = firstFrame; currentFrame != null; currentFrame = currentFrame.NextFrame)
            {
                int newTotal = points.ElementAtOrDefault(points.Count() - 1) + currentFrame.Calculate();

                points.Add(newTotal);
            }

            return points.ToArray<int>();
        }
    }
}
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Domain
{
    public interface IBowlingCalculator
    {
        int[] CalulatePoints(IEnumerable<int[]> scores);
    }

    public class BowlingCalculator : IBowlingCalculator
    {
        private IFrameLinker _linker;

        public BowlingCalculator(IFrameLinker linker)
        {
            _linker = linker;
        }

        public int[] CalulatePoints(IEnumerable<int[]> scores)
        {
            var firstFrameLink = _linker.LinkFrames(scores);

            var points = new List<int>();

            for (BaseFrame currentFrame = firstFrameLink; currentFrame != null; currentFrame = currentFrame.NextFrame)
            {
                int newTotal = points.ElementAtOrDefault(points.Count() - 1) + currentFrame.Calculate();

                points.Add(newTotal);
            }

            return points.ToArray<int>();
        }
    }
}
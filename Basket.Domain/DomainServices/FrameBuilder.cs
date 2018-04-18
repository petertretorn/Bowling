using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bowling.Domain
{
    public interface IFrameBuilder
    {
        BaseFrame BuildFrames(IEnumerable<int[]> points);
    }

    public class FrameBuilder : IFrameBuilder
    {
        public BaseFrame BuildFrames(IEnumerable<int[]> points)
        {
            var frames = points
                .Select(data => FrameFactory.Create(data[0], data[1]))
                .ToList();

            var initialFrame = LinkFrames(frames);

            return initialFrame;
        }

        public BaseFrame LinkFrames(IList<BaseFrame> frames)
        {
            var size = frames.Count();

            return frames
                .Select(SetLink(frames, size))
                .ToList()
                .First();
        }

        private Func<BaseFrame, int, BaseFrame> SetLink(IList<BaseFrame> frames, int size)
        {
            return (current, index) =>
            {
                current.NextFrame = (index < size - 1) ? frames[index + 1] : null;
                return current;
            };
        }
    }
}

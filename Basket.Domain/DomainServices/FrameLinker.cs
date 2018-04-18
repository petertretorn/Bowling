using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Domain
{
    public interface IFrameLinker
    {
        BaseFrame LinkFrames(IEnumerable<int[]> points);
    }

    public class FrameLinker : IFrameLinker
    {
        public BaseFrame LinkFrames(IEnumerable<int[]> points)
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

using System;

namespace Bowling.Domain
{
    public class SpareFrame : BaseFrame
    {
        public SpareFrame(int first, int second) : base(first, second) { }

        protected int ExstraShot => new Random().Next(0, 10);

        public override int Calculate()
        {
            return (HasNext)
                ? BaseScore() + NextFrame.FirstShot
                : BaseScore() + ExstraShot;
        }
    }
}

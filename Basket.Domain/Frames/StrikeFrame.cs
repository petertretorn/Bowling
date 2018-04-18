using System;

namespace Bowling.Domain
{
    public class StrikeFrame : SpareFrame
    {
        public StrikeFrame(int first, int second) : base(first, second) { }

        public override int Calculate()
        {
            if (!HasNext)
            {
                return BaseScore() + ( 2 * ExstraShot );
            }

            var strikePoints = IsDoubleStrike()
                ? CalculateDoubleStrike()
                : NextFrame.FirstShot + NextFrame.SecondShot;

            return BaseScore() + strikePoints;
        }

        private bool IsDoubleStrike() => NextFrame.IsStrike();

        private int CalculateDoubleStrike()
        {
            return (NextFrame.HasNext)
                ? NextFrame.FirstShot + NextFrame.NextFrame.FirstShot
                : NextFrame.FirstShot + ExstraShot;
        }
    }
}

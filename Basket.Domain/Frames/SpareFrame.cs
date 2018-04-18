using System.Collections.Generic;

namespace Bowling.Domain
{
    public class SpareFrame : BaseFrame
    {
        public SpareFrame(int first, int second) : base(first, second) { }
        
        public override int Calculate()
        {
            return BaseScore() + NextFrame.FirstShot;
        }
    }
}

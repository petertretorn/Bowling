using System;
using System.Collections.Generic;

namespace Bowling.Domain
{
    public class BaseFrame
    {
        public int FirstShot { get; private set; }

        public int SecondShot { get; private set; }

        public BaseFrame NextFrame { get; set; }

        public bool HasNext => NextFrame != null;
        
        public BaseFrame(int first, int second)
        {
            this.FirstShot = first;
            this.SecondShot = second;
        }
        
        protected int BaseScore() => FirstShot + SecondShot;

        public virtual int Calculate()
        {
            return BaseScore();
        }
    }
}

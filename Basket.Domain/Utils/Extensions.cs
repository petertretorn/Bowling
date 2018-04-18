using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Domain
{
    public static class Extensions
    {
        public static bool IsStrike(this BaseFrame frame)
        {
            return frame.FirstShot == 10;
        }
    }
}

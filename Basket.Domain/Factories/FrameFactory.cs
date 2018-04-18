using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Domain
{
    public static class FrameFactory
    {
        public static BaseFrame Create(int first, int second)
        {
            if (IsStrike(first))
            {
                return new StrikeFrame(first, second);
            }

            if (IsSpare(first, second))
            {
                return new SpareFrame(first, second);
            }

            return new BaseFrame(first, second);
        }

        public static bool IsStrike(int first) => first == 10;

        public static bool IsSpare(int first, int second) => !IsStrike(first) && first + second == 10;
    }
}

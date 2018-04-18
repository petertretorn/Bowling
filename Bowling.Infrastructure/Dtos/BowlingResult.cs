using System.Collections.Generic;

namespace Bowling.Infrastructure
{
    public class BowlingResponse
    {
        public IEnumerable<int[]> Points { get; set; }
        public string Token { get; set; }
    }
}
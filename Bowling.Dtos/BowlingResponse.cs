using System.Collections.Generic;

namespace Bowling.Dtos
{
    public class BowlingResponse
    {
        public IEnumerable<int[]> Points { get; set; }
        public string Token { get; set; }
    }
}
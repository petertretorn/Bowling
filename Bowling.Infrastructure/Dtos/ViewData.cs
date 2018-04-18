using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Infrastructure.Dtos
{
    public class ViewData
    {
        public bool Result { get; set; }
        public IEnumerable<int[]> Scores { get; set; }
        public IEnumerable<int> CalculatedPoints { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Dtos
{
    public class ValidationResponse
    {
        public bool Success { get; set; }
        public int[] Input { get; set; }
    }
}

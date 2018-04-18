using System;
using System.Collections.Generic;
using System.Text;

namespace Bowling.Infrastructure.Dtos
{
    public class ValidationPayload
    {
        public int[] points { get; set; }
        public string token { get; set; }
    }
}

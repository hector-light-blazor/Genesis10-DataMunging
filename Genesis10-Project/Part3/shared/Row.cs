using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared
{
    public class Row
    {
        public string Name { get; set; } = string.Empty;
        public int MaxValue { get; set; }
        public int MinValue { get; set; }
        public int CalculateDiff => Math.Abs(MinValue - MaxValue);

    }
}
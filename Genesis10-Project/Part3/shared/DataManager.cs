using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared
{
    public class DataManager
    {
        public List<Row> Rows {get; set;} = new();

        public Row GetSmallestDif => Rows.OrderBy(c => c.CalculateDiff).First();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Part2
{
    public class FootBallManager
    {
        public List<FootBallMapper> FootBallMapper {get; set;} = new();

        public FootBallMapper SmallestDif() 
        {
           
            return FootBallMapper.OrderBy(c => c.CalculateDiff).First();
        }
    }

    public class FootBallMapper
    {
        public string FootballTeam { get; set; } = string.Empty;

        public int ScoreFor {get; set;}

        public int ScoreAgainst {get; set;}

        public int CalculateDiff => Math.Abs(ScoreAgainst - ScoreFor);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace shared
{
    public static class Parser
    {
        public static Row FootBallParse(List<string> rows)
        {
             var result = new Row();
            int score = 0;
            for(var i = 0; i < rows.Count(); i++){
                if(i == 1)
                {
                result.Name = rows[i];
                }else if(i == 6)
                {
                    if(int.TryParse(rows[i], out score))
                    {
                        result.MaxValue = score;
                    }
                }
                else if(i == 8)
                {
                    if(int.TryParse(rows[i], out score))
                    {
                        result.MinValue = score;
                    }
                }
            }
            return result;
        }

        public static Row WeatherParse(List<string> rows)
        {
             var result = new Row();
            int number = 0;
            for(var index = 0; index < rows.Count(); index++){

                //Ensure that is only a digit
                var cleanData = new string(rows[index].Where(c => char.IsDigit(c)).ToArray());
            

                if(index == 0)
                {
                    if(int.TryParse(cleanData, out number))
                    {
                        result.Name = number.ToString();
                    }
                }else if(index == 1){
                    if(int.TryParse(cleanData, out number))
                    {
                        result.MaxValue = number;
                    }
                }else if(index == 2){
                    if(int.TryParse(cleanData, out number))
                    {
                        result.MinValue = number;
                    }
                }
                }
                return result;
        }
    }
}
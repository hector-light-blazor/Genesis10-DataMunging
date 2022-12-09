
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Part2;
List<string> GetData(string location)
{

    return System.IO.File.ReadAllLines(location).ToList();
}


//Function will remove the extra white space notneeded.
string CleanTextRow(string row)
{
     int n = 5;
    StringBuilder tmpbuilder = new StringBuilder(row.Length);
                for (int i = 0; i < n; ++i)
            {
                string scopy = row;
                bool inspaces = false;
                tmpbuilder.Length = 0;
 
                for (int k = 0; k < row.Length; ++k)
                {
                    char c = scopy[k];
 
                    if (inspaces)
                    {
                        if (c != ' ')
                        {
                            inspaces = false;
                            tmpbuilder.Append(c);
                        }
                    }
                    else if (c == ' ')
                    {
                        inspaces = true;
                        tmpbuilder.Append(' ');
                    }
                    else
                        tmpbuilder.Append(c);
                }
            }

            return tmpbuilder.ToString();
}

FootBallMapper MappRowData(List<string> row)
{
    var result = new FootBallMapper();
    int score = 0;
    for(var i = 0; i < row.Count(); i++){
        if(i == 1)
        {
           result.FootballTeam = row[i];
        }else if(i == 6)
        {
            if(int.TryParse(row[i], out score))
            {
                result.ScoreFor = score;
            }
        }
        else if(i == 8)
        {
            if(int.TryParse(row[i], out score))
            {
                result.ScoreAgainst = score;
            }
        }
    }
    return result;
}

FootBallManager Mapper = new();


List<string> FootBallData = GetData(@"./data/football.dat");


//Loop Through data
//Skip the first row since is header data: If needed just change i to 0; 
for(var i = 1; i < FootBallData.Count(); i++)
{
    var cleanRowData = CleanTextRow(FootBallData[i]);
    var RowDataCollection = cleanRowData.Split(" ")
                            .Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
    if(RowDataCollection.Count > 1)
    {
        var rowResponse = MappRowData(RowDataCollection);
        
        if(rowResponse != null)
            Mapper.FootBallMapper.Add(rowResponse);
    }

}

Console.WriteLine("FInal Results");

var FinalResults = Mapper.SmallestDif();
Console.WriteLine($"Team: {FinalResults.FootballTeam} : Agaisnt : {FinalResults.ScoreAgainst}, For : {FinalResults.ScoreFor}, DIF : {FinalResults.CalculateDiff}");


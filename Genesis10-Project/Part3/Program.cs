using shared;
using System.Text.Json;

List<string> FootballData = FileManager.GetData(@"./data/football.dat");
List<string> WeatherData = FileManager.GetData(@"./data/weather.dat");

DataManager FootballManager = new();

DataManager WeatherManager = new();

for(var i = 1; i < FootballData.Count(); i++)
{
    var Row = FootballData[i];
    var RowDataCollection = Row.Split(" ")
                            .Where(s => !string.IsNullOrWhiteSpace(s)).ToList();
                            // Console.WriteLine(JsonSerializer.Serialize(RowDataCollection));
   var RowResultsFootball = Parser.FootBallParse(RowDataCollection);
   FootballManager.Rows.Add(RowResultsFootball);
}

for(var i = 1; i < WeatherData.Count() - 1; i++)
{
    var Row = WeatherData[i];
    var RowDataCollection = Row.Split(" ")
                            .Where(s => !string.IsNullOrWhiteSpace(s)).Take(3).ToList();

    if(RowDataCollection.Count > 0) 
    {
        var RowResultsWeather = Parser.WeatherParse(RowDataCollection);
        WeatherManager.Rows.Add(RowResultsWeather);
    }                        
}


Console.WriteLine("Final Results");
Console.WriteLine("==============");


var FinalResultsForFootball = FootballManager.GetSmallestDif;
var FinalResultsForWeather = WeatherManager.GetSmallestDif;

Console.WriteLine($"Team: {FinalResultsForFootball.Name} : Agaisnt : {FinalResultsForFootball.MaxValue}, For : {FinalResultsForFootball.MinValue}, DIF : {FinalResultsForFootball.CalculateDiff}");


Console.WriteLine();


Console.WriteLine($"Day: {FinalResultsForWeather.Name} : Agaisnt : {FinalResultsForWeather.MaxValue}, For : {FinalResultsForWeather.MinValue}, DIF : {FinalResultsForWeather.CalculateDiff}");


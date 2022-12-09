


//Create empty mapper
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Shared;

//Function to Clean Raw Data by removing the extra spaces..
string FormatTextRow(string row)
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


//Process each row to a weather mapper.
//Need to process the data certain numbers have extrac characters..
WeatherMapper ConvertRowsToWeatherMapper(List<string> row)
{
    var Mapper = new WeatherMapper();
    int number = 0;
    for(var index = 0; index < row.Count(); index++){
        var cleanData = new string(row[index].Where(c => char.IsDigit(c)).ToArray());
    
            if(int.TryParse(cleanData, out number))

        if(index == 0)
        {
            if(int.TryParse(cleanData, out number))
            {
                Mapper.Day = number;
            }
        }else if(index == 1){
            if(int.TryParse(cleanData, out number))
            {
                Mapper.MaxTemp = number;
            }
        }else if(index == 2){
            if(int.TryParse(cleanData, out number))
            {
                Mapper.MinTemp = number;
            }
        }
    }
    return Mapper;
}


List<string> GetWeatherData()
{

    return System.IO.File.ReadAllLines(@"./data/weather.dat").ToList();
}


WeatherManager ManagerWeather  = new();

//Load the text data into List of of rows.
List<string> WeatherData = GetWeatherData();

//Loop Through data skip the first row.
for(var i = 1; i < WeatherData.Count() -1 ; i++){
    
    var rowSize = WeatherData[i].Count();
    var rowData = WeatherData[i];
    
    // Row Size needs to be bigger than zero if not is empty data..
    if(rowSize != 0) 
    {

    //This function will remove extra whitespace
       var cleanRow = FormatTextRow(rowData);

       List<string> splitRows = cleanRow.Split(' ').Where(s => !string.IsNullOrWhiteSpace(s))
       .Take(3).ToList();
       

       ManagerWeather.WeatherData.Add(ConvertRowsToWeatherMapper(splitRows));
    }
}


Console.WriteLine("Table Display Results");
Console.WriteLine("===============");
var tableResults = ManagerWeather.WeatherData.OrderBy(c => c.MinTemp).ToList();


//Just to display the data for visual purposes.
tableResults.ForEach(c => 
    Console.WriteLine(JsonSerializer.Serialize(c))
);

Console.WriteLine("===============");
Console.WriteLine("");

var FinalResults = ManagerWeather.GetDayOfSmallestTempSpread;


Console.WriteLine("Final Results");
Console.WriteLine("===============");
Console.WriteLine($"Day = {FinalResults}");

//Class Weather Will Map data from raw text to object data
//This class will be utilize for weather. dat file.
namespace Shared
{
        class WeatherMapper
    {
        public int Day { get; set; }
        public int MaxTemp { get; set; }
        public int MinTemp { get; set; }

        public int CalculateDif => Math.Abs(MinTemp - MaxTemp);
        
    }


    class WeatherManager
    {
        public List<WeatherMapper> WeatherData {get; set;} = new();

        public int GetDayOfSmallestTempSpread => WeatherData.OrderBy(c => c.CalculateDif).First().Day;
    }
}
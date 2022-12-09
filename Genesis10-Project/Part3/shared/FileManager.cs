using System.IO;
using System.Text;

namespace shared;
public static class FileManager
{

    //Remove Extra White Space
    static string RemoveExtraSpaceInRow(string row)
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
    public static List<string> GetData(string location)
    {
        if(!string.IsNullOrEmpty(location))
        {
            var Rows = File.ReadAllLines(location).ToList();
            Rows.ForEach(c => RemoveExtraSpaceInRow(c));
            return Rows.Where(c => c.Contains("--") == false).ToList();
        }
        else{
            throw new NullReferenceException("Location is Empty.");
        }
    }
}

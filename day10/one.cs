using System;
using System.Text.RegularExpressions;

class Reg
{
    public static void reg()
    {
        // string str = "abc123";
        // string str = "abc";
        // string str = "10 20 30";
        // string str = "Amount : 5000";
        // string str = "10A20B30C!@_";
        // string str = "10A20B30C!@_abc";
        // string str = "file.txt";
        // string str = "C:\abc\file.txt";
        // string str = "?C:\abc\file.txt?";
        // string str = "this is me hellow";
        // string pattern = @"\d";
        // string pattern = @"\d+";
        // string pattern = @"\d*";
        // string pattern = @"\D";
        // string pattern = @"\w";
        // string pattern = @"\W";
        //  string pattern = @"\\";
        //   string pattern = @"\?";
        // string pattern = @"\^hello";

        // MatchCollections  m = Regex.Matches(str, pattern);
        // Console.WriteLine(MatchCollection);
        // Console.WriteLine(Regex.IsMatch(str, pattern));

        //grouping 


        // string pattern = @"(?<year>\d{4})-(?<month>\d{2})-(?<date>\d{2})";
        // string str = "1992-04-24";
        // // string str = "24-03-2004";

        // Match match = Regex.Match(str, pattern);

        // if (match.Success)
        // {
        //     Console.WriteLine("Full Match: " + match.Value);
        //     Console.WriteLine("Year  : " + match.Groups["year"].Value);
        //     Console.WriteLine("Month : " + match.Groups["month"].Value);
        //     Console.WriteLine("Date  : " + match.Groups["date"].Value);
        // }

        // MatchCollection matches = Regex.Matches(str, pattern);

        // foreach (Match m in matches)
        // {
        //     Console.WriteLine("Matched: " + m.Value);
        //     Console.WriteLine(m.Value[0]);
        // }


        // string str = "apple";
        // string pattern = @"a...e";

        // MatchCollection matches = Regex.Matches(str, pattern);

        // foreach (Match m in matches)
        // {
        //     Console.WriteLine("Matched: " + m.Value); 
        // }

        string pattern = @"\b[\w.-]+@[\w.-]+\.\w{2,}\b";
        string str = "2002masoom@gmail.com";
        MatchCollection matches = Regex.Matches(str, pattern);

        foreach (Match m in matches)
        {
            Console.WriteLine("Matched: " + m.Value); 
        }
    }
}
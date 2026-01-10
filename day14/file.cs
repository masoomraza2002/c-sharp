using System;
using System.IO;

class Filee
{
    public static void filee()
    {
        File.WriteAllText("abc.txt" , "hello this is me");
        Console.WriteLine("data written to file");

        string content = File.ReadAllText("abc.txt");
        Console.WriteLine(content);
    }
}
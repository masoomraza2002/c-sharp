using System;

class Names
{
    public static void name()
    {
        String s = Console.ReadLine();
        foreach(char c in s){
            Console.WriteLine(c);
        }
    }
}
using System;

class Convertt
{
    public static void FeetToCM()
    {
        double ft = Convert.ToDouble(Console.ReadLine());
        double cm = ft * 3.48;
        Console.WriteLine($"length is {cm}");
    }
}
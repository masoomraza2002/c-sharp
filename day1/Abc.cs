using System;

class Abc
{
    public static void area()
    {
        double r = Convert.ToDouble(Console.ReadLine());
        double area = Math.PI * r * r;
        Console.WriteLine("Area = " + area);
    }    
}

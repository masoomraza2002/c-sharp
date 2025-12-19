using System;

class Large
{
    public static void Find()
    {
        int a = Convert.ToInt32(Console.ReadLine());
        int b = Convert.ToInt32(Console.ReadLine());
        int c = Convert.ToInt32(Console.ReadLine());

        if(a>b && a > c)
        {
            Console.WriteLine($"{a} is largest");
        } else if (b > c)
        {
            Console.WriteLine($"{b} is largest");
        }
        else
        {
            Console.WriteLine($"{c} is largest");
        }
    }
}
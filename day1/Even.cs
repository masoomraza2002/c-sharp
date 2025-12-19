using System;

class Even
{
    public static void Printt()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        if(n%2 == 0)
        {
            Console.WriteLine("even");
        }
        else
        {
            Console.WriteLine("odd");
        }
    }
}
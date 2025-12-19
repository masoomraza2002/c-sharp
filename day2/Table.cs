using System;

class Table
{
    public static void table()
    {
        for (int j = 20; j <= 30; j++)
        {            
            Console.WriteLine($"****   Table of {j}  ****\n");
            
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{j} X {i} = {j * i}");
            }
            Console.WriteLine("\n\n"); 
        }
    }
}
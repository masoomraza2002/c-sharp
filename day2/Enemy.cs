using System;

class Enemy()
{
    public static void enemy()
    {
        for(int i = 1; i <= 10; i++)
        {
            if(i == 4)
            {
                Console.WriteLine($"E{i} is invisble. Skipping E{i}");
                continue;
            }
            Console.WriteLine($"Player killed E{i}");
        }
        Console.Write("Game end");
    }
}
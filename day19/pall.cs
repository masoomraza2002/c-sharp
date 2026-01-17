using System;
using System.Threading.Tasks;

class Main3
{
    public static void main3()
    {
        Parallel.For(0, 5, i =>
        {
            Console.WriteLine($"Processing item {i}");
        });

        Console.ReadLine();  
    }
}

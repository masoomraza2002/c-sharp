using System;
using System.Collections.Generic;
using System.Linq;

class Ord
{
    public static void ord()
    {
        List<int> numbers = new List<int> { 5, 2, 8, 1, 3 };

        var asc = numbers.OrderBy(n => n);
        var desc = numbers.OrderByDescending(n => n);

        Console.WriteLine("Ascending");
        foreach (var n in asc)
        {
            Console.WriteLine(n);
        }

        Console.WriteLine("Descending");
        foreach (var n in desc)
        {
            Console.WriteLine(n);
        }
    }
}

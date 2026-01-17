using System;

class Main4
{
    public static void main4()
    {
        int[] num = new int[10];
        int sum = 0;
        // Parallel.For(0, num.Length , i =>
        // {
        //     sum += i;
        // });
        Parallel.For(
            0,
             num.Length, 
             () => 0,
            (i, loopstate, localSum) =>
            {
                return localSum + num[i];
            },
            localSum =>
            {
                Interlocked.Add(ref sum, localSum);
            });
        Console.WriteLine("sum : " + sum);
    }
}
using System;

class Call
{
    public static void fun(ref int x)
    {
        x += 10;
        Console.WriteLine(x);
    }
    public static void fun2(int x)
    {
        x += 10;
        Console.WriteLine(x);
    }

    public static void call()
    {
        int x = 10;
        fun2(x);
        Console.WriteLine(x);
        fun(ref x);
        Console.WriteLine(x);
    }
}
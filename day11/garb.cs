using System;
class Gbg
{
    public static void gbg()
    {
        Console.WriteLine("creatng objects...");
        for (int i = 0; i < 10; i++)
        {
            MyClass obj = new MyClass();
        }

        Console.WriteLine("Foring garbage colllections");
        GC.Collect();
        GC.WaitForPendingFinalizers();

        Console.WriteLine("Garbage collection completed");
    }
}
class MyClass
{
    ~MyClass()
    {
        Console.WriteLine("Finalizer called object colledcted");
    }
}
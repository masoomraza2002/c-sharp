using System;
using System.Threading;

class Main2
{
    public static int counter = 0;
    public static void main2()
    {
        Thread t1 = new Thread(Increment);
        Thread t2 = new Thread(Increment);
        t1.Start();
        t2.Start();
        t1.Join();
        t2.Join();
        Console.WriteLine("final val "+counter);
    }

    public static void Increment()
    {
        for(int i = 0; i < 100000; i++)
        {
            counter++;
        }
    }


}
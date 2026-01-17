using System;

class One
{
    public static void one()
    {
        Thread worker = new Thread(DoWork);
        worker.Start();
        Console.WriteLine("main");
    }

    public static  void DoWork()
    {
        for(int i = 1; i <= 5; i++)
        {
            Console.WriteLine("worker thread "+i);
            Thread.Sleep(1000);
        }
    }
}
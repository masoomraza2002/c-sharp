// using System;
// using System.Diagnostics;

// class Main1
// {
//     public static void main1()
//     {
//         Process p1 = Process.GetCurrentProcess();
//         Console.WriteLine("current process id " + p1.Id);
//         Console.WriteLine("current process name " + p1.ProcessName);
//         Console.WriteLine("current process name " + p1.ProcessName);        
//     }
// }


using System;
using System.Threading;

class Main1
{
    public static void main1()
    {
        // Create a new thread
        Thread worker = new Thread(DoWork);

        // Start the thread
        worker.Start();

        Console.WriteLine("Main thread continues...");

        // Optional: Wait for worker thread to finish
        worker.Join();
        Console.WriteLine("Main thread finished");
    }

    public static void DoWork()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Worker thread: " + i);
            Thread.Sleep(500); // Simulate work
        }
    }
}
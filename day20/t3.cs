using System;

class Main3
{
    public static void main3()
    {
        // try
        // {
        //     Task t = Task.Run(()=>throw new Exception("Taks error"));
        //     t.Wait();
        // }
        // catch(AggregateException ex)
        // {
        //     Console.WriteLine(ex.InnerException[0].Message);
        // }

        Task t1 = Task.Run(()=>Console.WriteLine("task 1"));
        Task t2 = Task.Run(()=>Console.WriteLine("task 2"));

        Task.WhenAll(t1,t2).ContinueWith(t => Console.WriteLine("All task completed"));
    }


}
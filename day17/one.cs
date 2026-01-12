using System;
using System.Data;
using System.Diagnostics;
/*class Debugginh
{
    public static void Main(string[] args)
    {
        Trace.Listeners.Add(new ConsoleTraceListener());
        Trace.WriteLine("Application Started");

        int a = 10;
        int b = 0;
        try
        {
            int result = a / b;
            System.Console.WriteLine(result);
        }
        catch (Exception ex)
        {
            Trace.WriteLine("Exception occured: " + ex.Message);
        }

        Trace.WriteLine("Application Ended");

    }
}*/

class Main1
{
    public static void main1()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());

        Trace.WriteLine("Program started");

        PerformCalculation(10, 5);
        PerformCalculation(10, 0);   // Error case

        DebugLoop();  

        Trace.WriteLine("Program ended");
    }

    static void PerformCalculation(int a, int b)
    {
        Trace.WriteLine($"Entering PerformCalculation | a={a}, b={b}");

        if (b == 0)
        {
            Trace.WriteLine("Error: Division by zero detected");
            return;
        }

        int result = Divide(a, b);

        Trace.WriteLine($"Calculation successful | Result={result}");
        Trace.WriteLine("Exiting PerformCalculation");
    }

    static int Divide(int x, int y)
    {
        Trace.WriteLine($"Dividing values | x={x}, y={y}");
        return x / y;
    }

    // LOOP DEBUGGING METHOD (FROM IMAGE)
    static void DebugLoop()
    {
        Trace.WriteLine("Starting loop debugging");

        int total = 0;

        for (int i = 1; i <= 5; i++)
        {
            total += i;   // <-- Put breakpoint here
            Trace.WriteLine($"i={i}, total={total}");
        }

        Trace.WriteLine($"Final total value = {total}");
        Trace.WriteLine("Ending loop debugging");
    }
}
using System;
using System.IO;

try
{
    try
    {
        File.ReadAllText("transactions.txt");
    }
    catch (IOException ioEx)
    {
        throw new ApplicationException(
            "Unable to load transaction data",
            ioEx
        );
    }
}
catch (Exception ex)
{
    Console.WriteLine("Message: " + ex.Message);
    Console.WriteLine("Root Cause: " + ex.InnerException.Message);
}
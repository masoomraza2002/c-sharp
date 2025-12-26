using System;
using System.Security.Cryptography.X509Certificates;

class Two
{
    public static void two()
    {
        //resize
        int[] num =  {1,2};
        Array.Resize(ref num , 4);
        foreach(int i in num)
        {
            Console.Write(i+" ");
        }
        Console.WriteLine();

        // Array.Resize( num , 4);
        // foreach(int i in num)
        // {
        //     Console.Write(i+" ");
        // }
        // Console.WriteLine();

        // Array.Resize( num , 1);
        // foreach(int i in num)
        // {
        //     Console.Write(i+" ");
        // }
        // Console.WriteLine();

        // Array.Resize(ref num , 1);
        // foreach(int i in num)
        // {
        //     Console.Write(i+" ");
        // }
        // Console.WriteLine();

        Console.WriteLine(Array.Exists(num , x=>x>25));
    }
}
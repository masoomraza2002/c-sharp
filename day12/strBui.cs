using System;
using System.Text;

class One
{
    public static void one()
    {
        // StringBuilder sb = new StringBuilder();
        // sb.Append("Text");
        // sb.Insert(0, "statrt ");
        // Console.WriteLine(sb.ToString());
        Console.WriteLine(GC.GetTotalMemory(false));
        StringBuilder sb = new StringBuilder();
        for(int i = 0; i < 10000; i++)
        {
            sb.Append(i);
        }
        String res = sb.ToString();
        Console.WriteLine(GC.GetTotalMemory(false));


        StringBuilder sb1 = new StringBuilder("Hello");
        StringBuilder sb2 = new StringBuilder("Hello");
        Console.WriteLine(sb1.Equals(sb2));
        StringBuilder sb3 = sb2;
        Console.WriteLine(sb3.Equals(sb2));
        Console.WriteLine(object.ReferenceEquals(sb1,sb2));
        Console.WriteLine(object.ReferenceEquals(sb1,sb3));
        Console.WriteLine(sb1 == sb2);
        String st1 = "Hello";
        String st2 = "Hello";

        Console.WriteLine(st1 == st2);
    }
}
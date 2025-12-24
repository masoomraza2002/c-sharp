using  System;
using System.Reflection.Metadata.Ecma335;
class Portfolio
{
    public string Name;

    public override bool Equals(object obj)

    {
        Portfolio p = obj as Portfolio;
        return (p != null && p.Name == Name);
    }
    
}

class Main2
{
    public static void main2()
    {
        Portfolio p1 = new Portfolio{Name = "Grow"};
        Portfolio p2 = new Portfolio{Name = "Grow"};

        Console.WriteLine(p1.GetHashCode());
        Console.WriteLine(p2.GetHashCode());
    }
}
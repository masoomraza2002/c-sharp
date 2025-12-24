using System;

class Gen
{
    public T Genr<T>(T a,T b)
    {
        return a;
    }
}

class Main4
{
    public static void main4()
    {
        Gen gg = new Gen();
        int g1 = gg.Genr(10,20);
        double g2 = gg.Genr(10.80,14);
        string g3 = gg.Genr("abc","def");

        Console.WriteLine(g1);
        Console.WriteLine(gg.Genr(10.29,10));
        Console.WriteLine(g2);
        Console.WriteLine(g3);
    }
}
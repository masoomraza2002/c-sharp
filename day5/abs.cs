using System;

abstract class Abs
{
    public abstract void Show();
    public abstract void Heal();
}

class Hello : Abs
{ 
    public override void Show()
    {
        Console.WriteLine("this is hello");
    }
    public override void Heal()
    {
        Console.WriteLine("this is hello");
    }
}

class Main1
{
    public static void main1()
    {
        Hello obj = new Hello();
        obj.Show();
    }
}
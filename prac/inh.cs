using System;

public class Account
{
    protected double bal;
    public Account(double bal)
    {
        this.bal = bal;
    }
    public virtual void cal()
    {
        Console.WriteLine($"bal is {bal}");
    }
}

public class saving : Account
{
    public saving(double bal):base(bal){}

    public override void cal()
    {
        Console.WriteLine($"bal {bal*5}");
    }
}

public class Premium : saving
{
    public Premium(double bal):base(bal){}

    public override void cal()
    {
        Console.WriteLine($"bal {bal*10}");
    }
}

class Main1()
{
    public static void main1()
    {
        Account a1 = new saving(100);
        a1.cal();

        Account a2 = new Premium(100);
        a2.cal();


    }
}
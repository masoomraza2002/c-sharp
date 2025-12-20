using System;

class Wallet
{
    private double money;

    public Wallet(double money)
    {
        this.money = money;
    }

    public double AddMoney(double amount, double amount2)
    {
        money += amount + amount2;
        return money;
    }

    public double AddMoney(int amount, int amount2)
    {
        return AddMoney((double)amount, (double)amount2);
    }

    public double AddMoney(double amount, int amount2)
    {
        return AddMoney(amount, (double)amount2);
    }

    public double GetMoney()
    {
        return money;
    }
}

class Wall
{
    public static void wall()
    {
        Wallet wt = new Wallet(1000);

        Console.WriteLine(wt.AddMoney(1000.5151, 1000.115));
        Console.WriteLine(wt.AddMoney(1000, 1000));
        Console.WriteLine(wt.AddMoney(1000, 1000.651));

        Console.WriteLine(wt.GetMoney());
    }
}
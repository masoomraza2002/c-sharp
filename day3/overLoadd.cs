using System;

class Over
{
    private int money;

    public Wallet(int money)
    {
        this.money = money;
    }

    public void add(int amount)
    {
        money += amount;
    }


    public void add(int amount1, int amount2)
    {
        money += amount;
    }

    public void add(double amount)
    {
        money += (int)amount;
    }
}

class OverLoad
{
    public static void ops()
    {
        Wallet wt = new Wallet(1000);
        wt.add(3434);
        wt.add(3434, 1000);
        wt.add(100.6516);
        Console.WriteLine(wt.getMoney());
    }
}
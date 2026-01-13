using System;

// public interface Pay
// {
//     void makePay(double amount);
// }

// public class Card : Pay
// {
//     public void makePay(double amount)
//     {
//         Console.WriteLine($"card payment of {amount}");
//     }
// }

// public class UPI : Pay
// {
//     public void makePay(double amount)
//     {
//         Console.WriteLine($"upi payment of {amount}");
//     }
// }

// class Intf
// {
//     public static void intf()
//     {
//         Pay pay;
//         pay = new Card();
//         pay.makePay(100);

//         pay = new UPI();
//         pay.makePay(100);
//     }
// }




public interface plug{
    void on();
    void off();
}

public interface connect
{
    void connnectWifi();
}

public class TV : plug, connect
{
    public void on()
    {
        Console.WriteLine("tv on");
    }
    public void off()
    {
        Console.WriteLine("tv off");
    }

    public void connnectWifi()
    {
        Console.WriteLine("wifi connected"); 
    }
}

class Intf
{
    public static void intf()
    {
        TV tv  = new TV();
        tv.connnectWifi();
        tv.off();
        tv.on();
    }
}
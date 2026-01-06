using System;

delegate void PaymentDele(int amou);
class PaymentService
{
    public void Pay(int amou)
    {
        Console.WriteLine($"payemtn done : {amou}");
    }
}


class Main1
{
    public static void main1()
    {
        PaymentService ser  =  new PaymentService();
        PaymentDele del = ser.Pay;
        del(4000);
    }
}
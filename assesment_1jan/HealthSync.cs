using System;
using System.Text.RegularExpressions;

public abstract class Consultant
{
    protected double tot;
    public abstract double CalGrossPay();
    public virtual double TDS()
    {
        if (tot <= 5000)
        {
            return 0.05 * tot;
        }
        else
        {
            return 0.15 * tot;
        }
    }
    public bool validateConsultant(String id)
    {
        return Regex.IsMatch(id, @"^DR[0-9]{4}");
    }
}

class InHouse : Consultant
{
    private int count;
    private double rate;
    public InHouse(int count, double rate)
    {
        this.count = count;
        this.rate = rate;
    }
    public override double CalGrossPay()
    {
        tot = count * rate;
        return tot;
    }
}

class Visiting : Consultant
{
    private int count;
    private double rate;

    public Visiting(int count, double rate)
    {
        this.count = count;
        this.rate = rate;
    }
    public override double CalGrossPay()
    {
        tot = count * rate;
        return tot;
    }
    public override double TDS()
    {
        return 0.1 * tot;
    }
}


class Health
{
    public static void health()
    {
        Console.WriteLine("enter you id");
        string id = Console.ReadLine();

        Console.WriteLine("enter service (inhouse , visiting)");
        string service = Console.ReadLine().ToLower();

        Console.WriteLine("Enter count:");
        int count = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter rate:");
        double rate = double.Parse(Console.ReadLine());

        Consultant consultant;

        if (service == "inhouse")
            consultant = new InHouse(count, rate);
        else
            consultant = new Visiting(count, rate);


        if (!consultant.validateConsultant(id))
        {
            Console.WriteLine("Invalid Consultant ID");
            return;
        }

        double gross = consultant.CalGrossPay();
        double tax = consultant.TDS();

        Console.WriteLine($"Gross Pay : {gross}");
        Console.WriteLine($"TDS       : {tax}");
        Console.WriteLine($"Net Pay   : {gross - tax}");
    }
}
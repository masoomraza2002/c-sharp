class InvalidTierException : Exception
{
    public InvalidTierException(string message) : base(message){}
}

class Memebership
{
    public string Tier { get; set; }
    public int Duration { get; set; }
    public double PricePM { get; set; }

    public bool validateEnrolment()
    {
        if (Tier != "Basic" || Tier != "Elite" || Tier != "Premium")
        {
            throw new InvalidTierException("Invalid memebership tieer enrolled");
        }
        if (Duration <= 0)
        {
            throw new InvalidTierException("duration must be greater than 0");
        }
        return true;
    }

    public double calaulteBill()
    {
        double tot = Duration * PricePM;
        double discount;
        if (Tier == "Basic")
        {
            discount = 0.02;
        }
        else if (Tier == "Premium")
        {
            discount = 0.07;
        }
        else
        {
            discount = 0.12;
        }

        return tot - (tot * discount);
    }
}

class Gym
{
    public static void gym()
    {
        try
        {
            Memebership member = new Memebership();

            Console.WriteLine("ENEter tier");
            member.Tier = Console.ReadLine();

            Console.WriteLine("ENEter Duration");
            member.Duration = int.Parse(Console.ReadLine());

            Console.WriteLine("ENEter Price");
            member.PricePM = double.Parse(Console.ReadLine());

            member.validateEnrolment();
            double bill = member.calaulteBill();

            Console.WriteLine($"Final amount : {bill:F2}");

        }
        catch (InvalidTierException ex)
        {
            Console.WriteLine("Tier error : "+ ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error : "+ex.Message);
        }
    }
}
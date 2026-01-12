using System;
 
public class Chocolate
{
    public string Flavour { get; set; }
    public int Quantity { get; set; }
    public int PricePerUnit { get; set; }
    public double TotalPrice { get; set; }
    public double DiscountedPrice { get; set; }

    public bool ValidateChocolateFlavour()
    {
        if (Flavour == "Dark" || Flavour == "Milk" || Flavour == "White")
            return true;

        return false;
    }
} 
public class Suger
{
    public static Chocolate CalculateDiscountedPrice(Chocolate chocolate)
    {
        chocolate.TotalPrice = chocolate.Quantity * chocolate.PricePerUnit;

        double discountPercentage = 0;

        if (chocolate.Flavour == "Dark")
            discountPercentage = 18;
        else if (chocolate.Flavour == "Milk")
            discountPercentage = 12;
        else if (chocolate.Flavour == "White")
            discountPercentage = 6;

        chocolate.DiscountedPrice =
            chocolate.TotalPrice - (chocolate.TotalPrice * discountPercentage / 100);

        return chocolate;
    }

    public static void suger()
    {
        Chocolate chocolate = new Chocolate();

        Console.WriteLine("Enter Chocolate Flavour:");
        chocolate.Flavour = Console.ReadLine();

        Console.WriteLine("Enter Quantity:");
        chocolate.Quantity = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Price Per Unit:");
        chocolate.PricePerUnit = int.Parse(Console.ReadLine());

        if (!chocolate.ValidateChocolateFlavour())
        {
            Console.WriteLine("Invalid flavour");
            return;
        }

        chocolate = CalculateDiscountedPrice(chocolate);

        Console.WriteLine("\n--- BILL DETAILS ---");
        Console.WriteLine("Flavour          : " + chocolate.Flavour);
        Console.WriteLine("Quantity         : " + chocolate.Quantity);
        Console.WriteLine("Price Per Unit   : " + chocolate.PricePerUnit);
        Console.WriteLine("Total Price      : " + chocolate.TotalPrice);
        Console.WriteLine("Discounted Price : " + chocolate.DiscountedPrice);
    }
} 













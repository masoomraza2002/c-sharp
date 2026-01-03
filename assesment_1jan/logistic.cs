using System;
 public class Shipment
{
    public string ShipmentCode { get; set; }
    public string TransportMode { get; set; }
    public double Weight { get; set; }
    public int StorageDays { get; set; }
}

public class ShipmentDetails : Shipment
{
    public bool ValidateShipmentCode()
    {
        if (ShipmentCode == null || ShipmentCode.Length != 7)
            return false;

        if (!ShipmentCode.StartsWith("GC#"))
            return false;

        string digitsPart = ShipmentCode.Substring(3);
        return int.TryParse(digitsPart, out _);
    }

    public double CalculateTotalCost()
    {
        double ratePerKg;

        if (TransportMode == "Sea")
            ratePerKg = 15.00;
        else if (TransportMode == "Air")
            ratePerKg = 50.00;
        else if (TransportMode == "Land")
            ratePerKg = 25.00;
        else
            ratePerKg = 0;

        double totalCost = (Weight * ratePerKg) + Math.Sqrt(StorageDays);
        return Math.Round(totalCost, 2);
    }
} 
public class Logistic
{
    public static void logistic()
    {
        ShipmentDetails shipment = new ShipmentDetails();

        Console.WriteLine("Enter Shipment Code:");
        shipment.ShipmentCode = Console.ReadLine();

        if (!shipment.ValidateShipmentCode())
        {
            Console.WriteLine("Invalid shipment code");
            return;
        }

        Console.WriteLine("Enter Transport Mode (Sea / Air / Land):");
        shipment.TransportMode = Console.ReadLine();

        Console.WriteLine("Enter Weight:");
        shipment.Weight = double.Parse(Console.ReadLine());

        Console.WriteLine("Enter Storage Days:");
        shipment.StorageDays = int.Parse(Console.ReadLine());

        double cost = shipment.CalculateTotalCost();

        Console.WriteLine($"Total Shipment Cost: {cost:F2}");
    }
} 

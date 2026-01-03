using System;
 
class Computer
{
    public string Processor { get; set; }
    public int RamSize { get; set; }           
    public int HardDiskSize { get; set; }     
    public int GraphicCard { get; set; }      

    protected double GetProcessorCostForDesktop()
    {
        return Processor switch
        {
            "i3" => 1500,
            "i5" => 3000,
            "i7" => 4500,
            _ => 0
        };
    }

    protected double GetProcessorCostForLaptop()
    {
        return Processor switch
        {
            "i3" => 2500,
            "i5" => 5000,
            "i7" => 6500,
            _ => 0
        };
    }
}  
class Desktop : Computer
{
    public int MonitorSize { get; set; }      
    public int PowerSupplyVolt { get; set; }   

    public double DesktopPriceCalculation()
    {
        return GetProcessorCostForDesktop()
             + (RamSize * 200)
             + (HardDiskSize * 1500)
             + (GraphicCard * 2500)
             + (MonitorSize * 250)
             + (PowerSupplyVolt * 20);
    }
} 
class Laptop : Computer
{
    public int DisplaySize { get; set; }   
    public int BatteryVolt { get; set; }    

    public double LaptopPriceCalculation()
    {
        return GetProcessorCostForLaptop()
             + (RamSize * 200)
             + (HardDiskSize * 1500)
             + (GraphicCard * 2500)
             + (DisplaySize * 250)
             + (BatteryVolt * 20);
    }
} 
class Tech 
{
    public static void tech()
    {
        Console.WriteLine("Enter system type (laptop / desktop):");
        string systemType = Console.ReadLine().ToLower();

        Console.WriteLine("Enter processor (i3 / i5 / i7):");
        string processor = Console.ReadLine().ToLower();

        Console.WriteLine("Enter RAM size (GB):");
        int ram = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Hard Disk size (TB):");
        int disk = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Graphic Card size (GB):");
        int graphics = int.Parse(Console.ReadLine());

        double finalPrice;

        if (systemType == "desktop")
        {
            Desktop desktop = new Desktop
            {
                Processor = processor,
                RamSize = ram,
                HardDiskSize = disk,
                GraphicCard = graphics
            };

            Console.WriteLine("Enter Monitor size (inches):");
            desktop.MonitorSize = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Power Supply Voltage:");
            desktop.PowerSupplyVolt = int.Parse(Console.ReadLine());

            finalPrice = desktop.DesktopPriceCalculation();

            Console.WriteLine("\n--- PURCHASE SUMMARY ---");
            Console.WriteLine("System       : Desktop");
            Console.WriteLine("Processor    : " + desktop.Processor);
            Console.WriteLine("Final Price  : " + finalPrice);
        }
        else if (systemType == "laptop")
        {
            Laptop laptop = new Laptop
            {
                Processor = processor,
                RamSize = ram,
                HardDiskSize = disk,
                GraphicCard = graphics
            };

            Console.WriteLine("Enter Display size (inches):");
            laptop.DisplaySize = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Battery Voltage:");
            laptop.BatteryVolt = int.Parse(Console.ReadLine());

            finalPrice = laptop.LaptopPriceCalculation();

            Console.WriteLine("\n--- PURCHASE SUMMARY ---");
            Console.WriteLine("System       : Laptop");
            Console.WriteLine("Processor    : " + laptop.Processor);
            Console.WriteLine("Final Price  : " + finalPrice);
        }
        else
        {
            Console.WriteLine("Invalid system type selected.");
        }
    }
} 
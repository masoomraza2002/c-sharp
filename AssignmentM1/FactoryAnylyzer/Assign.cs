using System;
class Robot
{
    private double armPrecision;
    private int workerDensity;
    private string machineryState;

    public Robot(double armPrecision, int workerDensity, string machineryState)
    {
        armPrecision = armPrecision;
        workerDensity = workerDensity;
        machineryState = machineryState;
    }

    public double Arm
    {
        get
        {
            return armPrecision;
        }
        set
        {
            if (value < 0.0 || value > 1.0)
            {
                Console.WriteLine("Error: armPrecision must be in range of 0.0 to 1.0");
            }
            else
            {
                armPrecision = value;
            }
        }
    }

    public int Work
    {
        get
        {
            return workerDensity;
        }
        set
        {
            if (value < 1 || value > 20)
            {
                Console.WriteLine("Error: armPrecision must be in range of 0.0 to 1.0");
            }
            else
            {
                workerDensity = value;
            }
        }
    }

    public string Machine
    {
        get
        {
            return machineryState;
        }
        set
        {
            if (value != "Worn" && value != "Faulty" && value != "Critical")
            {
                Console.WriteLine("Unstopable  machine state");
            }
            else
            {
                machineryState = value;
            }
        }
    }

    private double getMachineFact()
    {

        switch (machineryState)
        {
            case "Worn":
                return 1.3;
            case "Faulty":
                return 2.0;
            case "Critical":
                return 3.0;
            default:
                return 0.0;
        }
    }


    public double CalculateHazardRisk(double armPrecision, int workerDensity, string machineryState)
    {
        double machineFactor = getMachineFact();
        return ((1.0 - armPrecision) * 15.0) + (workerDensity + machineFactor);
    }
}


class Main1
{
    public static void main1()
    {
        Console.Write("Enter arm precision (0.0–1.0): ");
        double arm = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter worker density (1–20): ");
        int workers = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter machine state (Worn/Faulty/Critical): ");
        string state = Console.ReadLine();

        Robot robot = new Robot(arm, workers, state);

        double risk = robot.CalculateHazardRisk(arm, workers, state);
        Console.WriteLine($"Hazard Risk Score: {risk}");
    }
}

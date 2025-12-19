using System;
class Bank()
{
    public static void bank()
    {
        Console.Write("Enter your Age : ");
        int age = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your monthy income : ");
        int income = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter your current balance : ");
        int balance = Convert.ToInt32(Console.ReadLine());



        while (true)
        {
            Console.WriteLine("Press 1 for Check Loan eligiblity/n " +
            "Press 2 for Check income tax /n " +
            "Press 3 for Enter transactions /n " +
            "Press 4 for exit");

            int key = Convert.ToInt32(Console.ReadLine());
            if (key == 4) break;

            switch (key)
            {
                case 1:
                    if (age >= 21 && income >= 30000)
                    {
                        Console.WriteLine("You are eligible for LOAN");
                    }
                    else
                    {
                        Console.WriteLine("You are NOT eligible for LOAN");
                    }
                    break;

                case 2:
                    double ann = 12.00 * (double)income;
                    if (ann <= 250000)
                    {
                        Console.WriteLine($"Tax is {0}");
                    }
                    else if (ann <= 500000)
                    {
                        Console.WriteLine($"Tax is {0.05 * ann}");
                    }
                    else if (ann <= 1000000)
                    {
                        Console.WriteLine($"Tax is {0.2 * ann}");
                    }
                    else
                    {
                        Console.WriteLine($"Tax is {0.3 * ann}");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter 5 transactions:");
                    for (int i = 1; i <= 5; i++)
                    {
                        int amount = Convert.ToInt32(Console.ReadLine());
                        if (amount < 0) continue;
                        balance += amount;
                    }
                    Console.WriteLine($"Your final balance is {balance}");
                    break;
                default:
                    break;
            }
            }
        }
    }

using System;

class Debit
{ 
    public static void ATMWithdrawalLimit()
    {
        int dailyLimit = 40000;

        Console.Write("Enter withdrawal amount: ");
        int amount = int.Parse(Console.ReadLine());

        if (amount <= dailyLimit)
            Console.WriteLine("Withdrawal permitted within daily limit.");
        else
            Console.WriteLine("Daily ATM withdrawal limit exceeded.");
    }
     
    public static void EMIBurdenCheck()
    {
        Console.Write("Enter monthly income: ");
        double income = double.Parse(Console.ReadLine());

        Console.Write("Enter EMI amount: ");
        double emi = double.Parse(Console.ReadLine());

        double maxEmi = income * 0.40;

        if (emi <= maxEmi)
            Console.WriteLine("EMI is financially manageable.");
        else
            Console.WriteLine("EMI exceeds safe income limit.");
    }

    public static void DailySpending()
    {
        Console.Write("Enter number of debit transactions: ");
        int n = int.Parse(Console.ReadLine());

        int total = 0;

        for (int i = 1; i <= n; i++)
        {
            Console.Write("Enter amount for transaction " + i + ": ");
            total += int.Parse(Console.ReadLine());
        }

        Console.WriteLine("Total debit amount for the day: ₹" + total);
    }

    public static void MinimumBalanceCheck()
    {
        int minBalance = 2000;

        Console.Write("Enter current balance: ");
        int balance = int.Parse(Console.ReadLine());

        if (balance < minBalance)
            Console.WriteLine("Minimum balance not maintained. Penalty applicable.");
        else
            Console.WriteLine("Minimum balance requirement satisfied.");
    }
}

class Credit
{
    public static void NetSalary()
    {
        Console.Write("Enter gross salary: ");
        double gross = double.Parse(Console.ReadLine());

        double deduction = gross * 0.10;
        double netSalary = gross - deduction;

        Console.WriteLine("Net salary credited: ₹" + netSalary);
    }

    public static void FDMaturity()
    {
        Console.Write("Enter principal amount: ");
        double p = double.Parse(Console.ReadLine());

        Console.Write("Enter rate of interest: ");
        double r = double.Parse(Console.ReadLine());

        Console.Write("Enter time (years): ");
        double t = double.Parse(Console.ReadLine());

        double interest = (p * r * t) / 100;
        double maturity = p + interest;

        Console.WriteLine("Fixed Deposit maturity amount: ₹" + maturity);
    }

    public static void RewardPoints()
    {
        Console.Write("Enter total credit card spending: ");
        int spending = int.Parse(Console.ReadLine());

        int points = spending / 100;

        Console.WriteLine("Reward points earned: " + points);
    }

    public static void BonusEligibility()
    {
        Console.Write("Enter annual salary: ");
        int salary = int.Parse(Console.ReadLine());

        Console.Write("Enter years of service: ");
        int years = int.Parse(Console.ReadLine());

        if (salary >= 500000 && years >= 3)
            Console.WriteLine("Employee is eligible for bonus.");
        else
            Console.WriteLine("Employee is not eligible for bonus.");
    }
}

class Finance
{
    public static void finance()
    {
        int choice;

        do
        {
            Console.WriteLine("\n--- Finance Management System ---");
            Console.WriteLine("1. Debit Operations");
            Console.WriteLine("2. Credit Operations");
            Console.WriteLine("3. Exit");
            Console.Write("Enter your choice: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n--- Debit Menu ---");
                    Console.WriteLine("1. ATM Withdrawal Limit");
                    Console.WriteLine("2. EMI Burden Check");
                    Console.WriteLine("3. Daily Spending");
                    Console.WriteLine("4. Minimum Balance Check");
                    Console.Write("Enter choice: ");

                    int d = int.Parse(Console.ReadLine());

                    switch (d)
                    {
                        case 1: Debit.ATMWithdrawalLimit(); break;
                        case 2: Debit.EMIBurdenCheck(); break;
                        case 3: Debit.DailySpending(); break;
                        case 4: Debit.MinimumBalanceCheck(); break;
                        default: Console.WriteLine("Invalid Debit option"); break;
                    }
                    break;

                case 2:
                    Console.WriteLine("\n--- Credit Menu ---");
                    Console.WriteLine("1. Net Salary Calculation");
                    Console.WriteLine("2. FD Maturity Calculation");
                    Console.WriteLine("3. Reward Points");
                    Console.WriteLine("4. Bonus Eligibility");
                    Console.Write("Enter choice: ");

                    int c = int.Parse(Console.ReadLine());

                    switch (c)
                    {
                        case 1: Credit.NetSalary(); break;
                        case 2: Credit.FDMaturity(); break;
                        case 3: Credit.RewardPoints(); break;
                        case 4: Credit.BonusEligibility(); break;
                        default: Console.WriteLine("Invalid Credit option"); break;
                    }
                    break;

                case 3:
                    Console.WriteLine("Exiting program...");
                    break;

                default:
                    Console.WriteLine("Invalid main menu choice");
                    break;
            }

        } while (choice != 3);
    }
}

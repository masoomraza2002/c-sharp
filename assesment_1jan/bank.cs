using System;
 
public class Account
{
    public string AccountNumber { get; set; }
    public decimal Balance { get; set; }

    public decimal Deposit(decimal amount)
    {
        try
        {
            if (amount <= 0)
                throw new ArgumentException("Deposit amount must be positive.");

            Balance += amount;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }

        return Balance;
    }

    public decimal Withdraw(decimal amount)
    {
        try
        {
            if (amount <= 0)
                throw new ArgumentException("Withdrawal amount must be positive.");

            if (amount > Balance)
                throw new InvalidOperationException("Insufficient funds.");

            Balance -= amount;
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }

        return Balance;
    }
} 
 
public class Bank
{
    public static void bank()
    {
        Account account = new Account();

        Console.WriteLine("Enter Account Number:");
        account.AccountNumber = Console.ReadLine();

        Console.WriteLine("Enter Initial Balance:");
        account.Balance = decimal.Parse(Console.ReadLine());

        Console.WriteLine("\nChoose Operation:");
        Console.WriteLine("1. Deposit");
        Console.WriteLine("2. Withdraw");

        int choice = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter Amount:");
        decimal amount = decimal.Parse(Console.ReadLine());

        if (choice == 1)
        {
            account.Deposit(amount);
        }
        else if (choice == 2)
        {
            account.Withdraw(amount);
        }
        else
        {
            Console.WriteLine("Invalid choice.");
        }

        Console.WriteLine($"\nFinal Balance: {account.Balance}");
    }
} 
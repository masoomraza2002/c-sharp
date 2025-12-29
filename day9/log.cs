using System;
using System.IO;

class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException(string message) : base(message) { }
}

class BankAccount
{
    public decimal Balance { get; private set; } = 5000;

    public void Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            throw new ArgumentException("Withdraw amount must be greater than 0");
        }

        if (amount > Balance)
        {
            throw new InsufficientBalanceException("Insufficient balance to withdraw");
        }

        Balance -= amount;
    }
}

class Main2
{
    public static void main2()
    {
        try
        {
            Console.Write("Enter withdraw amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            int serviceCharge = 100;
 
            int divisionCheck = serviceCharge / int.Parse("0");

            string data = File.ReadAllText("account.txt");

            BankAccount account = new BankAccount();
            account.Withdraw(amount);

            Console.WriteLine("Withdrawal successful");
            Console.WriteLine("Remaining Balance: " + account.Balance);
        }
        catch (FormatException ex)
        {
            LogException(ex);
            Console.WriteLine("Invalid input format");
        }
        catch (DivideByZeroException ex)
        {
            LogException(ex);
            Console.WriteLine("Unexpected calculation error");
        }
        catch (FileNotFoundException ex)
        {
            LogException(ex);
            Console.WriteLine("Account file not found");
        }
        catch (InsufficientBalanceException ex)
        {
            LogException(ex);
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            LogException(ex);
            Console.WriteLine("Unexpected error occurred");
        }
        finally
        {
            Console.WriteLine("Transaction attempt complete");
        }
    }

    static void LogException(Exception ex)
    {
        File.AppendAllText(
            "error.log",
            DateTime.Now + " | " + ex.GetType().Name + " | " + ex.Message + Environment.NewLine
        );
    }
}

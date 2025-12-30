using System;
using System.IO;

namespace BankingSystem
{ 
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException(string message)
            : base(message)
        {
        }
    }

    public class BankOperationException : Exception
    {
        public BankOperationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }

    public class BankAccount
    {
        public string AccountNumber { get; private set; }
        public decimal Balance { get; private set; }

        private const string LogFilePath = "BankErrorLog.txt";

        public BankAccount(string accountNumber, decimal initialBalance)
        {
            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                throw new ArgumentException("Account number cannot be null, empty, or whitespace.");
            }

            if (initialBalance < 0)
            {
                throw new ArgumentException("Initial balance cannot be negative.");
            }

            AccountNumber = accountNumber;
            Balance = initialBalance;
        }

        public void Withdraw(decimal amount)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentException("Withdrawal amount must be greater than zero.");
                }

                if (amount > Balance)
                {
                    throw new InsufficientBalanceException(
                        $"Withdrawal failed. Attempted to withdraw {amount}, but available balance is {Balance}."
                    );
                }

                Balance -= amount;
                Console.WriteLine($"Withdrawal successful. Updated balance: {Balance}");
            }
            catch (InsufficientBalanceException ex)
            {
                LogException(ex);
                throw; 
            }
            catch (Exception ex)
            {
                LogException(ex);
                throw new BankOperationException("An unexpected banking error occurred.", ex);
            }
        }

        private void LogException(Exception ex)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(LogFilePath, true))
                {
                    writer.WriteLine("=================================");
                    writer.WriteLine($"Date & Time : {DateTime.Now}");
                    writer.WriteLine($"Account No  : {AccountNumber}");
                    writer.WriteLine("Exception Details:");
                    writer.WriteLine(ex.ToString());
                    writer.WriteLine("=================================");
                }
            }
            catch
            {
                
            }
        }
    }

    class Program1
    {
        public static void Main1()
        {
            try
            {
                BankAccount account = new BankAccount("ACC-1001", 5000);
                account.Withdraw(7000);  
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine("Business Error:");
                Console.WriteLine(ex.Message);
            }
            catch (BankOperationException ex)
            {
                Console.WriteLine("Bank Operation Error:");
                Console.WriteLine(ex.Message);

                if (ex.InnerException != null)
                {
                    Console.WriteLine("Root Cause:");
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected Error:");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Application execution completed safely.");
        }
    }
}
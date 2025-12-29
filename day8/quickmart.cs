// using System;

// class SaleTransaction
// {
//     public string InvoiceNo { get; set; }
//     public string CustomerName { get; set; }
//     public string ItemName { get; set; }
//     public int Quantity { get; set; }
//     public decimal PurchaseAmount { get; set; }
//     public decimal SellingAmount { get; set; }
//     public string ProfitOrLossStatus { get; set; }
//     public decimal ProfitOrLossAmount { get; set; }
//     public decimal ProfitMarginPercent { get; set; }
// }

// class TransactionManager
// {
//     public static SaleTransaction LastTransaction;
//     public static bool HasLastTransaction = false;

//     // 1) Create/Register Method
//     public static void CreateTransaction()
//     {
//         SaleTransaction transaction = new SaleTransaction();

//         Console.Write("Enter Invoice No: ");
//         transaction.InvoiceNo = Console.ReadLine();
//         if (string.IsNullOrWhiteSpace(transaction.InvoiceNo))
//         {
//             Console.WriteLine("Invoice No cannot be empty.");
//             return;
//         }

//         Console.Write("Enter Customer Name: ");
//         transaction.CustomerName = Console.ReadLine();

//         Console.Write("Enter Item Name: ");
//         transaction.ItemName = Console.ReadLine();

//         Console.Write("Enter Quantity: ");
//         if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
//         {
//             Console.WriteLine("Quantity must be greater than zero.");
//             return;
//         }
//         transaction.Quantity = qty;

//         Console.Write("Enter Purchase Amount (total): ");
//         if (!decimal.TryParse(Console.ReadLine(), out decimal purchase) || purchase <= 0)
//         {
//             Console.WriteLine("Purchase Amount must be greater than zero.");
//             return;
//         }
//         transaction.PurchaseAmount = purchase;

//         Console.Write("Enter Selling Amount (total): ");
//         if (!decimal.TryParse(Console.ReadLine(), out decimal selling) || selling < 0)
//         {
//             Console.WriteLine("Selling Amount cannot be negative.");
//             return;
//         }
//         transaction.SellingAmount = selling;

//         CalculateProfitLoss(transaction);

//         LastTransaction = transaction;
//         HasLastTransaction = true;

//         Console.WriteLine("\nTransaction saved successfully.");
//         PrintCalculation(transaction);
//         Console.WriteLine("------------------------------------------------------");
//     }

//     // 2) View Method
//     public static void ViewLastTransaction()
//     {
//         if (!HasLastTransaction)
//         {
//             Console.WriteLine("No transaction available. Please create a new transaction first.");
//             return;
//         }

//         SaleTransaction t = LastTransaction;

//         Console.WriteLine("\n-------------- Last Transaction --------------");
//         Console.WriteLine($"InvoiceNo: {t.InvoiceNo}");
//         Console.WriteLine($"Customer: {t.CustomerName}");
//         Console.WriteLine($"Item: {t.ItemName}");
//         Console.WriteLine($"Quantity: {t.Quantity}");
//         Console.WriteLine($"Purchase Amount: {t.PurchaseAmount:F2}");
//         Console.WriteLine($"Selling Amount: {t.SellingAmount:F2}");
//         Console.WriteLine($"Status: {t.ProfitOrLossStatus}");
//         Console.WriteLine($"Profit/Loss Amount: {t.ProfitOrLossAmount:F2}");
//         Console.WriteLine($"Profit Margin (%): {t.ProfitMarginPercent:F2}");
//         Console.WriteLine("--------------------------------------------");
//     }

//     // 3) Calculation Method
//     public static void RecalculateAndPrint()
//     {
//         if (!HasLastTransaction)
//         {
//             Console.WriteLine("No transaction available. Please create a new transaction first.");
//             return;
//         }

//         CalculateProfitLoss(LastTransaction);
//         PrintCalculation(LastTransaction);
//         Console.WriteLine("------------------------------------------------------");
//     }

//     private static void CalculateProfitLoss(SaleTransaction t)
//     {
//         if (t.SellingAmount > t.PurchaseAmount)
//         {
//             t.ProfitOrLossStatus = "PROFIT";
//             t.ProfitOrLossAmount = t.SellingAmount - t.PurchaseAmount;
//         }
//         else if (t.SellingAmount < t.PurchaseAmount)
//         {
//             t.ProfitOrLossStatus = "LOSS";
//             t.ProfitOrLossAmount = t.PurchaseAmount - t.SellingAmount;
//         }
//         else
//         {
//             t.ProfitOrLossStatus = "BREAK-EVEN";
//             t.ProfitOrLossAmount = 0;
//         }

//         t.ProfitMarginPercent = (t.ProfitOrLossAmount / t.PurchaseAmount) * 100;
//     }

//     private static void PrintCalculation(SaleTransaction t)
//     {
//         Console.WriteLine($"Status: {t.ProfitOrLossStatus}");
//         Console.WriteLine($"Profit/Loss Amount: {t.ProfitOrLossAmount:F2}");
//         Console.WriteLine($"Profit Margin (%): {t.ProfitMarginPercent:F2}");
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         bool running = true;

//         while (running)
//         {
//             Console.WriteLine("\n================== QuickMart Traders ==================");
//             Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
//             Console.WriteLine("2. View Last Transaction");
//             Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
//             Console.WriteLine("4. Exit");
//             Console.Write("Enter your option: ");

//             string choice = Console.ReadLine();

//             switch (choice)
//             {
//                 case "1":
//                     TransactionManager.CreateTransaction();
//                     break;

//                 case "2":
//                     TransactionManager.ViewLastTransaction();
//                     break;

//                 case "3":
//                     TransactionManager.RecalculateAndPrint();
//                     break;

//                 case "4":
//                     Console.WriteLine("\nThank you. Application closed normally.");
//                     running = false;
//                     break;

//                 default:
//                     Console.WriteLine("Invalid option. Please select a valid menu option.");
//                     break;
//             }
//         }
//     }
// }
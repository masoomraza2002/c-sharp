using System;
using System.Collections;
using System.Collections.Generic;

class Enterpris
{
    public static void main1()
    { 
        Console.WriteLine("TASK 1: DYNAMIC PRODUCT PRICE ANALYSIS");

        Console.Write("Enter number of products: ");
        int productCount = int.Parse(Console.ReadLine());

        int[] prices = new int[productCount];
        int sum = 0;

        for (int i = 0; i < productCount; i++)
        {
            while (true)
            {
                Console.Write($"Enter positive price for product {i}: ");
                int price = int.Parse(Console.ReadLine());
                if (price > 0)
                {
                    prices[i] = price;
                    sum += price;
                    break;
                }
                Console.WriteLine("Invalid price. Must be positive.");
            }
        }

        double productAverage = (double)sum / productCount;
        Console.WriteLine("Average Price: " + productAverage);

        Array.Sort(prices);

        for (int i = 0; i < prices.Length; i++)
        {
            if (prices[i] < productAverage)
                prices[i] = 0;
        }

        int oldLength = prices.Length;
        Array.Resize(ref prices, oldLength + 5);

        for (int i = oldLength; i < prices.Length; i++)
        {
            prices[i] = (int)productAverage;
        }

        Console.WriteLine("Final Product Prices:");
        for (int i = 0; i < prices.Length; i++)
        {
            Console.WriteLine($"Index {i} : {prices[i]}");
        }
 
        Console.WriteLine("\nTASK 2: BRANCH SALES ANALYSIS");

        Console.Write("Enter number of branches: ");
        int branches = int.Parse(Console.ReadLine());

        Console.Write("Enter number of months: ");
        int months = int.Parse(Console.ReadLine());

        int[,] sales = new int[branches, months];
        int highestSale = int.MinValue;

        for (int i = 0; i < branches; i++)
        {
            for (int j = 0; j < months; j++)
            {
                Console.Write($"Enter sales for Branch {i}, Month {j}: ");
                sales[i, j] = int.Parse(Console.ReadLine());

                if (sales[i, j] > highestSale)
                    highestSale = sales[i, j];
            }
        }

        for (int i = 0; i < branches; i++)
        {
            int total = 0;
            for (int j = 0; j < months; j++)
                total += sales[i, j];

            Console.WriteLine($"Total sales of Branch {i}: {total}");
        }

        Console.WriteLine("Highest Monthly Sale Overall: " + highestSale);
 
        Console.WriteLine("\nTASK 3: PERFORMANCE-BASED DATA EXTRACTION");

        int[][] jaggedSales = new int[branches][];

        for (int i = 0; i < branches; i++)
        {
            int count = 0;
            for (int j = 0; j < months; j++)
                if (sales[i, j] >= productAverage)
                    count++;

            jaggedSales[i] = new int[count];
            int index = 0;

            for (int j = 0; j < months; j++)
            {
                if (sales[i, j] >= productAverage)
                {
                    jaggedSales[i][index] = sales[i, j];
                    index++;
                }
            }
        }

        for (int i = 0; i < jaggedSales.Length; i++)
        {
            Console.Write($"Branch {i} Qualified Sales: ");
            for (int j = 0; j < jaggedSales[i].Length; j++)
                Console.Write(jaggedSales[i][j] + " ");
            Console.WriteLine();
        }
 
        Console.WriteLine("\nTASK 4: CUSTOMER TRANSACTION CLEANING");

        Console.Write("Enter number of customer transactions: ");
        int txnCount = int.Parse(Console.ReadLine());

        List<int> customerList = new List<int>();

        for (int i = 0; i < txnCount; i++)
        {
            Console.Write($"Enter Customer ID {i}: ");
            customerList.Add(int.Parse(Console.ReadLine()));
        }

        int originalCount = customerList.Count;

        HashSet<int> customerSet = new HashSet<int>(customerList);
        List<int> cleanedList = new List<int>(customerSet);

        Console.WriteLine("Cleaned Customer IDs:");
        foreach (int id in cleanedList)
            Console.WriteLine(id);

        Console.WriteLine("Duplicates Removed: " + (originalCount - cleanedList.Count));
 
        Console.WriteLine("\nTASK 5: FINANCIAL TRANSACTION FILTERING");

        Console.Write("Enter number of financial transactions: ");
        int finCount = int.Parse(Console.ReadLine());

        Dictionary<int, double> transactions = new Dictionary<int, double>();

        for (int i = 0; i < finCount; i++)
        {
            Console.Write("Enter Transaction ID: ");
            int id = int.Parse(Console.ReadLine());

            if (transactions.ContainsKey(id))
            {
                Console.WriteLine("Duplicate Transaction ID. Skipped.");
                i--;
                continue;
            }

            Console.Write("Enter Amount: ");
            double amount = double.Parse(Console.ReadLine());
            transactions.Add(id, amount);
        }

        SortedList<int, double> highValueTxns = new SortedList<int, double>();

        foreach (KeyValuePair<int, double> kv in transactions)
        {
            if (kv.Value >= productAverage)
                highValueTxns.Add(kv.Key, kv.Value);
        }

        Console.WriteLine("High Value Transactions:");
        foreach (KeyValuePair<int, double> kv in highValueTxns)
            Console.WriteLine($"ID: {kv.Key}, Amount: {kv.Value}");
 
        Console.WriteLine("\nTASK 6: PROCESS FLOW MANAGEMENT");

        Console.Write("Enter number of operations: ");
        int ops = int.Parse(Console.ReadLine());

        Queue queue = new Queue();
        Stack stack = new Stack();

        for (int i = 0; i < ops; i++)
        {
            Console.Write($"Enter operation {i}: ");
            string op = Console.ReadLine();
            queue.Enqueue(op);
            stack.Push(op);
        }

        Console.WriteLine("Processing Queue:");
        while (queue.Count > 0)
            Console.WriteLine(queue.Dequeue());

        Console.WriteLine("Undo Operations:");
        for (int i = 0; i < 2 && stack.Count > 0; i++)
            Console.WriteLine(stack.Pop());
 
        Console.WriteLine("\nTASK 7: LEGACY DATA RISK DEMONSTRATION");

        Console.Write("Enter number of users: ");
        int users = int.Parse(Console.ReadLine());

        Hashtable userTable = new Hashtable();
        ArrayList legacyList = new ArrayList();

        for (int i = 0; i < users; i++)
        {
            Console.Write("Enter Username: ");
            string name = Console.ReadLine();

            Console.Write("Enter Role: ");
            string role = Console.ReadLine();

            userTable[name] = role;
            legacyList.Add(name);
            legacyList.Add(role);
            legacyList.Add(i); 
        }

        Console.WriteLine("Hashtable Data:");
        foreach (DictionaryEntry entry in userTable)
            Console.WriteLine($"{entry.Key} : {entry.Value}");

        Console.WriteLine("ArrayList Data (Mixed Types):");
        foreach (object obj in legacyList)
            Console.WriteLine(obj);

        Console.WriteLine("\nRisk: ArrayList allows mixed types → runtime casting errors possible.");
    }
}

using System;
using System.Collections.Generic;

struct PriceSnapshot
{
    public string StockSymbol;
    public double StockPrice;
}

static class TradeAnalytics
{
    public static int totalTrade = 0;
    public static void displayTradeAnalytic()
    {
        Console.WriteLine("Total numb of trade: "+ totalTrade);
    }
}

static class FinanceExtension{
    public static double brockrageCal(this double value)
    {
        return 0.01*value;
    }

    public static double taxCal(this double value)
    {
        return 0.05* value;
    }
}
abstract class Trade
{
    public int tradeId;
    public string stockSymbol;
    public int quantity;
    public abstract double calTradeVal();

    public override string ToString()
    {
         return $"TradeID: {tradeId} , Stock symbol: {stockSymbol} , Quantity: {quantity}";
    }
}

class EquityTrade:Trade
{
    public double? marketPrice;

    public override double calTradeVal()
    {
        double price = marketPrice ?? 0;
        return price * quantity;
    }
}

class TradeRepository<T> where T : Trade
{
    private List<T> ll = new List<T>();
    
    public void AddTrade(T trade)
    {
        ll.Add(trade);
        TradeAnalytics.totalTrade++;
    }
    public List<T> getTrade()
    {
        return ll;
    }
}

static class TradeProcess
{
    public static void checkProcess(Trade trade)
    {
        if(trade is EquityTrade)
        {
            Console.WriteLine("Processing equity trade");
        }
        else
        {
            Console.WriteLine("Unknown trade");
        }
    }
}

class Main6
{
    public static void main6()
    {
        PriceSnapshot ps =  new PriceSnapshot{StockSymbol="TCS IND", StockPrice=599.00};
        Console.WriteLine("ps: " + ps.StockSymbol + " @ " + ps.StockPrice);

        TradeRepository<EquityTrade> repo = new TradeRepository<EquityTrade>();

        EquityTrade t1 =  new EquityTrade();
        t1.tradeId = 1;
        t1.stockSymbol = "tcs";
        t1.quantity = 10;
        t1.marketPrice = 3500;

        EquityTrade t2 =  new EquityTrade();
        t2.tradeId = 2;
        t2.stockSymbol = "sbi";
        t2.quantity = 5;
        t2.marketPrice = null;

        repo.AddTrade(t1);
        repo.AddTrade(t2);

        foreach(EquityTrade trade in repo.getTrade())
        {
            Console.WriteLine(trade);
            TradeProcess.checkProcess(trade);

            double value =  trade.calTradeVal();
            Console.WriteLine("trade val "+ value);
            Console.WriteLine("Brokrage "+ value.brockrageCal());
            Console.WriteLine("Tax "+ value.taxCal());
        }

        TradeAnalytics.displayTradeAnalytic();

        object boxed = TradeAnalytics.totalTrade;
        int unboxed = (int)boxed;

        Console.WriteLine("Boxed : "+boxed);
        Console.WriteLine("Un Boxed : "+unboxed);       
    }
}
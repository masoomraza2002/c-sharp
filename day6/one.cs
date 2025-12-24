// using System;

// struct stockPrice
// {
//     public string stockSymbol;
//     public double price;
    
// }

// class Trade
// {
//     public int tradeId;
//     public string  stockSymbol;
//     public int quantity;

//     public Trade(int tradeId,string stockSymbol,int quantity)
//     {
//         this.tradeId = tradeId;
//         this.stockSymbol = stockSymbol;
//         this.quantity = quantity;
//     }
// }

// class Main1
// {
//     public static void main1()
//     {
//         stockPrice sp = new stockPrice{stockSymbol="tcss" ,price= 100.00};
//         stockPrice sp2 = sp;
//         sp2.price = 500.00;
//         Console.WriteLine(sp.price);
//         Console.WriteLine(sp2.price);

//         Trade td = new Trade(1,"abc",10);
//         Trade td2 = td;
//         td.quantity = 100;
//         Console.WriteLine(td.quantity);
//         Console.WriteLine(td2.quantity);
//     }
// }
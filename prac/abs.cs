// using System;

// public abstract class Payment
// {
//     public void ProcessPay()
//     {
//         Console.WriteLine("payment done");
//         MakePayment();
//         Console.WriteLine("payment completed");
//     }

//     public abstract void MakePayment();

// }

// public class UPIPay : Payment
// {
//     public override void MakePayment()
//     {
//         Console.WriteLine("processing UPI pay");
//     }
// }


// public class Card : Payment
// {
//     public override void MakePayment()
//     {
//         Console.WriteLine("processing card pay");
//     }
// }

// class Abs
// {
//     public static void abs()
//     {
//         Payment p1 = new UPIPay();
//         Payment p2 = new Card();

//         p1.ProcessPay();
//         Console.WriteLine();
//         p2.ProcessPay();
        
//     }
// }
using System;
using DigitalWallet.Core;

// namespace DigtalWallet
// {
//     class Program
//     {
//         public static void Main(String[] args)
//         {
//             string appName = WalletInfo.GetAppName();
//             Console.WriteLine(appName);
//         }
//     }
// }

// using System;

namespace DigtalWallet
{
    class Program
    {
        public static void Main(string[] args)
        {
            decimal balance = 5000m;

            object boxedBalance = balance;   // BOXING

            Console.WriteLine("Boxed Balance: " + boxedBalance.GetType());
        }
    }
}
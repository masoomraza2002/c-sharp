using System;

delegate void ErrorDelegate(string mess);
 
class Main4
{
    public static void main4()
    {
        // Func<decimal , decimal,decimal> cal = (pri,dis) => pri - (pri*dis/100);
        // Console.WriteLine(cal(1000,10));

        // Predicate<int> isEli = age => age>=18;
        // Console.WriteLine(isEli(20));

        ErrorDelegate errorHandler = delegate (string msg)
        {
            Console.WriteLine("error : "+msg);
        };
        errorHandler("file not found");
    }
}

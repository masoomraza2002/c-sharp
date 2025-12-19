using System;

class Sum
{
    public static void Rev()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int ans = n%10;
        n /= 10;
        while(n != 0)
        {
            ans = ans * 10;
            ans += n % 10;
            n /= 10;
        }
        Console.WriteLine(ans);

    }
}
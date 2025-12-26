using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections; 

class Flip
{
    public static void flip()
    {
        string s = Console.ReadLine();
        if(string.IsNullOrEmpty(s) || s.Length < 6 || !Regex.IsMatch(s, "^[A-Za-z]+$"))
        {
            Console.WriteLine("");
            return;
        }

        s = s.ToLower();
        StringBuilder sb = new StringBuilder();

        foreach(char c in s)
        {
            if((int)c % 2 != 0)
            {
                sb.Append(c);
            }
        }

        char[] arr = sb.ToString().ToCharArray();
        Array.Reverse(arr);
        sb = new StringBuilder(new string(arr));

        for(int i = 0; i < sb.Length; i++)
        {
            if(i%2 == 0)
            {
                sb[i] = char.ToUpper(sb[i]);
            }
        }
        Console.WriteLine(sb.ToString());
    }
}
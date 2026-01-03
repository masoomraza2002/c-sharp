using System;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;

namespace LogProcessing
{
    class LogParser
    {
        private readonly string validLineRegexPattern;
        private readonly string splitLineRegexPattern;
        private readonly string quotedPasswordRegexPattern;
        private readonly string endOfLineRegexPattern;
        private readonly string weakPasswordRegexPattern;

        public bool isValid(string text)
        {
            string pattern = @"^\[(TRC|DBG|INF|WRN|ERR|FTL)\]";
            if (!Regex.IsMatch(text, pattern))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public string[] SplitLogLine(string text)
        {
            string pattern = @"<\*{3}>|<={4}>|<\^\*>";
            string[] ans = Regex.Split(text, pattern);
            return ans;
        }

        public int CountQuotedPasswords(string lines)
        {
            string pattern = @"[""']password[""']";
            MatchCollection match = Regex.Matches(lines, pattern);
            return match.Count();
        }

        public string RemoveEndOfLineText(string line)
        {
            string pattern = @"end-of-line\d+";
            return Regex.Replace(line, pattern, "");
        }

        public string[] ListLinesWithPasswords(string[] lines)
        {
            string pattern = @"password[a-zA-Z0-0]";
            string[] ans = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                Match match = Regex.Match(lines[i], pattern);

                if (match.Success)
                {
                    ans[i] = match.Value + ": " + lines[i];
                }
                else
                {
                    ans[i] = "----- " + lines[i];
                }
            }
            return ans;
        }


    }

    class Main1
    {
        public static void main1()
        {
            LogParser parser = new LogParser();

            Console.WriteLine("VALID LINE CHECK:");
            Console.WriteLine(parser.isValid("[INF] Application started"));
            Console.WriteLine(parser.isValid("Application started"));
            Console.WriteLine();

            Console.WriteLine("SPLIT LOG LINE:");
            string log = "START<***>INFO<====>UserLoggedIn<^*>SUCCESS";
            string[] parts = parser.SplitLogLine(log);
            foreach (var p in parts)
                Console.WriteLine(p);
            Console.WriteLine();

            Console.WriteLine("COUNT QUOTED PASSWORDS:");
            string pwdLine = @"User entered ""password"" and 'password'";
            Console.WriteLine(parser.CountQuotedPasswords(pwdLine));
            Console.WriteLine();

            Console.WriteLine("REMOVE END-OF-LINE MARKER:");
            string eol = "INFO Process finished end-of-line23";
            Console.WriteLine(parser.RemoveEndOfLineText(eol));
            Console.WriteLine();

            Console.WriteLine("WEAK PASSWORD DETECTION:");
            string[] logs =
            {
            "User password123 failed login",
            "System started successfully"
        };

            string[] result = parser.ListLinesWithPasswords(logs);
            foreach (var r in result)
                Console.WriteLine(r);
        }
    }
}
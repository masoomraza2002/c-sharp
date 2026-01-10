using System;
using System.Collections.Generic;

namespace DialingCodesApp
{
    public static class DialingCodes
    {        
        public static Dictionary<int, string> dict;
        
        public static Dictionary<int, string> GetEmptyDictionary()
        {
            return new Dictionary<int, string>();
        }
                
        public static Dictionary<int, string> GetExitingDictionary()
        {
            dict = new Dictionary<int, string>();
            dict.Add(1, "United States of America");
            dict.Add(55, "Brazil");
            dict.Add(91, "India");

            return dict;
        }
        
        public static Dictionary<int, string> AddCountryToEmptyDictionary(int code, string country)
        {
            Dictionary<int, string> dict2 = new Dictionary<int, string>();
            dict2.Add(code, country);
            return dict2;
        }
        
        public static Dictionary<int, string> AddCountryToExistingDictionary(
            Dictionary<int, string> existingDictionary,
            int countryCode,
            string countryName)
        {
            if (!existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary.Add(countryCode, countryName);
            }
            return existingDictionary;
        }
        
        public static string GetCountryNameFromDictionary(
            Dictionary<int, string> existingDictionary,
            int countryCode)
        {
            return existingDictionary.ContainsKey(countryCode)
                ? existingDictionary[countryCode]
                : "";
        }
        
        public static bool CheckCodeExists(
            Dictionary<int, string> existingDictionary,
            int countryCode)
        {
            return existingDictionary.ContainsKey(countryCode);
        }
        
        public static Dictionary<int, string> UpdateDictionary(
            Dictionary<int, string> existingDictionary,
            int countryCode,
            string countryName)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary[countryCode] = countryName;
            }
            return existingDictionary;
        }
        
        public static Dictionary<int, string> RemoveCountryFromDictionary(
            Dictionary<int, string> existingDictionary,
            int countryCode)
        {
            if (existingDictionary.ContainsKey(countryCode))
            {
                existingDictionary.Remove(countryCode);
            }
            return existingDictionary;
        }
        
        public static string FindLongestCountryName(
            Dictionary<int, string> existingDictionary)
        {
            if (existingDictionary.Count == 0)
                return "";

            string ans = "";
            int maxLen = 0;

            foreach (KeyValuePair<int, string> ent in existingDictionary)
            {
                if (ent.Value.Length > maxLen)
                {
                    maxLen = ent.Value.Length;
                    ans = ent.Value;
                }
            }
            return ans;
        }
    }
    
    class Main1
    {
        public static void main1()
        {            
            var emptyDict = DialingCodes.GetEmptyDictionary();            
            var existingDict = DialingCodes.GetExitingDictionary();            
            var japanDict = DialingCodes.AddCountryToEmptyDictionary(81, "Japan");            
            DialingCodes.AddCountryToExistingDictionary(existingDict, 44, "United Kingdom");            
            Console.WriteLine(DialingCodes.GetCountryNameFromDictionary(existingDict, 91));            
            Console.WriteLine(DialingCodes.CheckCodeExists(existingDict, 55));            
            DialingCodes.UpdateDictionary(existingDict, 91, "Republic of India");            
            DialingCodes.RemoveCountryFromDictionary(existingDict, 1);            
            Console.WriteLine(DialingCodes.FindLongestCountryName(existingDict));
        }
    }
}

using System;
using System.Collections;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

class Coll
{
    public static void coll()
    {
        // List<int> ll = new List<int>();
        // ll.Add(10);
        // Console.WriteLine(ll[0]);

        // Hashtable ht = new Hashtable();
        // ht.Add(1 , "Admin");
        // ht.Add(2 , "users");

        // Console.WriteLine(ht[1]);

        // Stack st = new Stack();
        // st.Push(10);
        // st.Push(20);
        // Console.WriteLine(st.Peek());

        // Queue q = new Queue();
        // q.Enqueue(10);
        // q.Enqueue(20);
        // Console.WriteLine(q.Peek());

        // Dictionary<int , string>  dict = new Dictionary<int, string>();
        // dict.Add(1,"abs");
        // Console.WriteLine(dict[1]);

        // SortedList<string,string> list = new SortedList<string, string>();
        // list.Add("abc","ABC");
        // list.Add("abb" , "sin");
        // foreach(KeyValuePair<string,string> item in list)
        // {
        //     Console.WriteLine(item.Key + " " + item.Value);
        // }

        Dictionary<int, int> dict = new Dictionary<int, int>();
        int num = Convert.ToInt32(Console.ReadLine());
        while(num != -1)
        {
            if (dict.ContainsKey(num))
            {
                dict[num]++;
            }
            else
            {
                dict[num] = 1;
            }
            num = Convert.ToInt32(Console.ReadLine());
        }

        foreach (var item in dict)
        {
            Console.WriteLine(item.Key + " " + item.Value);
        }
    }
}
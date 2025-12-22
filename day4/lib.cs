using System;
using System.Collections.Generic;

class Lib
{
    private Dictionary<int, string> books = new Dictionary<int, string>();
    public string this[int id]
    {
        get
        {
            if (books.ContainsKey(id))
            {
                return books[id];
            }
            return "book not found";
        }
        set
        {
            books[id] = value;
        }
    }

    public string this[string titlee]
    {
        get
        {
            foreach(var book in books)
            {
                if (book.Value.Equals(titlee))
                {
                    return book.Value;
                }
            }
            return "not found";
        }
    }
}

class Main7
{
    public static void main7()
    {
        Lib ll = new Lib();

        ll[101] = "abc";
        ll[102] = "def";
        ll[103] = "ghi";

        Console.WriteLine(ll[101]);
        Console.WriteLine(ll[102]);
        Console.WriteLine(ll[103]);

        Console.WriteLine(ll["ghi"]);
        Console.WriteLine(ll["dfkjd"]);
    }
}
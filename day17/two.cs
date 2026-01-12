using System;
using System.Collections.Generic;
using System.Diagnostics;

class Main2
{
    public static void main2()
    {
        Trace.Listeners.Add(new ConsoleTraceListener());

        Trace.WriteLine("Program started");

        List<User> users = CreateUsers();
        PrintUsers(users);

        Trace.WriteLine("Program ended");
    }

    static List<User> CreateUsers()
    {
        List<User> users = new List<User>
        {
            new User { Name = "Aryan", Age = 22 },
            new User { Name = "Mohit", Age = 32 },
            new User { Name = "Sushant", Age = 68 },  
            new User { Name = "Ritik", Age = 63 },
            new User { Name = "Sahil", Age = 52 }
        };

        return users;
    }

    static void PrintUsers(List<User> users)
    {
        foreach (var user in users)
        { 
            if (user.Age > 60)
            {
                Trace.WriteLine($"Stopped printing at Age > 60 ({user.Name})");
                break;   
            }

            Console.WriteLine($"User Name: {user.Name}, User Age: {user.Age}");
        }
    }
}

class User
{
    public string Name { get; set; }
    public int Age { get; set; }
}

using System;
using System.IO;
 
class Persist
{
    public static void persist()
    {
        User user = new User{Id=1 , Name="Alice"};

        using (StreamWriter writer = new StreamWriter("user.txt"))
        {
            writer.WriteLine(user.Id);
            writer.WriteLine(user.Name);

            user.Id = 2;
            user.Name = "abob";

            writer.WriteLine(user.Id);
            writer.WriteLine(user.Name);
        }

        Console.WriteLine("data saved");

        User userA =  new User();

        using (StreamReader reader = new StreamReader("user.txt"))
        {
            userA.Id = int.Parse(reader.ReadLine());
            userA.Name = reader.ReadLine();
        }

        Console.WriteLine($"User loaded  {userA.Id} , {userA.Name}");


    }
}
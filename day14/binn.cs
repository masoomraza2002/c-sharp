using System;

class User
{
    public int Id;
    public string Name;
}

class Binn
{
    public static void binn()
    {
        User user  = new User{Id = 2 , Name  = "bob"};

        using (BinaryWriter writer = new BinaryWriter(File.Open("user.bin", FileMode.Create)))
        {
            writer.Write(user.Id);
            writer.Write(user.Name);
        }
         Console.WriteLine("done");
    }
}
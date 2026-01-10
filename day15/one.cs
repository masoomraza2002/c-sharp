using System;
using System.IO;
using System.Xml.Serialization;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class Main1
{
    public static void main1()
    {
        User user = new User { Id = 1, Name = "alice" };
        XmlSerializer serialize = new XmlSerializer(typeof(User));
        using (FileStream fs = new FileStream("user.xml", FileMode.Create))
        {
            serialize.Serialize(fs, user);
        }
        Console.WriteLine("XML Serialzed");
    }
}
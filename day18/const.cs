using System;
using System.Reflection;

class Personn
{
    public Personn(string name, int age)
    {
        Console.WriteLine($"Name: {name}, Age: {age}");
    }
}

class Main1
{
    public static void main1()
    {        
        Type type = typeof(Personn);
        
        ConstructorInfo ctor = type.GetConstructor(
            new Type[] { typeof(string), typeof(int) }
        );

        if (ctor != null)
        {
            
            object obj = ctor.Invoke(new object[] { "John", 30 });
        }
        else
        {
            Console.WriteLine("Constructor not found");
        }
    }
}

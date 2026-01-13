using System;
using System.Reflection;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }

    public void Work()
    {
        Console.WriteLine("Employee working");
    }
}

class Main2
{
    public static void main2()
    {
        Type type = typeof(Employee);

        Console.WriteLine("Class Name: " + type.Name);
        Console.WriteLine("Namespace: " + type.Namespace);

        Console.WriteLine("\nProperties:");
        foreach (PropertyInfo prop in type.GetProperties())
        {
            Console.WriteLine($"{prop.Name} - {prop.PropertyType}");
        }

        Console.WriteLine("\nMethods:");
        foreach (MethodInfo method in type.GetMethods())
        {
            Console.WriteLine(method.Name);
        }
    }
}


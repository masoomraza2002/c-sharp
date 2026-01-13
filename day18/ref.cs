using System;
using System.Reflection;

class Person
{
    public string name;              
    public int Age { get; set; }      

    public Person(string name, int age)
    {
        this.name = name;
        Age = age;
    }

    public void PrintInfo(string prefix)
    {
        Console.WriteLine($"{prefix} Name={name}, Age={Age}");
    }
}

class Main3
{
    public static void main3()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type type = assembly.GetType("Person");
        
        ConstructorInfo ctor = type.GetConstructor(
            new Type[] { typeof(string), typeof(int) });

        object obj = ctor.Invoke(new object[] { "John", 30 });
        
        FieldInfo field = type.GetField("name");
        Console.WriteLine("Field Value: " + field.GetValue(obj));
        
        PropertyInfo prop = type.GetProperty("Age");
        Console.WriteLine("Property Value: " + prop.GetValue(obj));
        
        MethodInfo method = type.GetMethod("PrintInfo");

        ParameterInfo[] parameters = method.GetParameters();
        Console.WriteLine("Method Parameters:");
        foreach (var p in parameters)
        {
            Console.WriteLine($"- {p.Name} : {p.ParameterType}");
        }

        method.Invoke(obj, new object[] { "INFO:" });
    }
}

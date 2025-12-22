using System;

class Student
{
    private string name;
    private int age;
    private int marks;

    public string Name
    {
        get{return name; }
        set{
            if (string.IsNullOrWhiteSpace(value))
            {
                Console.WriteLine("Name should not be empty");
            }
            else
            {
                name = value;
            }
        }
    }

    public int Marks
    {
        get{ return  marks; }
        set{
            if (value > 100 || value < 0)
            {
                Console.WriteLine("Marks must be betewwn 0 to 100");
            }
            else
            {
                marks = value;
            }
        }
        
    }

    public int Age
    {
        get { return age; }
        set{
            if (value <= 0)
            {
                Console.WriteLine("age must be grater that 0");
            }
            else
            {
                age = value;
            }
        }  
    }


}

class Main6
{
    public static void main6()
    {
        Student std = new Student();

        std.Name = "masom";
        std.Age = 22;
        std.Marks = 85;

        Console.WriteLine($"{std.Name}");
        Console.WriteLine($"{std.Age}");
        Console.WriteLine($"{std.Marks}");

    }
}
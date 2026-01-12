using System;

class Student
{
    public string Name;
    public string Grade;
    public int Marks;
}

class Main3
{
    public static void main3()
    {
        List<Student> students = new List<Student>
        {
            new Student { Name = "Aryan", Marks = 75 },
            new Student { Name = "Mohit", Marks = 45 },
            new Student { Name = "Sushant", Marks = 90 },
            new Student { Name = "Ritik", Marks = 55 }
        };

        // var result = students.Select(s => new
        // {
        //     s.Name,
        //     Grade = s.Marks > 60 ? "Pass" : "Fail"
        // });

        // foreach (var item in result)
        // {
        //     Console.WriteLine($"Name: {item.Name}, Grade: {item.Grade}");
        // }


        // var soertedBySal = students.OrderBy(e => e.Marks);
        var soertedBySal = students.OrderBy(e => e.Name);

         foreach (var item in soertedBySal)
        {
            Console.WriteLine($"Name: {item.Name}, Marks: {item.Marks}");
        }

        Console.WriteLine(soertedBySal.GetTypes());
    }
}



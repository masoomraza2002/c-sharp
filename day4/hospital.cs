using System.ComponentModel;

class Doctor
{
    public string Name { get; set; }
    public string Specialization { get; set; }
    public readonly string LicenseNumber;

    public static int TotalDoctors;

    static Doctor()
    {
        TotalDoctors = 0;
        Console.WriteLine("Doctor system initialized.");
    }

    public Doctor(string name, string spec, string license)
    {
        Name = name;
        Specialization = spec;
        LicenseNumber = license;
        TotalDoctors++;
    }
}


class Cardiologist : Doctor
{
    public Cardiologist(string name, string license) : base(name, "cardio", license) { }

    public void display()
    {
        Console.WriteLine("Name : " + Name);
        Console.WriteLine("Name : " + Specialization);
        Console.WriteLine("Name : " + LicenseNumber);

        Console.WriteLine("total doc : " + Doctor.TotalDoctors);
    }
}

class Main11
{
    public static void main11()
    {
        Cardiologist c1 = new Cardiologist("Dr. Anshika", "LIC123");
        Cardiologist c2 = new Cardiologist("Dr. Aditya", "LIC456");

        c1.display();
        Console.WriteLine();
        c2.display();
    }
}
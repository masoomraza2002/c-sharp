using System;

class Box
{
    public static void cal(object sall)
    {
        int sal = (int)sall;
        sal += 5000;
        Console.WriteLine("sal "+sal);
    }
    public static void box()
    {
        int sal = 3000;
        object sall = sal;
        cal(sall);
        Console.WriteLine(sal);
    }
}



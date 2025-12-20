using System;

class Calculator
{
    public int a;
    public int b;

    public Calculator(int a,int b)
    {
        this.a = a;
        this.b = b;
    }

    public int add()
    {
        return a + b;
    }

    public int sub()
    {
        return a - b;
    }
}

class Main6()
{
    public static void main6()
    {
        Calculator cal = new Calculator(5, 6);
        Console.WriteLine(cal.add());
        Console.WriteLine(cal.sub());
    }
}
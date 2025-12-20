using System;

class BankAcc
{
    public String  name;
    private int balance;

    public BankAcc(String name,int balance)
    {
        this.name = name;
        this.balance = balance;
    }

    public int getBalance()
    {
        return balance;
    }
}

class Employee
{
    public String name;
    public int salary;

    public Employee(String name, int salary)
    {
        this.name = name;
        this.salary = salary;
    }
}


class Bank
{
    public static void bank()
    {
        BankAcc acc = new BankAcc("masoom", 220000);
        Console.WriteLine(acc.name);
        Console.WriteLine(acc.getBalance());

        Employee emp = new Employee("masoom", 20000);
        Console.WriteLine(emp.name);

    }
}
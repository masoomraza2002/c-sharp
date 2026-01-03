using System;

class Tpl
{
    // public static (int sum , int avg) Cal(int a,int b)
    // {
    //     return (a+b , (a+b)/2);
    // }

    public static (bool IsValid,string Mess) ValidateUser(string username)
    {
        if(string.IsNullOrEmpty(username)) return (false, "Username is req");
        return (true , "valid user");
    }

    public static void tpl()
    {
        // var stu = (Id :10 , Name : "masoom");
        // Console.WriteLine(stu.Id.GetType());
        // Console.WriteLine(stu.Name.GetType());
        // Console.WriteLine(Cal(10,20));
        var res = ValidateUser("Admin");
        Console.WriteLine(res.Mess);        
    }
}
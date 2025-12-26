using System;

abstract class EmployeeRecord
{
    public string EmployeeName;
    public double[] WeeklyHours;
    public abstract double GetMonthlyPay();
}

class FullTimeEmployee : EmployeeRecord
{
    public double HourlyRate;
    public double MonthlyBonus;

    public double GetMonthlyPay()
    {
        double sum = 0.0;
        foreach (double i in WeeklyHours)
        {
            sum += i;
        }
        return (sum * HourlyRate) + MonthlyBonus;
    }
}

class ContactEmpl : EmployeeRecord
{
    public double HourlyRate;
    public double GetMonthlyPay()
    {
        double sum = 0.0;
        foreach (double i in WeeklyHours)
        {
            sum += i;
        }
        return sum * HourlyRate;
    }
}

class Employee
{
    public static List<EmployeeRecord> payrollBoard = new List<EmployeeRecord>();

    public void RegisterEmployee(EmployeeRecord record)
    {
        payrollBoard.Add(record);
    }

    public Dictionary<string, int> GetOvertimeWeekCounts(List<EmployeeRecord> record, double hoursthreshold)
    {
        Dictionary<string, int> ans = new Dictionary<string, int>();
        foreach (EmployeeRecord er in record)
        {
            int cou = 0;
            foreach (double i in er.WeeklyHours)
            {
                if (i > hoursthreshold)
                {
                    cou++;
                }

            }
            if (cou > 0) ans.Add(er.EmployeeName, cou);
        }
        return ans;
    }

    public double CalculateAverageMonthlyPay()
    {

        if (payrollBoard.Count == 0) return 0.0;
        double totalPay = 0.0;

        foreach (EmployeeRecord emp in payrollBoard)
        {
            totalPay += emp.GetMonthlyPay();
        }
        return totalPay / payrollBoard.Count;
    }
}

class Payroll
{
    public static void payroll()
    {
        Employee empManager = new Employee();

        while (true)
        {
            Console.WriteLine("1. Register Employee");
            Console.WriteLine("2. View Overtime Count");
            Console.WriteLine("3. Average Monthly Pay");
            Console.WriteLine("4. Exit");

            int choice = int.Parse(Console.ReadLine());

            if (choice == 1)
            {
                Console.WriteLine("Choose Employee Type (1-Full Time, 2-Contract)");
                int type = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter Employee Name:");
                string name = Console.ReadLine();

                double[] hours = new double[4];
                for (int i = 0; i < 4; i++)
                {
                    hours[i] = double.Parse(Console.ReadLine());
                }

                Console.WriteLine("Enter Hourly Rate:");
                double rate = double.Parse(Console.ReadLine());

                if (type == 1)
                {
                    Console.WriteLine("Enter Monthly Bonus:");
                    double bonus = double.Parse(Console.ReadLine());

                    FullTimeEmployee fte = new FullTimeEmployee
                    {
                        EmployeeName = name,
                        WeeklyHours = hours,
                        HourlyRate = rate,
                        MonthlyBonus = bonus
                    };
                    empManager.RegisterEmployee(fte);
                }
                else
                {
                    ContactEmpl ce = new ContactEmpl
                    {
                        EmployeeName = name,
                        WeeklyHours = hours,
                        HourlyRate = rate
                    };
                    empManager.RegisterEmployee(ce);
                }

                Console.WriteLine("Employee registered successfully");
            }

            else if (choice == 2)
            {
                Console.WriteLine("Enter hours threshold:");
                double threshold = double.Parse(Console.ReadLine());

                var result = empManager.GetOvertimeWeekCounts(Employee.payrollBoard, threshold);

                if (result.Count == 0)
                {
                    Console.WriteLine("No overtime recorded this month");
                }
                else
                {
                    foreach (var kv in result)
                    {
                        Console.WriteLine($"{kv.Key} - {kv.Value}");
                    }
                }
            }

            else if (choice == 3)
            {
                double avg = empManager.CalculateAverageMonthlyPay();
                Console.WriteLine($"Overall average monthly pay: {avg}");
            }

            else if (choice == 4)
            {
                Console.WriteLine("Logging off — Payroll processed successfully!");
                break;
            }
        }
    }
}
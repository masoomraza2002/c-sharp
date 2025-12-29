using System;

class PatientBill
{
    public string BillId { get; set; }
    public string PatientName { get; set; }
    public bool HasInsurance { get; set; }

    public decimal ConsultationFee { get; set; }
    public decimal LabCharges { get; set; }
    public decimal MedicineCharges { get; set; }

    public decimal GrossAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public decimal FinalPayable { get; set; }

    public void CalculateBill()
    {
        GrossAmount = ConsultationFee + LabCharges + MedicineCharges;

        DiscountAmount = HasInsurance ? GrossAmount * 0.10m : 0;
        FinalPayable = GrossAmount - DiscountAmount;
    }

    public void DisplayBill()
    {
        Console.WriteLine("\n----- Patient Bill Details -----");
        Console.WriteLine($"Bill ID          : {BillId}");
        Console.WriteLine($"Patient Name     : {PatientName}");
        Console.WriteLine($"Has Insurance    : {(HasInsurance ? "Yes" : "No")}");
        Console.WriteLine($"Consultation Fee : {ConsultationFee:F2}");
        Console.WriteLine($"Lab Charges      : {LabCharges:F2}");
        Console.WriteLine($"Medicine Charges : {MedicineCharges:F2}");
        Console.WriteLine($"Gross Amount     : {GrossAmount:F2}");
        Console.WriteLine($"Discount Amount  : {DiscountAmount:F2}");
        Console.WriteLine($"Final Payable    : {FinalPayable:F2}");
        Console.WriteLine("--------------------------------");
    }
}

class Main1
{
    static PatientBill LastBill = null;
 
    public static void StartApp()
    {
        while (true)
        {
            Console.WriteLine("\n===== MediSure Clinic Billing =====");
            Console.WriteLine("1. Create New Bill");
            Console.WriteLine("2. View Last Bill");
            Console.WriteLine("3. Clear Last Bill");
            Console.WriteLine("4. Exit");

            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateNewBill();
                    break;
                case "2":
                    ViewLastBill();
                    break;
                case "3":
                    ClearLastBill();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }

    static void CreateNewBill()
    {
        PatientBill bill = new PatientBill();

        Console.Write("Bill ID: ");
        bill.BillId = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(bill.BillId))
        {
            Console.WriteLine("Bill ID cannot be empty.");
            return;
        }

        Console.Write("Patient Name: ");
        bill.PatientName = Console.ReadLine();

        Console.Write("Has Insurance (Y/N): ");
        bill.HasInsurance = Console.ReadLine().ToUpper() == "Y";

        Console.Write("Consultation Fee: ");
        bill.ConsultationFee = decimal.Parse(Console.ReadLine());

        Console.Write("Lab Charges: ");
        bill.LabCharges = decimal.Parse(Console.ReadLine());

        Console.Write("Medicine Charges: ");
        bill.MedicineCharges = decimal.Parse(Console.ReadLine());

        bill.CalculateBill();
        LastBill = bill;

        Console.WriteLine("Bill created successfully.");
    }

    static void ViewLastBill()
    {
        if (LastBill == null)
        {
            Console.WriteLine("No bill available.");
            return;
        }

        LastBill.DisplayBill();
    }

    static void ClearLastBill()
    {
        LastBill = null;
        Console.WriteLine("Last bill cleared.");
    }
}

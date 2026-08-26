

namespace partial_class;

public partial class Patient
{
    public void ShowPatientReport()
    {
        Console.WriteLine("========= Patient Report =========");

        Console.WriteLine($"Patient ID        : {PatientId}");
        Console.WriteLine($"Name              : {Name}");
        Console.WriteLine($"Age               : {Age}");

        Console.WriteLine();

        Console.WriteLine($"Blood Group       : {BloodGroup}");
        Console.WriteLine($"Disease           : {Disease}");
        Console.WriteLine($"Allergies         : {Allergies}");

        Console.WriteLine();

        Console.WriteLine($"Insurance Company : {InsuranceCompany}");
        Console.WriteLine($"Bill Amount       : {BillAmount}");

        Console.WriteLine("==================================");
    }
}
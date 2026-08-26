using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace PartialClass_Real_world_practice_qsn
{
    public partial class Patient 
    {
        public void ShowPatientReport()
        {


        
            Console.WriteLine("========= Patient Report =========");

            Console.WriteLine("Personal Information");
            Console.WriteLine("_______________________");

            Console.WriteLine($"Patient ID        : {PatientId}");
            Console.WriteLine($"Name              : {FullName}");
            Console.WriteLine($"Age               : {Age}");
            Console.WriteLine($"Gender            : {Gender}");
            Console.WriteLine($"Phone number      : {PhoneNumber}");



            Console.WriteLine();
            Console.WriteLine("Medical Information");
            Console.WriteLine("____________________");

            Console.WriteLine($"Blood Group       : {BloodGroup}");
            Console.WriteLine($"Disease           : {Disease}");
            Console.WriteLine($"Allergies         : {Allergies}");
            Console.WriteLine($"Height            : {Height}");
            Console.WriteLine($"weight            : {Weight}");


            Console.WriteLine();
            Console.WriteLine("Appointment");
            Console.WriteLine("____________________");
            Console.WriteLine($"Doctor           : {DoctorName}");
            Console.WriteLine($"Department       : {Department}");
            Console.WriteLine($"Appointment      : {AppointmentDate}");



            Console.WriteLine();
            Console.WriteLine("Billing");
            Console.WriteLine("____________________");

            Console.WriteLine($"Insurance Company : {InsuranceCompany}");
            Console.WriteLine($"Total Bill Amount       :{TotalBill}");
            Console.WriteLine($"Bill paid      : ");
            Console.WriteLine($"Remaining Bill to pay      : ");


            Console.WriteLine("==================================");
  
    }
 }
}

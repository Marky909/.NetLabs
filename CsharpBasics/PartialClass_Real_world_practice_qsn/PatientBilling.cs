using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PartialClass_Real_world_practice_qsn
{
    public partial class Patient
    {
        public decimal TotalBill { get; set; }
        public string InsuranceCompany { get; set; }
        public decimal AmountPaid { get; set; }
        
        public void GenerateBill(decimal amount)
        {
            TotalBill += amount;
        }

        public void PayBill(decimal amount)
        {
            if (TotalBill < amount)
            {
                Console.WriteLine("Payment cannot exceed the reamaining bill!!");
            }
            else
            {
                TotalBill -= amount;
            }
        }
        public void RemainingBalance()
        {
            Console.WriteLine($"The reaming amount to pay is {TotalBill}");
        }

        public void PatientBilling(decimal totalbill,string insurancecompany,decimal amountpaid)
        {
            TotalBill = totalbill;
            InsuranceCompany = insurancecompany;
            AmountPaid = amountpaid;
        }
    }
}

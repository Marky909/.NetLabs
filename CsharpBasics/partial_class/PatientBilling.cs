using System;


namespace partial_class
{
    public partial class Patient
    {
        public decimal BillAmount { get; private set; }

        public string InsuranceCompany { get; private set; } = "";

        public void UpdateBilling(decimal amount, string insuranceCompany)
        {
            if (amount < 0)
            {
                Console.WriteLine("Bill amount cannot be negative.");
                return;
            }

            BillAmount = amount;
            InsuranceCompany = insuranceCompany;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace PartialClass_Real_world_practice_qsn
{
    public partial class Patient
    {
        public string PatientId { get; }
        public string FullName { get; }
        private int Age;
        public int age
        {
            get
            {
                return Age;
            }
            set
            {
                if (value < 0)
                    age = 0;
                else
                    age = value;
            }

        }
        public string Gender { get; }

        private string PhoneNumber;
        public string phoneNumber
        {
            get
            {
                return PhoneNumber;
            }
            set
            {
                if (value.Length == 10)
                {
                    PhoneNumber = value;
                }
                else
                    PhoneNumber = "invalid number";
            }
        }


        public Patient(string patientid, string fullname, int age, string gender, string phonenumber)
        {
            PatientId = patientid;
            FullName = fullname;
            Age = age;
            Gender = gender;
            PhoneNumber = phonenumber;
        }
    }
}
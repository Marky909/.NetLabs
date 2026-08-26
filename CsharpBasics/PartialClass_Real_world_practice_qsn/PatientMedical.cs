using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClass_Real_world_practice_qsn
{
    public partial class Patient
    {
        public string BloodGroup { private set; get; }
        public string Disease { get; set; }
        public string Allergies { get; set; }

        public string Height { get; set; }
        
        public int Weight { get; set; }
        public void UpdateDiseases(string diseases)
        {
            Disease = diseases;
        }
        public void UpdateWeight(int weight)
        {
            Weight += weight;
        }

        public void PatientMedicalInfo(string bloodgroup,string disease,string allergies,string height,int weight)
        {
            BloodGroup = bloodgroup;
            Disease = disease;
            Allergies = allergies;
            Height = height;
            Weight = weight;
        }

    }
}

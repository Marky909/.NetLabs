using System;
using System.Collections.Generic;
using System.Text;

namespace PartialClass_Real_world_practice_qsn
{
    public partial class Patient
    {
        public string DoctorName { get; set; }
        public string Department { get; set; }
        public string AppointmentDate { get; set; }
        public void BookAppointment(string appointmentdate)
        {
            AppointmentDate = appointmentdate;
        }

        public void RescheduleAppointment(string appointmentdate)
        {
            AppointmentDate = appointmentdate;

        }
        public void PatientAppointment(string doctorname,string department,string appointmentdate)
        {
            DoctorName = doctorname;
            Department = department;
            AppointmentDate = appointmentdate;
        }

    }
}

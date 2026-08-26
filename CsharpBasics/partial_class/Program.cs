using partial_class;


Patient patient = new Patient("P101", "Marky", 21);

patient.BloodGroup = "O+";
patient.Disease = "Diarrhea";
patient.Allergies = "Honey";

patient.UpdateBilling(500, "Nepal Health Insurance");

patient.ShowPatientReport();
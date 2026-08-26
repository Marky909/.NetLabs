using System;
namespace partial_class;

public partial class Patient
{
    public string PatientId { get; }
    public string Name { get; }
    public int Age { get; }

    public Patient(string patientId, string name, int age)
    {
        PatientId = patientId;
        Name = name;
        Age = age;
    }
}
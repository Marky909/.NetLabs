//🏥 Assignment: Hospital Management System(Level 6 – Modularity Focus)
//🎯 Objective

//You are developing software for City Care Hospital.

//The hospital management team has noticed that the Patient class has grown to more than 2,000 lines, making it difficult for multiple developers to work on it.

//Your task is to reorganize the code using Partial Classes so that each team member can work on a separate module without causing merge conflicts.

//📌 Requirements

//Create a single class named

//Patient

//but split it into the following files.

//📁 PatientInfo.cs

//This file stores the patient's personal information.

//Properties
//PatientId
//FullName
//Age
//Gender
//PhoneNumber
//Constructor

//Initialize all the above values through a constructor.

//📁 PatientMedical.cs

//Store medical information.

//Properties
//BloodGroup
//Disease
//Allergies
//Height
//Weight
//Methods
//UpdateDisease()

//Updates the patient's disease.

//UpdateWeight()

//Changes the patient's weight.

//📁 PatientBilling.cs

//Store financial information.

//Properties
//TotalBill
//InsuranceCompany
//AmountPaid
//Methods
//GenerateBill(decimal amount)

//Adds a new bill.

//PayBill(decimal amount)

//Subtracts the payment from the remaining bill.

//Payment cannot exceed the remaining bill.

//RemainingBalance()

//Returns the remaining amount.

//📁 PatientAppointment.cs

//Store appointment information.

//Properties
//DoctorName
//Department
//AppointmentDate
//Methods
//BookAppointment()

//Books an appointment.

//RescheduleAppointment()

//Changes the appointment date.

//📁 PatientReport.cs

//Create

//ShowPatientReport()

//The report should look similar to this:

//==============================
//        PATIENT REPORT
//==============================

//Personal Information
//--------------------
//Patient ID     :
//Name           :
//Age            :
//Gender         :
//Phone Number   :

//Medical Information
//--------------------
//Blood Group    :
//Disease        :
//Allergies      :
//Height         :
//Weight         :

//Appointment
//--------------------
//Doctor         :
//Department     :
//Appointment    :

//Billing
//--------------------
//Insurance      :
//Total Bill     :
//Paid           :
//Remaining      :

//==============================
//📁 Program.cs

//After creating one patient object, perform the following tasks in order.

//Step 1

//Create the patient.

//Patient p1 = new Patient(...)
//Step 2

//Assign

//Blood Group
//Disease
//Allergies
//Height
//Weight
//Step 3

//Book an appointment.

//Step 4

//Generate a bill.

//Example

//$500
//Step 5

//Patient pays

//$200
//Step 6

//Patient gains weight.

//Update weight.

//Step 7

//Doctor changes the diagnosis.

//Update disease.

//Step 8

//Appointment is postponed.

//Reschedule the appointment.

//Step 9

//Patient pays the remaining amount.

//Step 10

//Print the complete report.

//⭐ Bonus Challenges

//After completing the assignment, add these features without creating new objects.

//Challenge 1

//Prevent negative bill amounts.

//Challenge 2

//Prevent age less than 0.

//Challenge 3

//If payment is greater than the remaining bill,

//display

//Payment exceeds remaining balance.
//Challenge 4

//If weight is below

//20 kg

//display

//Invalid weight.
//Challenge 5

//Display

//Patient has fully paid all hospital bills.

//when the remaining balance becomes zero.

//Challenge 6

//Show the report twice:

//Before treatment
//After treatment

//so you can observe what changed.
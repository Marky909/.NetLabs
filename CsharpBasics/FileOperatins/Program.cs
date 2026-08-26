using FileOperatins;

//WritingToFile file = new WritingToFile();
//string FilePath = "student.txt";
//file.WriteStudentData(FilePath);


//ReadingFromFile file1 = new ReadingFromFile();
//string FileLocation = "student.txt";
//file1.ReadStudentData(FileLocation);


WriteAndRead WR = new WriteAndRead();
//writing to file
string Location = "Employee.txt";
WR.WriteEmployeeDetails(Location);

Console.WriteLine("Employee details retriving......");
WR.ReadEmployeeDetails(Location);
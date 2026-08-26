using LINQDemo;

//List<Student> students = new List<Student>();
//{
//    new Student("Mark", 20);
//    new Student("Ram", 22);
//    new Student("Hari", 19);
//};
//var adults = students.Where(std => std.Age > 20);
//students.Add(new Student("Sita", 22));

//foreach(Student std in adults)
//{
//    Console.WriteLine(std.Name);
//}


Console.WriteLine("===Query syntax===");

List<Student1> studentss = new List<Student1>
{
    new Student1("Mark",20),
    new Student1("Ram",23),
    new Student1("Hari",19),
    new Student1("Sita",25)
};

var result =
    from student in studentss
    where student.Age > 20
    orderby student.Name
    select student;

foreach (Student1 stu in result)
{
    Console.WriteLine($"{stu.Name} - {stu.Age}");
}
using StructDemo;
Console.WriteLine("===Student Marks using struct======");


Student s1;

s1.Id = 1;
s1.Name = "Mark";
s1.Marks = 92.5;

s1.Display();

Console.WriteLine("===Constructor in struct======");

Rectangle r = new Rectangle(10, 5);

Console.WriteLine($"Area = {r.Area()}");
using Inheritacne;

SoftwareEngineerr eng = new SoftwareEngineerr("Marky","C#");
eng.DisplayInfo();

SoftwareEngineerrr engg = new SoftwareEngineerrr();
engg.Work();


Console.WriteLine("=====Method Hiding=====");

Dog D = new Dog();
D.Speak();
//Animal A = new Animal();
//A.Speak();

Console.WriteLine("=====Method Overriding=====");

Animal1 a = new Dog1();
a.Speak1();      // Dog barks

//Dog1 d = new Dog1();
//d.Speak1();
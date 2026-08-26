using CalculatorUsingInterface;

IOperation add = new Add();
IOperation sub = new Subtract();
IOperation mul = new Multiply();
IOperation div = new Divide();

Console.Write("Enter the first number: ");
double num1 = Convert.ToInt32(Console.ReadLine());

Console.Write("Enter the second number: ");
double num2 = Convert.ToInt32(Console.ReadLine());

Console.WriteLine($"The result of addition of {num1} and {num2} is {add.Calculate(num1, num2)}");
Console.WriteLine($"The result of subtraction of {num1} and {num2} is {sub.Calculate(num1, num2)}");
Console.WriteLine($"The result of Multiplication of {num1} and {num2} is {mul.Calculate(num1, num2)}");
Console.WriteLine($"The result of Division of {num1} and {num2} is {div.Calculate(num1, num2)}");
//Console.WriteLine(sub.Calculate(num1, num2));
//Console.WriteLine(mul.Calculate(num1, num2));
//Console.WriteLine(div.Calculate(num1, num2));


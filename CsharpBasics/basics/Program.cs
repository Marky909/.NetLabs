//Modern vs traditional way of declaring the variable in c#


int agee = 50; //tradiotional way explictly mentioning the type
var age = 20; // Modern way using var comiler will automatically mention the type as per the value supplied in statement
float f = (float)age;

Console.WriteLine(age.GetType());
Console.WriteLine(f.GetType());

//Operators in c#
//Arithmetic operator

int num1 = 10, num2 = 20;
int sum_result = num1 + num2;
Console.WriteLine();

int mul = num1 * num2;

float div = (float)num1 / num2;

int sub = num1 - num2;
int mod = num2 % num1;
int increased_num1 = num1++;
int decreased_num2 = num2--;

Console.WriteLine();



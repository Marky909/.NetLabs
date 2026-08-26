using ExceptionHandling2;

try
{
    int age = 15;

    if (age < 18)
    {
        throw new InvalidAgeException("Age must be 18 or above.");
    }

    Console.WriteLine("Eligible");
}
catch (InvalidAgeException ex)
{
    Console.WriteLine(ex.Message);
}
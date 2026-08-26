using System;
class program
{
    static void Main(string[] args)
    {
        try
        {
            int[] arr = { 1, 2, 3 };
            int a = 10;
            int b = 20;
            int result = a / b;
            Console.WriteLine(result);
            Console.WriteLine(arr[3]);
        }
        catch(DivideByZeroException ex)
        {
            Console.WriteLine("Exceptopn: " + ex.Message);
        }
        catch(IndexOutOfRangeException ex)
        {
            Console.WriteLine("Exception: " + ex.Message);
        }
        finally
        {
            Console.WriteLine("program succesfully completed!!!!");
        }
    }
}
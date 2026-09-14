using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        Console.Write("Enter the teststring: ");
        string teststring = Convert.ToString(Console.ReadLine()) ?? "";
        Console.Write("Enter the testpattern: ");
        string testIdentifier = Convert.ToString(Console.ReadLine()) ?? "";
        //string[] testStrings = { "", "a", "aa", "b", "ab", "aab", "abb", "aabb" };
        string pattern = @"^(a*|a*b+|abb)$";
        string identifierPattern = @"^[A-Za-z_][A-Za-z0-9_]*$";

        if (Regex.IsMatch(teststring, pattern))
            Console.WriteLine($"{teststring} → Accepted");
        else                     
            Console.WriteLine($"{teststring} → Rejected");

        if (Regex.IsMatch(testIdentifier, identifierPattern))
            Console.WriteLine($"{testIdentifier} → Accepted");
        else
            Console.WriteLine($"{testIdentifier} → Rejected");

    }
}



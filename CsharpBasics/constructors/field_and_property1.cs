//Example 1 (Simple) – Student Age Verification 🎓
//Scenario
//You are developing a college management system.
//Each student has:
//Name
//Age
//Rule
//Age cannot be negative.
//If someone tries to set a negative age, ignore it.

using System;
using constructors;


public class cms
{
    public string Name;
    private int age;
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value < 0)
            {
                age = 0;
            }
        }
    }
}



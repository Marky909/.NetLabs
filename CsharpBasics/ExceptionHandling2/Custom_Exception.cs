using System;
using System.Collections.Generic;
using System.Text;

namespace ExceptionHandling2
{
    public class InvalidAgeException:Exception
    {
        public InvalidAgeException(string message) : base(message)
        {
        }
    }

}

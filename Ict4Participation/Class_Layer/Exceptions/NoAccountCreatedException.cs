using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Layer.Exceptions
{
    public class NoAccountCreatedException : Exception
    {
        public NoAccountCreatedException(string message = "No account created could be created in the database")
            : base(message)
        {
            Console.WriteLine("No account could be created in the database with these credentials. Make sure the insert was processed properly");
        }
    }
}

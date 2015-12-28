using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Layer.Exceptions
{
    public class NoAccountFoundException : Exception
    {
        public NoAccountFoundException(string message = "No matching account found in the database")
            : base(message)
        {
            Console.WriteLine("No account could be found in the database with this email and username. Make sure the insert was processed properly");
        }
    }
}

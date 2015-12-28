using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Layer.Exceptions
{
    public class NotBoundToUserException : Exception
    {
        public NotBoundToUserException(string message = "Object not bound to user")
            : base(message)
        {
            Console.WriteLine("Given object was not given a userID and the application canceled its progress. Make sure the object is given a userID before you deploy it.");
        }
    }
}

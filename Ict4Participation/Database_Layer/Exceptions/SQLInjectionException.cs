using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Layer.Exceptions
{
    public class SQLInjectionException : Exception
    {
        public SQLInjectionException(string message = "Retrieve query: SQLInjection detected!") 
            : base(message) 
        {
            Console.WriteLine("A SQL injection has occurred. Either this is due to someone trying to add another query into a select query (which should not be possible), or someone has breached the code.");
            //TODO Idea:
            //Send something to the database to write down this IP and forbid connection for an hour
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database_Layer.Exceptions
{
    public class SQLInjectionException : Exception
    {
        public SQLInjectionException(string ex) : base(ex) {}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Layer.Utility_Classes
{
    public class ConvertTo
    {
        public static string OracleDateTime(DateTime dt)
        {
            return dt.ToString("d-MMM-yyyy HH:mm:ss");
        }
    }
}

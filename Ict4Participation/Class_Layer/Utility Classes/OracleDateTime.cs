using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Layer.Utility_Classes
{
    public class ConvertTo
    {
        public static string OracleDateTime(Nullable<DateTime> dt)
        {
            CultureInfo ci = new CultureInfo("en-EN");
            return dt != null ? ((DateTime)dt).ToString("d-MMM-yyyy HH:mm:ss", ci) : null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Layer;

namespace Class_Layer.Controllers
{
    public class DatabaseController
    {
        public static void SetHost()
        {
            Console.WriteLine("Setting database host...");
            Console.WriteLine(Database.FindHost());
        }
    }
}

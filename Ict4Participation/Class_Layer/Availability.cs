using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Layer.Interfaces;

namespace Class_Layer
{
    public class Availability : IAccInfo
    {
        public int UserID { get; private set; }
        public string Daytime { get; private set; }
        public string Day { get; private set; }

        public Availability(int userID, string day, string daytime)
        {
            this.UserID = userID;
            this.Day = day;
            this.Daytime = daytime;
        }

        public bool Add()
        {
            //TODO
            //Call database to add this availability
            return false;
        }

        public bool Remove()
        {
            //TODO
            //Call database to remove this availability
            return false;
        }

        public static List<Availability> GetAll(int userID)
        {
            //TODO
            //Load in distinct skills from user

            return null;
        }
    }
}

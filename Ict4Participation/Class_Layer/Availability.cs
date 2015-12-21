using System;
using System.Collections.Generic;
using System.Data;
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
            //Call database to add this availability
            return Database_Layer.Database.InsertAvailability(this.UserID, this.Day, this.Daytime);
        }

        public bool Remove()
        {
            //Call database to remove this availability
            return Database_Layer.Database.DeleteAvailability(this.UserID, this.Day, this.Daytime);
        }

        public static List<Availability> GetAll(int userID)
        {
            List<Availability> avails = new List<Availability>();
            //Load in availability from user
            DataTable Dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Availability\" WHERE \"ID\"= (SELECT \"ID\" FROM \"Availability_Acc\" WHERE \"ACC_ID\" = " + userID + ")");
            foreach (DataRow row in Dt.Rows)
            {
                avails.Add(
                    new Availability(
                        userID,
                        row["Day"].ToString(),
                        row["Period"].ToString()
                        ));
            }
            return avails;
        }
    }
}

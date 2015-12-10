using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Layer.Interfaces;

namespace Class_Layer
{
    public class Skill : IAccInfo
    {
        public int UserID { get; private set; }
        public string Name { get; private set; }

        public Skill(int userid, string name)
        {
            this.UserID = userid;
            this.Name = name;
        }

        public bool Add()
        {         
            return Database_Layer.Database.SkillInsert(this.Name, this.UserID);            
        }

        public bool Remove()
        {
            return Database_Layer.Database.SkillDelete(this.Name, this.UserID);
        }

        public static List<Skill> GetAll(Nullable<int> userID = null)
        {
            List<Skill> skills = new List<Skill>();
            
            if (userID != null)//get all the user skills of specified user
            {
                DataTable Dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc_Skill\" WHERE \"ACC_ID\"=" + userID);
                foreach (DataRow row in Dt.Rows)
                {
                    skills.Add(
                        new Skill(
                            Convert.ToInt32(userID),
                            row["SKILL_NAME"].ToString()
                            ));
                }
            }
            else//get all skills if no ID is specified
            {
                DataTable Dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Skill\"");
                foreach (DataRow row in Dt.Rows)
                {
                    skills.Add(
                        new Skill(
                            0,
                            row["UName"].ToString()
                            ));
                }
            }
            return skills;
        }
    }
}

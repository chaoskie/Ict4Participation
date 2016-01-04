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
        public int UserID { get; set; }
        public string Name { get; private set; }

        public Skill(int userid, string name)
        {
            this.UserID = userid;
            this.Name = name;
        }

        public bool Add()
        {         
            return Database_Layer.Database.InsertSkillAccount(this.Name, this.UserID);            
        }

        public bool Remove()
        {
            return Database_Layer.Database.DeleteSkillAccount(this.Name, this.UserID);
        }

        public static List<Skill> GetAll(Nullable<int> fID = null, bool isUser = true)
        {
            List<Skill> skills = new List<Skill>();
            string query = isUser ? "Acc" : "Question";
            
            if (fID != null)//get all the user skills of specified user
            {
                DataTable Dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"" + query + "_Skill\" WHERE \"" + query.ToUpper() + "_ID\"=" + fID);
                foreach (DataRow row in Dt.Rows)
                {
                    skills.Add(
                        new Skill(
                            Convert.ToInt32(fID),
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
                            row["Name"].ToString() //row["UName"].ToString()
                            ));
                }
            }
            return skills;
        }
    }
}

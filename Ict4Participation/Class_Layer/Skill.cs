using System;
using System.Collections.Generic;
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

        public Skill(int id, string name)
        {
            this.UserID = id;
            this.Name = name;
        }

        public bool Add()
        {
            //TODO
            //Call database to add this skill
            return false;
        }

        public bool Remove()
        {
            //TODO
            //Call database to remove this skill
            return false;
        }

        public static List<Skill> GetAll(Nullable<int> userID = null)
        {
            //get all if no ID is specified
            if (userID == null)
            {
                //TODO
                //Load in distinct skills from everyone
            }
            //Get user-specific if ID is specified
            else
            {
                //TODO
                //Load in distinct skills from user
            }
            return null;
        }
    }
}

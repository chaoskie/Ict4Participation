using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Layer;

namespace Class_Layer
{
    public class QuestionAccount
    {
        public int AccID
        {
            get;
            private set;
        }
        public int QueID
        {
            get;
            private set;
        }
        public DateTime AcceptionDate
        {
            get;
            private set;
        }

        /// <summary>
        /// Fetches all the actions belonging to a user through their questions
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        /// <returns>A list of all the actions</returns>
        public static List<QuestionAccount> FetchQuestionActions(int userID)
        {
            List<QuestionAccount> qactions = new List<QuestionAccount>();

            DataTable dt = Database.RetrieveQuery("SELECT * FROM \"Question_Acc\" WHERE \"QUESTION_ID\" IN (SELECT * FROM \"Question\" WHERE \"PosterACC_ID\" = " + userID + ")");
            foreach (DataRow row in dt.Rows)
            {
                qactions.Add(new QuestionAccount(
                    Convert.ToInt32(row["ACC_ID"]),
                    Convert.ToInt32(row["QUESTION_ID"]),
                    Convert.ToDateTime(row["AcceptedDate"])
                    ));
            }
            return qactions;
        }

        private QuestionAccount(int accID, int queID, DateTime acceptionDate)
        {
            this.AccID = accID;
            this.QueID = queID;
            this.AcceptionDate = acceptionDate;
        }
    }
}

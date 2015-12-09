//-----------------------------------------------------------------------
// <copyright file="Question.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Layer
{
    /// <summary>
    /// Subclass of the post class
    /// </summary>
    public class Question : Post
    {
        /// <summary>
        /// Gets the ID of the question
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Gets the title of the question
        /// </summary>
        public string Title { get; private set; }
        /// <summary>
        /// Gets the start date of help for this question
        /// </summary>
        public Nullable<DateTime> StartDate { get; private set; }
        /// <summary>
        /// Gets the end date of help for this question
        /// </summary>
        public Nullable<DateTime> EndDate { get; private set; }
        /// <summary>
        /// Gets the post date for this question
        /// </summary>
        public DateTime PostDate { get; private set; }
        /// <summary>
        /// Gets the description of this question
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Gets the urgency of this question
        /// </summary>
        public bool Urgent { get; private set; }
        /// <summary>
        /// Gets the location of this question
        /// </summary>
        public string Location { get; private set; }
        /// <summary>
        /// Gets the maximum amount of volunteers on this question
        /// </summary>
        public int AmountAccs { get; private set; }
        /// <summary>
        /// Gets the status of this question
        /// </summary>
        public Enums.Status Status { get; private set; }
        /// <summary>
        /// Gets the skills of a question
        /// </summary>
        public List<string> Skills { get; private set; }
        /// <summary>
        /// Gets the IDs of all volunteers
        /// </summary>
        public List<int> Volunteers { get; private set; }

        /// <summary>
        /// Creates this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Create()
        {
            string st = Utility_Classes.ConvertTo.OracleDateTime(this.StartDate);
            string et = Utility_Classes.ConvertTo.OracleDateTime(this.EndDate);
            //insert into database
            return Database_Layer.Database.InsertQuestion(this.Title, st, et, this.Description, this.Urgent, this.Location, this.AmountAccs, this.Status, this.Skills, this.Volunteers);
        }

        /// <summary>
        /// Deletes this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Delete()
        {
            //Call database for delete query
            return Database_Layer.Database.DeleteQuestion(this.PostID);
        }

        /// <summary>
        /// Updates this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Update()
        {
            string st = Utility_Classes.ConvertTo.OracleDateTime(this.StartDate);
            string et = Utility_Classes.ConvertTo.OracleDateTime(this.EndDate);
            //Call database for update query
            return Database_Layer.Database.UpdateQuestion(this.PostID, this.Title, st, et, this.Description, this.Urgent, this.Location, this.AmountAccs, this.Status, this.Skills, this.Volunteers);
        }

        public static List<Question> GetAll(Nullable<int> userID)
        {
            List<Question> questions = new List<Question>();
            string addquery = String.Empty;

            if (userID != null)
            //If accountID is not null, get all questions of specified users, else run the default query to get all questions
            {
                addquery = " WHERE \"PosterACC_ID\"=" + userID;
            }

            DataTable Dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Question\"" + addquery);
            foreach (DataRow row in Dt.Rows)
            {
                //Create a list of volunteers, by default: none
                List<int> volunteers = new List<int>();
                //Fill the list of volunteers with the actual volunteers if there are any
                DataTable VolDt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Question_Acc\" WHERE \"QUESTION_ID\"=" + row["ID"].ToString());
                foreach (DataRow VolunteersRow in VolDt.Rows)
                {
                    volunteers.Add(Convert.ToInt32(row["ACC_ID"]));
                }
                //Check urgency
                bool urg = row["Urgency"].ToString() == "1" ? true : false;

                //Add the new question
                questions.Add(new Question(
                    Convert.ToInt32(row["ID"]),
                    Convert.ToInt32(row["PosterACC_ID"]),
                    row["Title"].ToString(),
                    Convert.ToDateTime(row["StartDate"]),
                    Convert.ToDateTime(row["EndDate"]),
                    row["Description"].ToString(),
                    urg,
                    row["Location"].ToString(),
                    Convert.ToInt32(row["AmountACCs"]),
                    Skill.GetAll(Convert.ToInt32(row["ID"])).Select(s => s.ToString()).ToList(),
                    volunteers
                    ));
            }
            //Return the question list
            return questions;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Question"/> class.
        /// </summary>
        /// <param name="postID">The ID of the question</param>
        /// <param name="title">The title of the question</param>
        /// <param name="schedule">The scheduled time of the question</param>
        /// <param name="description">The description of the question</param>
        /// <param name="questionLocation">The location of the question</param>
        public Question(int postID, int posterID, string title, Nullable<DateTime> startDate, Nullable<DateTime> endDate,
            string description, bool urgency, string location, int amnt, List<string> skills, List<int> volunteers)
            : base(postID, posterID)
        {
            this.Title = title;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.Description = description;
            this.Urgent = urgency;
            this.Location = location;
            this.AmountAccs = amnt;
            this.Skills = skills;
            this.Volunteers = volunteers;
        }

        //Returns a full description
        public string GetDescription(int postid, out int ID)
        {
            //TODO
            //Make a nice ToString method from this, using the GetOP method as well
            ID = 0;
            return "";
        }
    }
}

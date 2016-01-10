//-----------------------------------------------------------------------
// <copyright file="Question.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
namespace Class_Layer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;

    /// <summary>
    /// The <see cref="Question"/> class is a subclass of the post class.
    /// </summary>
    public class Question : Post
    {
        #region Fields
        /// <summary>
        /// The status of this question.
        /// </summary>
        /// <value>The status of the question.</value>
        private Enums.Status status;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Question"/> class.
        /// </summary>
        /// <param name="postID">The ID of the question.</param>
        /// <param name="posterID">The ID of the poster of the question.</param>
        /// <param name="title">The title of the question.</param>
        /// <param name="startDate">The start date of the question.</param>
        /// <param name="endDate">The end date of the question.</param>
        /// <param name="description">The description of the question.</param>
        /// <param name="urgency">The urgency of the question.</param>
        /// <param name="location">The location of the question.</param>
        /// <param name="amnt">The amount of volunteers of the question.</param>
        /// <param name="skills">The list of skills of the question.</param>
        /// <param name="volunteers">The list of volunteer IDs of the question.</param>
        /// <param name="status">The status of the question.</param>
        public Question(int postID, int posterID, string title, DateTime? startDate, DateTime? endDate, string description, bool urgency, string location, int amnt, List<string> skills, List<int> volunteers, int status)
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
            this.status = (Enums.Status)status;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the ID of the question.
        /// </summary>
        /// <value>The ID of the question.</value>
        public int ID { get; private set; }

        /// <summary>
        /// Gets the title of the question.
        /// </summary>
        /// <value>The title of the question.</value>
        public string Title { get; private set; }

        /// <summary>
        /// Gets the start date of help for this question.
        /// </summary>
        /// <value>The start date of the question.</value>
        public DateTime? StartDate { get; private set; }

        /// <summary>
        /// Gets the end date of help for this question.
        /// </summary>
        /// <value>The end date of the question.</value>
        public DateTime? EndDate { get; private set; }

        /// <summary>
        /// Gets the post date of this question.
        /// </summary>
        /// <value>The post date of this question.</value>
        public DateTime PostDate { get; private set; }

        /// <summary>
        /// Gets the description of this question.
        /// </summary>
        /// <value>The description of the question.</value>
        public string Description { get; private set; }

        /// <summary>
        /// Gets a value indicating whether the question is urgent or not.
        /// </summary>
        /// <value>The urgency of this question.</value>
        public bool Urgent { get; private set; }

        /// <summary>
        /// Gets the location of this question.
        /// </summary>
        /// <value>The location of the question.</value>
        public string Location { get; private set; }

        /// <summary>
        /// Gets the maximum amount of volunteers on this question.
        /// </summary>
        /// <value>The maximum amount of volunteers on this question.</value>
        public int AmountAccs { get; private set; }

        /// <summary>
        /// Gets the status of this question.
        /// </summary>
        /// <value>The status of the question.</value>
        public string Status
        {
            get
            {
                return this.status.ToString();
            }

            private set
            {
                this.status = (Enums.Status)Enum.Parse(typeof(Enums.Status), value);
            }
        }

        /// <summary>
        /// Gets the list of skills of the question.
        /// </summary>
        /// <value>The list of skills of the question.</value>
        public List<string> Skills { get; private set; }

        /// <summary>
        /// Gets the IDs of all volunteers of the question.
        /// </summary>
        /// <value>The IDs of all volunteers of the question.</value>
        public List<int> Volunteers { get; private set; }
        #endregion

        #region Static Methods
        /// <summary>
        /// Method to get all questions of a user from the database.
        /// </summary>
        /// <param name="userID">The ID of the user.</param>
        /// <returns>Returns a list of questions.</returns>
        public static List<Question> GetAll(int? userID)
        {
            List<Question> questions = new List<Question>();
            string addquery = string.Empty;

            if (userID != null)
            {
                // If accountID is not null, get all questions of specified users, else run the default query to get all questions
                addquery = " WHERE \"PosterACC_ID\"=" + userID;
            }

            DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Question\"" + addquery);
            foreach (DataRow row in dt.Rows)
            {
                // Create a list of volunteers, by default: none
                List<int> volunteers = new List<int>();
                
                // Fill the list of volunteers with the actual volunteers if there are any
                DataTable volDt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Question_Acc\" WHERE \"QUESTION_ID\"=" + row["ID"].ToString());
                foreach (DataRow volunteersRow in volDt.Rows)
                {
                    volunteers.Add(Convert.ToInt32(volunteersRow["ACC_ID"]));
                }

                // Check urgency
                bool urg = row["Urgent"].ToString() == "1" ? true : false;

                // Add the new question
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
                    Skill.GetAll(Convert.ToInt32(row["ID"]), false).Select(s => s.Name).ToList(),
                    volunteers,
                    Convert.ToInt32(row["Status"])));
            }

            // Return the question list
            return questions;
        }
        #endregion

        #region Non-Static Methods
        /// <summary>
        /// Updates the question
        /// </summary>
        /// <returns></returns>
        public override bool Update()
        {
            //Create a list of volunteers, by default: none
            List<int> volunteers = new List<int>();
            //Fill the list of volunteers with the actual volunteers if there are any
            DataTable VolDt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Question_Acc\" WHERE \"QUESTION_ID\"=" + base.PostID);
            foreach (DataRow VolunteersRow in VolDt.Rows)
            {
                volunteers.Add(Convert.ToInt32(VolunteersRow["ACC_ID"]));
            }
            List<string> sks = Skill.GetAll(this.PostID, false).Select(s => s.Name).ToList();

            return Update(sks, volunteers);

        }

        /// <summary>
        /// Creates this database entry.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the question has been successfully created or not.</returns>
        public override bool Create()
        {
            bool flawless = true;
            int? qID = null;
            string st = Utility_Classes.ConvertTo.OracleDateTime(this.StartDate);
            string et = Utility_Classes.ConvertTo.OracleDateTime(this.EndDate);

            // Insert into database
            if (!Database_Layer.Database.InsertQuestion(this.Title, this.PosterID, st, et, this.Description, this.Urgent, this.Location, this.AmountAccs, (int)this.status, out qID))
            {
                Console.WriteLine("Couldn't create new question");
                flawless = false;
            }

            if (qID == null)
            {
                Console.WriteLine("Couldn't retrieve newly made question");
                flawless = false;
            }

            foreach (string s in this.Skills)
            {
                if (!Database_Layer.Database.InsertSkillQuestion(s, Convert.ToInt32(qID)))
                {
                    Console.WriteLine("Couldn't add the following skill reference: " + s);
                    flawless = false;
                }
            }

            return flawless;
        }

        /// <summary>
        /// Deletes this database entry.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the question has been successfully deleted or not.</returns>
        public override bool Delete()
        {
            // Call database for delete query
            return Database_Layer.Database.DeleteQuestion(this.PostID);
        }

        /// <summary>
        /// Updates this database entry.
        /// </summary>
        /// <param name="oldskills">The current list of skills.</param>
        /// <param name="oldvolunteers">The current list of volunteer IDs.</param>
        /// <returns>Returns a boolean, indicating whether the question has been successfully updated or not.</returns>
        private bool Update(List<string> oldskills, List<int> oldvolunteers)
        {
            bool flawless = true;
            string st = Utility_Classes.ConvertTo.OracleDateTime(this.StartDate);
            string et = Utility_Classes.ConvertTo.OracleDateTime(this.EndDate);

            this.status = this.AmountAccs > oldvolunteers.Count ? Enums.Status.Open : Enums.Status.Aangenomen;

            // Call database for update query
            if (!Database_Layer.Database.UpdateQuestion(this.PostID, this.Title, this.PosterID, st, et, this.Description, this.Urgent, this.Location, this.AmountAccs, (int)this.status))
            {
                Console.WriteLine("Couldn't update question");
                return false;
            }

            // Update skills
            // =============
            foreach (string s in this.Skills)
            {
                // If old skills does not have this skill, add it
                if (!oldskills.Contains(s))
                {
                    if (!Database_Layer.Database.InsertSkillQuestion(s, this.PostID))
                    {
                        Console.WriteLine("Couldn't add the following skill reference: " + s);
                        flawless = false;
                    }
                }
            }

            foreach (string s in oldskills)
            {
                // If new skills does not have this skill, remove it
                if (!this.Skills.Contains(s))
                {
                    if (!Database_Layer.Database.DeleteSkillQuestion(this.PostID, s))
                    {
                        Console.WriteLine("Couldn't remove the following skill reference: " + s);
                        flawless = false;
                    }
                }
            }

            // Update volunteers
            // =================
            foreach (int v in this.Volunteers)
            {
                // If old volunteer list does not have this volunteer, add it
                if (!oldvolunteers.Contains(v))
                {
                    if (!Database_Layer.Database.InsertQuestionAccount(this.PostID, v))
                    {
                        Console.WriteLine("Couldn't add the volunteer with ID: " + v);
                        flawless = false;
                    }
                }
            }

            foreach (int v in oldvolunteers)
            {
                // If new skills does not have this skill, remove it
                if (!this.Volunteers.Contains(v))
                {
                    if (!Database_Layer.Database.DeleteQuestionAccount(this.PostID, v))
                    {
                        Console.WriteLine("Couldn't remove the volunteer with ID: " + v);
                        flawless = false;
                    }
                }
            }

            return flawless;
        }
        #endregion
    }
}

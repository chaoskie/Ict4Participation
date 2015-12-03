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

        //TODO:
        //List accounts somehow

        /// <summary>
        /// Posts a question
        /// <param name="posterID">The ID of the user who posts the question</param>
        /// <param name="title">The title of the question</param>
        /// <param name="startDate">The start date of when help is sought</param>
        /// <param name="endDate">The end date of when help is sought</param>
        /// <param name="description">The description of the question</param>
        /// <param name="urgency">Whether the question is urgent or not</param>
        /// <param name="location">The location of the question</param>
        /// <param name="amnt">The maximum amount of volunteers</param>
        /// <param name="skills">The skills that are required for this question</param>
        /// <param name="q">The newly made question</param>
        /// <returns>Whether it succeeded or not</returns>
        public static bool CreateQuestion(int posterID, string title, Nullable<DateTime> startDate, Nullable<DateTime> endDate, 
            string description, bool urgency, string location, int amnt, List<string> skills, out Question q)
        {
            //TODO
            //Call database to insert question
            //Database returns the ID of last inserted object
            //Insert skills to database
            q = null;
            return false;
        }

        /// <summary>
        /// Deletes the question with specified ID
        /// </summary>
        /// <param name="ID"></param>
        public static void Delete(int ID)
        {
            Database_Layer.Database.DeleteQuestion(ID);
        }

        /// <summary>
        /// Retrieves questions from the database
        /// </summary>
        /// <param name="all">Whether they have to be all the questions, or just the op</param>
        /// <param name="accountid">the ID of the op, if all is not true</param>
        /// <returns></returns>
        public static List<Question> FindQuestions(bool all = true, int accountid = 0)
        {
            //TODO
            //Check whether all questions should be retrieved or only from specified account
            //Call database with query
            //Return list
            return null;
        }

        /// <summary>
        /// Retrieves the name and ID of the original poster
        /// </summary>
        /// <param name="postid">ID of the post</param>
        /// <param name="ID">ID of the user</param>
        /// <returns>the name of the original poster</returns>
        public static string GetOP(int postid, out int ID)
        {
            string name = String.Empty;
            ID = 0;
            DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT Name, ID FROM \"Acc\" WHERE \"ID\" = (SELECT \"PosterACC_ID\" FROM \"Question\" WHERE \"ID\" = " + postid + ")");
            foreach (DataRow row in dt.Rows)
            {
                ID = Convert.ToInt32(row["ID"]);
                name = row["Name"].ToString();
            }
            return name;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="postID">The ID of the question</param>
        /// <param name="posterID">The poster ID of the question</param>
        /// <param name="title">The title of the question</param>
        /// <param name="startDate">The start date of the question help</param>
        /// <param name="endDate">The end date of the question help</param>
        /// <param name="description">The description for the question</param>
        /// <param name="urgency">Whether the question is urgent or not</param>
        /// <param name="location">The location of the question</param>
        /// <param name="amnt">The maximum amount of volunteers</param>
        /// <param name="skills">The skills needed for the question</param>
        public static void Update(int postID, int posterID, string title, Nullable<DateTime> startDate, Nullable<DateTime> endDate,
            string description, bool urgency, string location, int amnt, List<string> skills, int userID)
        {
            //TODO
            //Call database to update question
            //Update question skills
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Question"/> class.
        /// </summary>
        /// <param name="postID">The ID of the question</param>
        /// <param name="title">The title of the question</param>
        /// <param name="schedule">The scheduled time of the question</param>
        /// <param name="description">The description of the question</param>
        /// <param name="questionLocation">The location of the question</param>
        private Question(int postID, int posterID, string title, Nullable<DateTime> startDate, Nullable<DateTime> endDate,
            string description, bool urgency, string location, int amnt, List<string> skills)
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

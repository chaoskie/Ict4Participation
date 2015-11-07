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
        /// Gets the scheduled time of the question
        /// </summary>
        public DateTime Schedule { get; private set; }

        /// <summary>
        /// Gets the description of the question
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Gets the location of the question
        /// </summary>
        public Location QuestionLocation { get; private set; }

        /// <summary>
        /// Gets the skills of a question
        /// </summary>
        public List<string> Skills { get; private set; }

        /// <summary>
        /// Gets the userID of a question
        /// </summary>
        public int UserID { get; private set; }

        /// <summary>
        /// Posts a question
        /// </summary>
        /// <param name="accountid">ID of the poster</param>
        /// <param name="title">title of the question</param>
        /// <param name="schedule">date of the question to be resolved</param>
        /// <param name="description">the description of the question</param>
        /// <param name="questionLocation">the location of the question</param>
        /// <param name="q">a returned question</param>
        /// <returns>Whether the question was able to be posted</returns>
        public static bool CreateQuestion(int accountid, string title, DateTime dateSchedule, string description, Location questionLocation, List<string> skills, out Question q)
        {
            bool creationSuccess = false;
            bool doInsertLocation = false;
            q = null;
            string schedule = dateSchedule.ToString("dd-MMM-yyyy HH:mm:s");

            try
            {
                int locID = 0;

                //Check if exists, if not: insert instead
                doInsertLocation = Location.ValidateLocation(questionLocation, out locID) == true ? false : true;

                //If it exists, don't insert a new location, else do
                if (doInsertLocation)
                { locID = Location.InsertLocation(questionLocation); }

                //Insert question 
                Database_Layer.Database.NewQuestion(title, accountid, schedule, description, locID);
                //Retrieve question ID / post ID
                DataTable dtQuestion = Database_Layer.Database.RetrieveQuery(
                    String.Format("SELECT max(ID) FROM \"Question\" WHERE \"PosterACC_ID\" = '{0}'",
                    accountid));
                int qID = 0;
                //Set questionID
                foreach (DataRow row in dtQuestion.Rows)
                {
                    qID = Convert.ToInt32(row["max(ID)"]);
                }
                //Insert matching skills to database
                foreach (string skill in skills)
                {
                    Database_Layer.Database.SkillInsert(skill, qID);
                }

                q = new Question(qID, title, dateSchedule, description, questionLocation, skills, accountid);
                creationSuccess = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return creationSuccess;
        }

        /// <summary>
        /// Retrieves questions from the database
        /// </summary>
        /// <param name="all">Whether they have to be all the questions, or just the op</param>
        /// <param name="accountid">the ID of the op, if all is not true</param>
        /// <returns></returns>
        public static List<Question> FindQuestions(bool all = true, int accountid = 0)
        {
            List<Question> q = new List<Question>();
            DataTable dtQuestion;
            //If all posts are meant to be retrieved
            if (all)
            {
                dtQuestion = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Question\"");
            }
            //else retrieve all the user's posts
            else
            {
                dtQuestion = Database_Layer.Database.RetrieveQuery(
                    String.Format("SELECT * FROM \"Question\" WHERE \"PosterACC_ID\" = '{0}'",
                    accountid));
            }

            foreach (DataRow row in dtQuestion.Rows)
            {
                //Create a new instance of the matching location
                Location loc = new Location(Convert.ToInt32(row["LOCATION_ID"]));

                //Find and add skills
                DataTable dtSkills = Database_Layer.Database.RetrieveQuery(String.Format("SELECT * FROM \"Question_Skill\" WHERE \"QUESTION_ID\" = {0}", row["ID"].ToString()));
                List<string> skills = new List<string>();
                foreach (DataRow skill in dtSkills.Rows)
                {
                    skills.Add(skill["SKILL_NAME"].ToString());
                }

                //Add question to list
                q.Add(new Question(Convert.ToInt32(row["ID"]),
                    row["Title"].ToString(),
                    Convert.ToDateTime(row["TimeTable"]),
                    row["Description"].ToString(),
                    loc,
                    skills,
                    Convert.ToInt32(row["PosterACC_ID"])
                    ));
            }
            return q;
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
            DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc\" WHERE \"ID\" = (SELECT \"PosterACC_ID\" FROM \"Question\" WHERE \"ID\" = " + postid + ")");
            foreach (DataRow row in dt.Rows)
            {
                ID = Convert.ToInt32(row["ID"]);
                name = row["Name"].ToString();
            }
            return name;
        }

        /// <summary>
        /// Updates the question
        /// </summary>
        /// <param name="postID">The ID of the question</param>
        /// <param name="title">The title of the question</param>
        /// <param name="schedule">The time of help for the question</param>
        /// <param name="description">The description for the question</param>
        /// <param name="location">The location of the question</param>
        /// <param name="skills">The skills needed for the question</param>
        /// <param name="userID">The ID of the user who posted the question</param>
        public static void Update(int postID, string title, DateTime schedule, string description, Location location, List<string> skills, int userID)
        {
            //TODO
            //Call database update query
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Question"/> class.
        /// </summary>
        /// <param name="postID">The ID of the question</param>
        /// <param name="title">The title of the question</param>
        /// <param name="schedule">The scheduled time of the question</param>
        /// <param name="description">The description of the question</param>
        /// <param name="questionLocation">The location of the question</param>
        private Question(int postID, string title, DateTime schedule, string description, Location questionLocation, List<string> skills, int userid)
            : base(postID, title)
        {
            this.Schedule = schedule;
            this.Description = description;
            this.Schedule = schedule;
            this.QuestionLocation = questionLocation;
            this.Skills = skills;
        }

        //Returns a full description
        public string GetDescription(int postid, out int ID)
        {
            return string.Format(
                "Door: {0} \nHulp gewenst op: {1} \nBeschrijving: {2} \nLocatie: {3}",
                GetOP(postid, out ID), Schedule.ToString(), Description, QuestionLocation.ToString());
        }
    }
}

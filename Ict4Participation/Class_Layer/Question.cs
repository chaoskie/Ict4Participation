﻿//-----------------------------------------------------------------------
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
        /// Posts a question
        /// </summary>
        /// <param name="accountid">ID of the poster</param>
        /// <param name="title">title of the question</param>
        /// <param name="schedule">date of the question to be resolved</param>
        /// <param name="description">the description of the question</param>
        /// <param name="questionLocation">the location of the question</param>
        /// <param name="q">a returned question</param>
        /// <returns>Whether the question was able to be posted</returns>
        public static bool CreateQuestion(int accountid, string title, DateTime dateSchedule, string description, Location questionLocation, out Question q)
        {
            bool creationSuccess = false;
            bool doInsertLocation = false;
            q = null;
            string schedule = dateSchedule.ToString("dd-MMM-yyyy HH:mm:s");

            try
            {
                //Check if location already exists
                DataTable dtLocation = Database_Layer.Database.RetrieveQuery(
                    String.Format("SELECT ID FROM \"Location\" WHERE \"Longitude\" = '{0}' AND \"Latitude\" = '{1}' AND \"Description\" = '{2}'",
                    questionLocation.PreciseLocation.X, questionLocation.PreciseLocation.Y, questionLocation.DescribedLocation));
                doInsertLocation = dtLocation != null ? false : true;

                int locID = 0;

                //If it exists, don't insert a new location, else do
                if (doInsertLocation)
                {
                    Database_Layer.Database.ExecuteQuery(
                        String.Format("INSERT INTO \"Location\" (\"Longitude\", \"Latitude\", \"Description\") VALUES ('{0}', '{1}', '{2}')",
                        questionLocation.PreciseLocation.X, questionLocation.PreciseLocation.Y, questionLocation.DescribedLocation));
                    //Retrieve location ID. again.
                    dtLocation = Database_Layer.Database.RetrieveQuery(
                        String.Format("SELECT ID FROM \"Location\" WHERE \"Longitude\" = '{0}' AND \"Latitude\" = '{1}' AND \"Description\" = '{2}'",
                        questionLocation.PreciseLocation.X, questionLocation.PreciseLocation.Y, questionLocation.DescribedLocation));
                }
                //Set locationID
                foreach (DataRow row in dtLocation.Rows)
                {
                    locID = Convert.ToInt32(row["ID"]);
                }

                //Insert question 
                Database_Layer.Database.ExecuteQuery(
                    String.Format("INSERT INTO \"Question\" (\"Title\", \"PosterACC_ID\", \"Timetable\", \"Description\", \"LOCATION_ID\") "
                + "VALUES ('{0}', {1}, TO_DATE('{2}', 'dd-mon-yyyy HH24:mi:ss'), '{3}', {4})",
                    title, accountid, schedule, description, locID));
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

                q = new Question(qID, title, dateSchedule, description, questionLocation);
                creationSuccess = true;
            }
            catch (Exception e)
            {

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
                //Find location and create an instance
                DataTable dtLocation = Database_Layer.Database.RetrieveQuery(
                      String.Format("SELECT * FROM \"Location\" WHERE \"ID\" = '{0}'", row["LOCATION_ID"]));
                Location loc = null;
                foreach (DataRow rowLoc in dtLocation.Rows)
                {
                    loc = new Location(new PointF(
                        (float)(Convert.ToDecimal(rowLoc["Longitude"])),
                        (float)(Convert.ToDecimal(rowLoc["Latitude"]))),
                        rowLoc["Description"].ToString());
                }

                //Add question to list
                q.Add(new Question(Convert.ToInt32(row["ID"]),
                    row["Title"].ToString(),
                    Convert.ToDateTime(row["TimeTable"]),
                    row["Description"].ToString(),
                    loc
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
        /// Initializes a new instance of the <see cref="Question"/> class.
        /// </summary>
        /// <param name="postID">The ID of the question</param>
        /// <param name="title">The title of the question</param>
        /// <param name="schedule">The scheduled time of the question</param>
        /// <param name="description">The description of the question</param>
        /// <param name="questionLocation">The location of the question</param>
        private Question(int postID, string title, DateTime schedule, string description, Location questionLocation)
            : base(postID, title)
        {
            this.Schedule = schedule;
            this.Description = description;
            this.Schedule = schedule;
            this.QuestionLocation = questionLocation;
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

//-----------------------------------------------------------------------
// <copyright file="Question.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
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
        public static bool CreateQuestion(int accountid, string title, DateTime schedule, string description, Location questionLocation, out Question q)
        {
            bool creationSuccess = false;
            bool doInsertLocation = false;
            q = null;
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
                        String.Format("INSERT INTO \"Location\" VALUES (null, '{0}', '{1}', '{2}')",
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
                    String.Format("INSERT INTO \"Question\" VALUES (null, '{0}', {1}, {2}, '{3}', {4})",
                    title, accountid, schedule, description, locID));
                //Retrieve question ID / post ID
                DataTable dtQuestion = Database_Layer.Database.RetrieveQuery(
                    String.Format("SELECT max(ID) FROM \"Question\" WHERE \"PosterACC_ID\" = '{0}'",
                    accountid));
                int qID = 0;
                //Set questionID
                foreach (DataRow row in dtQuestion.Rows)
                {
                    qID = Convert.ToInt32(row["ID"]);
                }

                q = new Question(qID, title, schedule, description, questionLocation);
                creationSuccess = true;
            }
            catch (Exception e)
            {

            }
            return creationSuccess;
        }

        public static bool FindQuestionPoster(int postID)
        {
            return false;
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
        }
    }
}

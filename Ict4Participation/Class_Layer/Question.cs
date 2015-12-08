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
            //TODO
            //insert into database
            return true;
        }

        /// <summary>
        /// Deletes this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Delete()
        {
            //Call database for delete query
            Database_Layer.Database.DeleteQuestion(this.PostID);
            return true;
        }

        /// <summary>
        /// Updates this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Update()
        {
            //TODO
            //Call database for update query
            return true;
        }

        public static List<Question> GetAll(Nullable<int> accountid)
        {
            //TODO
            //Call database, return list of questions matching the account
            //If accountID is null, get all questions of all users
            return null;
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

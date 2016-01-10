//-----------------------------------------------------------------------
// <copyright file="Meeting.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
namespace Class_Layer
{
    using System;
    using System.Collections.Generic;
    using System.Data;

    /// <summary>
    /// The <see cref="Meeting"/> class manages information about a meeting.
    /// </summary>
    public class Meeting : Post
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Meeting"/> class.
        /// </summary>
        /// <param name="id">The ID of the meeting.</param>
        /// <param name="requestedTo">The requested account ID of the meeting.</param>
        /// <param name="requester">The requester account ID of the meeting.</param>
        /// <param name="start">The start date of the meeting.</param>
        /// <param name="end">The end date of the meeting.</param>
        /// <param name="location">The location of the meeting.</param>
        public Meeting(int id, int requestedTo, int requester, DateTime? start, DateTime? end, string location)
            : base(id, requestedTo)
        {
            this.RequesterID = requester;
            this.StartDate = start;
            this.EndDate = end;
            this.Location = location;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the ID of the user who requested this meeting.
        /// </summary>
        /// <value>The ID of the user who requested this meeting.</value>
        public int RequesterID { get; private set; }

        /// <summary>
        /// Gets the start time of the meeting.
        /// </summary>
        /// <value>The start time of the meeting.</value>
        public DateTime? StartDate { get; private set; }

        /// <summary>
        /// Gets the end time of the meeting.
        /// </summary>
        /// <value>The end time of the meeting.</value>
        public DateTime? EndDate { get; private set; }

        /// <summary>
        /// Gets the creation date of the meeting.
        /// </summary>
        /// <value>The creation date of the meeting.</value>
        public DateTime CreationDate { get; private set; }

        /// <summary>
        /// Gets the location of the meeting.
        /// </summary>
        /// <value>The location of the meeting.</value>
        public string Location { get; private set; }

        /// <summary>
        /// Gets the details of the meeting.
        /// </summary>
        /// <value>The details of the meeting.</value>
        public string Details { get; private set; }
        #endregion

        #region Static Methods
        /// <summary>
        /// Retrieves all the meetings belonging to a specific or unspecified user from the database.
        /// </summary>
        /// <param name="userid">The userID of the specific user.</param>
        /// <returns>Returns a list of said meetings.</returns>
        public static List<Meeting> GetAll(int? userid = null)
        {
            List<Meeting> meetings = new List<Meeting>();
            string addquery = string.Empty;
            if (userid != null)
            {
                // Get all the user skills of specified user
                addquery = "WHERE \"RequesterACC_ID\"=" + userid + " OR \"RequestedACC_ID\"=" + userid;
            }

            // Else get all meetings if no ID is specified
            DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Meeting\" " + addquery);
            foreach (DataRow row in dt.Rows)
            {
                meetings.Add(new Meeting(
                        Convert.ToInt32(row["ID"]),
                        Convert.ToInt32(row["RequestedACC_ID"]),
                        Convert.ToInt32(row["RequesterACC_ID"]),
                        row["StartDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["StartDate"]),
                        row["EndDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["EndDate"]),
                        row["Location"].ToString()));
            }

            // Return a list with all the found meetings
            return meetings;
        }
        #endregion

        #region Non-Static Methods
        /// <summary>
        /// Creates this database entry.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the meeting has been successfully created or not.</returns>
        public override bool Create()
        {
            // Insert into database
            string st = Utility_Classes.ConvertTo.OracleDateTime(this.StartDate);
            string et = Utility_Classes.ConvertTo.OracleDateTime(this.EndDate);

            // Read PosterID as the requester, and RequesterID as the ID of the participant who was requested to join
            return Database_Layer.Database.InsertMeeting(this.PosterID, this.RequesterID, st, et, this.Location);
        }

        /// <summary>
        /// Deletes this database entry.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the meeting has been successfully deleted or not.</returns>
        public override bool Delete()
        {
            // Call database for delete query
            return Database_Layer.Database.DeleteMeeting(this.PostID);
        }

        /// <summary>
        /// Updates this database entry.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the the meeting has been successfully updated or not.</returns>
        public override bool Update()
        {
            string st = Utility_Classes.ConvertTo.OracleDateTime(this.StartDate);
            string et = Utility_Classes.ConvertTo.OracleDateTime(this.EndDate);

            // Call database for update query
            return Database_Layer.Database.UpdateMeeting(this.PostID, st, et, this.Location);
        }

        /// <summary>
        /// Method to return this object in string format.
        /// </summary>
        /// <returns>Returns this object in string format.</returns>
        public override string ToString()
        {
            return this.Details;
        }
        #endregion
    }
}

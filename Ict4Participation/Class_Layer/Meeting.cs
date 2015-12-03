//-----------------------------------------------------------------------
// <copyright file="Meeting.cs" company="ICT4Participation">
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
    /// Manages information about a meeting
    /// </summary>
    public class Meeting
    {
        /// <summary>
        /// Gets the ID of the meeting
        /// </summary>
        public int ID { get; private set; }
        /// <summary>
        /// Gets the ID of the user who requested this meeting
        /// </summary>
        public int RequesterID { get; private set; }
        /// <summary>
        /// Gets the ID of the user who was requested to be at this meeting
        /// </summary>
        public int RequestedID { get; private set; }
        /// <summary>
        /// Gets the start time of the meeting
        /// </summary>
        public Nullable<DateTime> StartDate { get; private set; }
        /// <summary>
        /// Gets the end time of the meeting
        /// </summary>
        public Nullable<DateTime> EndDate { get; private set; }
        /// <summary>
        /// Gets the creation date of the meeting
        /// </summary>
        public DateTime CreationDate { get; private set; }
        /// <summary>
        /// Gets the location of the meeting
        /// </summary>
        public string Location { get; private set; }
        /// <summary>
        /// Gets the details of the meeting
        /// </summary>
        public string Details { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Meeting"/> class.
        /// </summary>
        /// <param name="id">the ID of the meeting</param>
        /// <param name="beginTime">The begin time of the meeting</param>
        /// <param name="loc">The location of the meeting</param>
        private Meeting(string beginTime, string locatie, string username1, string username2)
        {
            //TODO
            //Fetch usernames
            //Set details to the following:
            //Op xxxxx is de volgende meeting ingepland:
            //Tijdstip: van xxxxxx tot xxxxxx
            //Locatie: xxxxxx
            //Uitgenodigden: xxxxxx met xxxxxx
        }

        #region Create meeting, database mostly

        /// <summary>
        /// Creates a meeting, where the datetime and locationID are given
        /// </summary>
        /// <param name="userIDmaker">the ID of the user who makes the meeting</param>
        /// <param name="userIDrequester">the ID of the user who joins the meeting</param>
        /// <param name="time">the time of the meeting</param>
        /// <param name="locID">the locationID of the location</param>
        /// <returns></returns>
        public static string Create(int userIDmaker, int userIDrequester, DateTime startTime, DateTime endTime, string location)
        {
            string st = Utility_Classes.ConvertTo.OracleDateTime(startTime);
            string et = Utility_Classes.ConvertTo.OracleDateTime(endTime);
            //TODO
            //Call database to insert new meeting
            return "";
        }
        #endregion

        /// <summary>
        /// Retrieves all the meetings belonging to a specific user from the database. Or unspecified
        /// </summary>
        /// <param name="userid">the userID of the specific user</param>
        /// <returns>Yields a list of said meetings</returns>
        public static List<Meeting> GetAllMeetings(Nullable<int> userid = null)
        {
            //TODO
            //Find all meetings if userID is null
            //Find user-specific meetings
            //Possibly make another constructor
            //Return a list with all the found meetings
            return null;
        }

        public override string ToString()
        {
            return Details;
        }
    }
}

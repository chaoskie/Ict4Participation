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
    public class Meeting : Post
    {
        /// <summary>
        /// Gets the ID of the user who requested this meeting
        /// </summary>
        public int RequesterID { get; private set; }
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

        public Meeting(int ID, int requestedTo, int requester, Nullable<DateTime> start, Nullable<DateTime> end, string location)
            : base(ID, requestedTo)
        {
            this.RequesterID = requester;
            this.StartDate = start;
            this.EndDate = end;
            this.Location = location;

            //TODO
            //Fetch usernames
            //Set details to the following:
            //Op xxxxx is de volgende meeting ingepland:
            //Tijdstip: van xxxxxx tot xxxxxx
            //Locatie: xxxxxx
            //Uitgenodigden: xxxxxx met xxxxxx
        }


        /// <summary>
        /// Creates this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Create()
        {
            //TODO
            //insert into database
            string st = Utility_Classes.ConvertTo.OracleDateTime(this.StartDate);
            string et = Utility_Classes.ConvertTo.OracleDateTime(this.EndDate);
            return true;
        }

        /// <summary>
        /// Deletes this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Delete()
        {
            //TODO
            //Call database for delete query
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

        /// <summary>
        /// Retrieves all the meetings belonging to a specific user from the database. Or unspecified
        /// </summary>
        /// <param name="userid">the userID of the specific user</param>
        /// <returns>Yields a list of said meetings</returns>
        public static List<Meeting> GetAll(Nullable<int> userid = null)
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

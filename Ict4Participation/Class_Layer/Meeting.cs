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
            //insert into database
            string st = Utility_Classes.ConvertTo.OracleDateTime(this.StartDate);
            string et = Utility_Classes.ConvertTo.OracleDateTime(this.EndDate);
            ///Read PosterID as the requester, and RequesterID as the ID of the participant who was requested to join
            return Database_Layer.Database.InsertMeeting(this.PosterID, this.RequesterID, st, et, this.Location);
        }

        /// <summary>
        /// Deletes this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Delete()
        {
            //Call database for delete query
            return Database_Layer.Database.DeleteMeeting(this.PostID);
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
            return Database_Layer.Database.UpdateMeeting(this.PostID, st, et, this.Location);
        }

        /// <summary>
        /// Retrieves all the meetings belonging to a specific user from the database. Or unspecified
        /// </summary>
        /// <param name="userid">the userID of the specific user</param>
        /// <returns>Yields a list of said meetings</returns>
        public static List<Meeting> GetAll(Nullable<int> userid = null)
        {

            List<Meeting> meetings = new List<Meeting>();
            string addquery = String.Empty;
            if (userid != null)//get all the user skills of specified user
            {
                addquery =  "WHERE \"RequesterAcc_ID\"=" + userid + " OR \"RequestedAccID\"=" + userid;
                //else get all meetings if no ID is specified
            }

            DataTable Dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Meeting\" " + addquery);
            foreach (DataRow row in Dt.Rows)
            {
                meetings.Add(
                    new Meeting(
                        Convert.ToInt32(row["ID"]),
                        Convert.ToInt32(row["RequestedAcc_ID"]),
                        Convert.ToInt32(row["RequesterAcc_ID"]),
                        Convert.ToDateTime(row["StartDate"]),
                        Convert.ToDateTime(row["EndDate"]),
                        row["Location"].ToString()
                        ));
            }
            //Return a list with all the found meetings
            return meetings;
        }

        public override string ToString()
        {
            return Details;
        }
    }
}

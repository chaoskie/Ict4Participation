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
        /// The ID of the meeting, as given by the database
        /// </summary>
        public int ID { get; private set; }

        /// <summary>
        /// Gets the begin time of the meeting
        /// </summary>
        public string BeginTime { get; private set; }

        /// <summary>
        /// Gets the location of the meeting
        /// </summary>
        public Location Loc { get; private set; }

        public string Details { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Meeting"/> class.
        /// </summary>
        /// <param name="id">the ID of the meeting</param>
        /// <param name="beginTime">The begin time of the meeting</param>
        /// <param name="loc">The location of the meeting</param>
        private Meeting(int id, string beginTime, Location loc, string username1, string username2)
        {
            string locinfo = loc.ToString();
            if (string.IsNullOrWhiteSpace(beginTime))
            {
                beginTime = "nog niet aangegeven";
            }

            if (loc.ToString() == " op 0 , 0")
            {
                locinfo = "nog niet aangegeven";
            }
            this.BeginTime = beginTime;
            this.Loc = loc;
            this.ID = id;
            this.Details = String.Format("Tijdstip: {0}Locatie: {1}Uitgenodigden: {2} met {3}", BeginTime + Environment.NewLine, locinfo + Environment.NewLine, username1, username2);
        }

        //TODO
        #region Create meeting, database mostly

        /// <summary>
        /// Creates a meeting, where the datetime and locationID are given
        /// </summary>
        /// <param name="userIDmaker">the ID of the user who makes the meeting</param>
        /// <param name="userIDrequester">the ID of the user who joins the meeting</param>
        /// <param name="time">the time of the meeting</param>
        /// <param name="locID">the locationID of the location</param>
        /// <returns></returns>
        public static string CreateMeeting(int userIDmaker, int userIDrequester, DateTime time, int locID)
        {
            string timetable = time.ToString("dd-MMM-yyyy HH:mm:s");
            Database_Layer.Database.InsertMeetingA(userIDmaker, userIDrequester, timetable, locID);
            return "Afspraak met tijd en locatie aangemaakt!";
        }

        /// <summary>
        /// Creates a meeting, where only the datetime is given
        /// </summary>
        /// <param name="userIDmaker">the ID of the user who makes the meeting</param>
        /// <param name="userIDrequester">the ID of the user who joins the meeting</param>
        /// <param name="time">the time of the meeting</param>
        /// <returns></returns>
        public static string CreateMeeting(int userIDmaker, int userIDrequester, DateTime time)
        {
            string timetable = time.ToString("dd-MMM-yyyy HH:mm:s");
            Database_Layer.Database.InsertMeetingA(userIDmaker, userIDrequester, timetable);
            return "Afspraak met tijd alleen aangemaakt!";
        }

        /// <summary>
        /// Creates a meeting, where only the locationID is given
        /// </summary>
        /// <param name="userIDmaker">the ID of the user who makes the meeting</param>
        /// <param name="userIDrequester">the ID of the user who joins the meeting</param>
        /// <param name="locID">the locationID of the location</param>
        /// <returns></returns>
        public static string CreateMeeting(int userIDmaker, int userIDrequester, int locID)
        {
            Database_Layer.Database.InsertMeetingA(userIDmaker, userIDrequester, locID);
            return "Afspraak met locatie alleen aangemaakt!";
        }

        /// <summary>
        /// Creates an empty meeting
        /// </summary>
        /// <param name="userIDmaker">the ID of the user who makes the meeting</param>
        /// <param name="userIDrequester">the ID of the user who joins the meeting</param>
        /// <returns></returns>
        public static string CreateMeeting(int userIDmaker, int userIDrequester)
        {
            Database_Layer.Database.InsertMeetingA(userIDmaker, userIDrequester);
            return "Afspraak aangemaakt!";
        }

        #endregion

        /// <summary>
        /// Retrieves all the meetings belonging to a specific user from the database. Or unspecified
        /// </summary>
        /// <param name="userid">the userID of the specific user</param>
        /// <returns>Yields a list of said meetings</returns>
        public static List<Meeting> GetAllMeetings(Nullable<int> userid = null)
        {
            string query = 
                "SELECT RequesterName, RequestedName, Timet, LocationID, MID FROM"
                + "(SELECT RequesterName, \"Name\" as RequestedName, rr, rd, Timet, LocationID, MID FROM ( "
                + "SELECT \"Name\" as RequesterName, ac.\"ID\", me.\"RequestedACC_ID\" as rd, me.\"RequesterACC_ID\" as rr, me.\"Timetable\" as Timet, me.location_id as LocationID, me.\"ID\" as MID FROM \"Acc\" ac "
                + "JOIN \"Meeting\" me "
                + "ON me.\"RequesterACC_ID\"=ac.\"ID\" "
                + ") tt "
                + "JOIN \"Acc\" ac "
                + "ON tt.rd=ac.\"ID\" "
                + ") ";
            if (userid != null)
            {
                query += "WHERE rr = " + userid + " OR rd = " + userid + " ";
            }
            List<Meeting> foundmeetings = new List<Meeting>();
            DataTable dt = Database_Layer.Database.RetrieveQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                var outputParam = row["LocationID"];
                int locID = 0;
                if(!(outputParam is DBNull))
                {locID = Convert.ToInt32(row["LocationID"]);}

                foundmeetings.Add(new Meeting(
                    Convert.ToInt32(row["MID"]),
                    row["Timet"].ToString(),
                    new Location(Convert.ToInt32(locID)),
                    row["RequesterName"].ToString(),
                    row["RequestedName"].ToString()
                    ));
            }
            return foundmeetings;
        }

        public override string ToString()
        {
            return Details;
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="Meeting.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
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
        /// Gets the begin time of the meeting
        /// </summary>
        public DateTime BeginTime { get; private set; }

        /// <summary>
        /// Gets the end time of the meeting
        /// </summary>
        public DateTime EndTime { get; private set; }

        /// <summary>
        /// Gets the location of the meeting
        /// </summary>
        public Location Loc { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Meeting"/> class.
        /// </summary>
        /// <param name="beginTime">The begin time of the meeting</param>
        /// <param name="endTime">The end time of the meeting</param>
        /// <param name="loc">The location of the meetinf</param>
        public Meeting(DateTime beginTime, DateTime endTime, Location loc)
        {
            this.BeginTime = beginTime;
            this.EndTime = endTime;
            this.Loc = loc;
        }
    }
}

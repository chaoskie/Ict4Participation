//-----------------------------------------------------------------------
// <copyright file="Question.cs" company="ICT4Participation">
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
        /// Initializes a new instance of the <see cref="Question"/> class.
        /// </summary>
        /// <param name="postID">The ID of the question</param>
        /// <param name="title">The title of the question</param>
        /// <param name="schedule">The scheduled time of the question</param>
        /// <param name="description">The description of the question</param>
        /// <param name="questionLocation">The location of the question</param>
        public Question(int postID, string title, DateTime schedule, string description, Location questionLocation)
            : base(postID, title)
        {
            this.Schedule = schedule;
            this.Description = description;
            this.Schedule = schedule;
        }
    }
}

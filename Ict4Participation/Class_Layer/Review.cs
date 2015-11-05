//-----------------------------------------------------------------------
// <copyright file="Review.cs" company="ICT4Participation">
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
    public class Review : Post
    {
        /// <summary>
        /// Gets the rating of the review
        /// </summary>
        public int Rating { get; private set; }

        /// <summary>
        /// Gets the accountID of the author
        /// </summary>
        public int AccountID { get; private set; }

        /// <summary>
        /// Gets the description of the review
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Review"/> class.
        /// </summary>
        /// <param name="postID">The ID of the review</param>
        /// <param name="title">The title of the review</param>
        /// <param name="rating">The rating of the review</param>
        /// <param name="accountID">The accountID of the author</param>
        /// <param name="description">The description of the review</param>
        public Review(int postID, string title, int rating, int accountID, string description)
            : base(postID, title)
        {
            this.Rating = rating;
            this.AccountID = accountID;
            this.Description = description;
        }

        public static List<string> GetUserReviews(int accountID, out List<Review> reviews)
        {
            reviews = new List<Review>();
            return null;
        }
    }
}

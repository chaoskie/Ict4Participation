//-----------------------------------------------------------------------
// <copyright file="Review.cs" company="ICT4Participation">
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
    /// The <see cref="Review"/> class is a subclass of the post class.
    /// </summary>
    public class Review : Post
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Review"/> class.
        /// </summary>
        /// <param name="postID">The ID of the review.</param>
        /// <param name="rating">The rating of the review.</param>
        /// <param name="posterID">The ID of the poster account.</param>
        /// <param name="postedtoID">The ID of the account the review is posted to.</param>
        /// <param name="description">The description of the review.</param>
        public Review(int postID, int rating, int posterID, int postedtoID, string description)
            : base(postID, posterID)
        {
            this.Rating = rating;
            this.PostedToID = postedtoID;
            this.Description = description;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the rating of the review.
        /// </summary>
        /// <value>The rating of the review.</value>
        public int Rating { get; private set; }

        /// <summary>
        /// Gets the accountID of the author.
        /// </summary>
        /// <value>The accountID of the author.</value>
        public int PostedToID { get; private set; }

        /// <summary>
        /// Gets the description of the review.
        /// </summary>
        /// <value>The description of the review.</value>
        public string Description { get; private set; }
        #endregion

        #region Static Methods
        /// <summary>
        /// Gets all reviews posted by or on a specified user.
        /// </summary>
        /// <param name="accountID">The ID of the user.</param>
        /// <param name="isPoster">Whether the user has posted, or received these reviews.</param>
        /// <returns>Returns a list of the reviews.</returns>
        public static List<Review> GetAll(int accountID, bool isPoster = false)
        {
            // Call database for a list of reviews about specified person
            List<Review> reviews = new List<Review>();
            string who = string.Empty;
            who = isPoster ? "PosterACC_ID" : "PostedACC_ID";
            DataTable dt_Review = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Review\" WHERE \"" + who + "\" = " + accountID);

            foreach (DataRow row in dt_Review.Rows)
            {
                reviews.Add(new Review(
                    Convert.ToInt32(row["ID"]),
                    Convert.ToInt32(row["Rating"]),
                    Convert.ToInt32(row["PosterACC_ID"]),
                    Convert.ToInt32(row["PostedACC_ID"]),
                    row["Description"].ToString()));
            }

            return reviews;
        }
        #endregion

        #region Non-Static Methods
        /// <summary>
        /// Creates this database entry.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the review has been successfully created or not.</returns>
        public override bool Create()
        {
            //// Insert into database
            return Database_Layer.Database.InsertReview(this.Rating, this.PostedToID, this.PosterID, this.Description);
        }

        /// <summary>
        /// Deletes this database entry.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the review has been successfully deleted or not.</returns>
        public override bool Delete()
        {
            // Call database for delete query
            return Database_Layer.Database.DeleteReview(this.PostID);
        }

        /// <summary>
        /// Updates this database entry.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the review has been successfully deleted or not.</returns>
        public override bool Update()
        {
            // Call database for update query
            return Database_Layer.Database.UpdateReview(this.PostID, this.Rating, this.Description);
        }
        #endregion
    }
}

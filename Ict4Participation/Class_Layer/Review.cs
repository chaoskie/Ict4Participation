//-----------------------------------------------------------------------
// <copyright file="Review.cs" company="ICT4Participation">
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
        public int PosterID { get; private set; }

        /// <summary>
        /// Gets the accountID of the author
        /// </summary>
        public int PostedToID { get; private set; }

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
        private Review(int postID, string title, int rating, int posterID, int postedtoID, string description)
            : base(postID, title)
        {
            this.Rating = rating;
            this.PosterID = posterID;
            this.PostedToID = postedtoID;
            this.Description = description;
        }

        /// <summary>
        /// Adds a new review about a specified user to the database
        /// </summary>
        /// <param name="rating">The rating of the review</param>
        /// <param name="title">The title of the review</param>
        /// <param name="postedtoID">The ID of the reviewed</param>
        /// <param name="posterID">The ID of the reviewer</param>
        /// <param name="description">The description of the review</param>
        /// <returns>String containing information about the review placement</returns>
        public static string PlaceReview(int rating, string title, int postedtoID, int posterID, string description)
        {
            Database_Layer.Database.InsertReview(rating, title, postedtoID, posterID, description);
            return String.Format("{0}-sterren review geplaatst!", rating);
        }

        /// <summary>
        /// Yields all the reviews from the database, matching the user ID
        /// </summary>
        /// <param name="accountID">The ID of the user as stated in the database</param>
        /// <param name="reviews">The reviews about this user</param>
        /// <returns>A list containing the description of all these reviews</returns>
        public static List<string> GetUserReviews(int accountID, out List<Review> reviews, bool isPoster = false)
        {
            reviews = new List<Review>();
            string who = string.Empty;
            who = isPoster ? "PosterACC_ID" : "PostedACC_ID";
            DataTable dtReview = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Review\" WHERE \"" + who + "\" = " + accountID);
            foreach (DataRow row in dtReview.Rows)
            {
                reviews.Add(new Review(
                    Convert.ToInt32(row["ID"]),
                    row["Title"].ToString(),
                    Convert.ToInt32(row["Rating"]),
                    Convert.ToInt32(row["PosterACC_ID"]),
                    Convert.ToInt32(row["PostedACC_ID"]),
                    row["Description"].ToString()
                    ));
            }

            List<string> reviewdetails = new List<string>();
            foreach (Review r in reviews)
            {
                reviewdetails.Add(r.Rating + " " + r.Title);
            }
            return reviewdetails;
        }

        /// <summary>
        /// Yields all the reviews from the database
        /// </summary>
        /// <param name="reviews">All of them!</param>
        /// <returns>ALL THE REVIEWS</returns>
        public static List<string> GetAllUserReviews(out List<Review> reviews)
        {
            reviews = new List<Review>();
            DataTable dtReview = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Review\"");
            foreach (DataRow row in dtReview.Rows)
            {
                reviews.Add(new Review(
                    Convert.ToInt32(row["ID"]),
                    row["Title"].ToString(),
                    Convert.ToInt32(row["Rating"]),
                    Convert.ToInt32(row["PosterACC_ID"]),
                    Convert.ToInt32(row["PostedACC_ID"]),
                    row["Description"].ToString()
                    ));
            }

            List<string> reviewdetails = new List<string>();
            foreach (Review r in reviews)
            {
                reviewdetails.Add(r.Rating + " " + r.Title);
            }
            return reviewdetails;
        }
    }
}

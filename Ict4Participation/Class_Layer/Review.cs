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
        public int PostedToID { get; private set; }

        /// <summary>
        /// Gets the description of the review
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Initialises a new instance of the Review class
        /// </summary>
        /// <param name="postID"></param>
        /// <param name="rating"></param>
        /// <param name="posterID"></param>
        /// <param name="postedtoID"></param>
        /// <param name="description"></param>
        public Review(int postID, int rating, int posterID, int postedtoID, string description)
            : base(postID, posterID)
        {
            this.Rating = rating;
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
        public static string Place(int rating, int postedtoID, int posterID, string description)
        {
            //TODO
            //Call database to post a new review
            //  Database_Layer.Database.InsertReview(rating, postedtoID, posterID, description);
            return String.Format("{0}-sterren review geplaatst!", rating);
        }
        /// <summary>
        /// deletes the given review entry
        /// </summary>
        /// <param name="ID">id of the given review</param>
        public static void Delete(int ID)
        {
            Database_Layer.Database.DeleteReview(ID);
        }

        /// <summary>
        /// Updates the desired review
        /// </summary>
        /// <param name="postID">The ID of the review</param>
        /// <param name="rating">The new rating of the review</param>
        /// <param name="desc">The new description of the review</param>
        public static void Update(int postID, int rating, string desc)
        {
            //TODO
            //Call database to update the review
            //  Database_Layer.Database.UpdateReview(postID, rating, desc);
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
                reviews.Add(Create(row));
            }
            return GetDetails(reviews);
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
                reviews.Add(Create(row));
            }
            return GetDetails(reviews);
        }

        /// <summary>
        /// Creates a review from the data of a datarow
        /// </summary>
        /// <param name="row">The datarow to process</param>
        /// <returns>The review filled with information in the datarow</returns>
        private static Review Create(DataRow row)
        {
            return new Review(
                    Convert.ToInt32(row["ID"]),
                    Convert.ToInt32(row["Rating"]),
                    Convert.ToInt32(row["PosterACC_ID"]),
                    Convert.ToInt32(row["PostedACC_ID"]),
                    row["Description"].ToString()
                );
        }

        /// <summary>
        /// Gets the details of a list of reviews
        /// </summary>
        /// <param name="reviews">the reviews</param>
        /// <returns>Yields the detailed information</returns>
        private static List<string> GetDetails(List<Review> reviews)
        {
            List<string> reviewdetails = new List<string>();
            foreach (Review r in reviews)
            {
                reviewdetails.Add(String.Format("{0}-Sterren: {1} \n{2}", r.Rating, r.Description));
            }
            return reviewdetails;
        }
    }
}

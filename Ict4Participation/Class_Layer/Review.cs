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
        /// Creates this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Create()
        {
            //insert into database
            return Database_Layer.Database.InsertReview(this.Rating, this.PostedToID, this.PosterID, this.Description);
        }

        /// <summary>
        /// Deletes this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Delete()
        {
            //Call database for delete query
            return Database_Layer.Database.DeleteReview(this.PostID);
        }

        /// <summary>
        /// Updates this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Update()
        {
            //Call database for update query
            return Database_Layer.Database.UpdateReview(this.PostID, this.Rating, this.Description);
        }

        /// <summary>
        /// Gets all reviews posted by or on a specified user
        /// </summary>
        /// <param name="accountID">the ID of the user</param>
        /// <param name="isPoster">Whether the user has posted, or received these reviews</param>
        /// <returns>A list of the reviews</returns>
        public static List<Review> GetAll(int accountID, bool isPoster = false)
        {
            //Call database for a list of reviews about specified person
            List<Review> reviews = new List<Review>();
            string who = string.Empty;
            who = isPoster ? "PosterACC_ID" : "PostedACC_ID";
            DataTable dtReview = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Review\" WHERE \"" + who + "\" = " + accountID);
            foreach (DataRow row in dtReview.Rows)
            {
                reviews.Add(new Review(
                    Convert.ToInt32(row["ID"]),
                    Convert.ToInt32(row["Rating"]),
                    Convert.ToInt32(row["PosterACC_ID"]),
                    Convert.ToInt32(row["PostedACC_ID"]),
                    row["Description"].ToString()
                ));
            }
            return reviews;
        }
    }
}

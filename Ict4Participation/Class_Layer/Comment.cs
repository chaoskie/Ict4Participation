//-----------------------------------------------------------------------
// <copyright file="Comment.cs" company="ICT4Participation">
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
    public class Comment : Post
    {
        /// <summary>
        /// Gets the accountID of the author
        /// </summary>
        public int PostedToID { get; private set; }
        /// <summary>
        /// Gets the description of this comment
        /// </summary>
        public string Description { get; private set; }
        /// <summary>
        /// Gets the posted date of this comment
        /// </summary>
        public DateTime PostDate { get; private set; }

        /// <summary>
        /// Creates this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Create()
        {
            //insert into database
            Database_Layer.Database.InsertComment(this.PosterID, this.PostedToID, this.Description);
            return true;
        }

        /// <summary>
        /// Deletes this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Delete()
        {
            //Call database for delete query
            Database_Layer.Database.DeleteComment(this.PostID, true);
            return true;
        }

        /// <summary>
        /// Updates this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Update()
        {
            //Call database for update query
            Database_Layer.Database.UpdateComment(this.PostID, this.Description);
            return true;
        }

        /// <summary>
        /// Gets all the comments belonging to a question
        /// </summary>
        /// <param name="questionID"></param>
        /// <returns>A list of the comments to this questionID</returns>
        public static List<Comment> GetAll(int questionID)
        {
            List<Comment> comments = new List<Comment>();
            //Load in comment from questions
            DataTable Dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Comment\" WHERE \"QUESTION_ID\" = " + questionID);
            foreach (DataRow row in Dt.Rows)
            {
                comments.Add(
                    new Comment(
                        Convert.ToInt32(row["ID"]),
                        row["Description"].ToString(),
                        Convert.ToInt32(row["PosterAcc_ID"]),
                        questionID,
                        Convert.ToDateTime(row["PostDate"])
                        ));
            }
            return comments;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class.
        /// </summary>
        public Comment(int postID, string desc, int posterID, int postedToID, DateTime postDate)
            : base(postID, posterID)
        {
            this.PostedToID = postedToID;
            this.PostDate = postDate;
            this.Description = desc;
            //nothing much
        }
    }
}

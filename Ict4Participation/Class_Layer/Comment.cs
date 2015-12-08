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
            Database_Layer.Database.PlaceComment(this.PosterID, this.PostedToID, this.Description);
            return true;
        }

        /// <summary>
        /// Deletes this database entry
        /// </summary>
        /// <returns>Success</returns>
        public override bool Delete()
        {
            //Call database for delete query
            Database_Layer.Database.RemoveComment(this.PostID, true);
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
            //TODO
            return null;
        }

        /// <summary>
        /// Finds the user(name) of the posted comment
        /// </summary>
        /// <param name="postid">THe comment post id</param>
        /// <returns>The name of the user</returns>
        public static List<string> GetQuestionComments(int postID, out List<Comment> Comments)
        {
            //Create comment objects
            Comments = new List<Comment>();
            //Create comment details
            List<string> commentstr = new List<string>();
            //Fetch comments
            DataTable dt = Database_Layer.Database.RetrieveQuery(
            "SELECT * FROM "
            + "(SELECT c.\"ID\" as CID, c.\"QUESTION_ID\" as QID, c.\"Description\" as Post, a.\"Name\" as Poster, c.\"PostDate\" as timet, \"PosterACC_ID\" as PosterID FROM \"Comment\" c "
            + "JOIN \"Acc\" a "
            + "ON a.\"ID\"=c.\"PosterACC_ID\") "
            + "WHERE QID = " + postID + "ORDER BY timet");
            foreach (DataRow row in dt.Rows)
            {
                //Create comments
                commentstr.Add(String.Format("{0}: {1}", row["Poster"].ToString(), row["Post"].ToString()));
                Comments.Add(new Comment(
                   Convert.ToInt32(row["CID"]),
                   row["Post"].ToString(),
                   Convert.ToInt32(row["PosterID"]),
                   Convert.ToInt32(row["QID"]),
                   Convert.ToDateTime(row["timet"])
                   ));
            }
            return commentstr;
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

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
        /// Creates a new comment to be inserted into the database
        /// </summary>
        /// <param name="accountID">The OP</param>
        /// <param name="questionID">The Question ID</param>
        /// <param name="title">The comment</param>
        public static void PlaceComment(int accountID, int questionID, string Desc)
        {
            //insert into database
            Database_Layer.Database.PlaceComment(accountID, questionID, Desc);
        }

        /// <summary>
        /// Deletes the comment with the specified ID
        /// </summary>
        /// <param name="id">The ID of the comment</param>
        public static void DeleteComment(int id)
        {
            //Call database for delete query
            Database_Layer.Database.RemoveComment(id);
        }

        /// <summary>
        /// Updates the comment with the specified ID to the specified string
        /// </summary>
        /// <param name="id">The ID of the comment</param>
        /// <param name="text">The soon to be text of the comment</param>
        public static void EditComment(int id, string text)
        {
            //Call database for update query
            Database_Layer.Database.UpdateComment(id, text);
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
            + "(SELECT c.\"ID\" as CID, c.\"QUESTION_ID\" as QID, c.\"Description\" as Post, a.\"Name\" as Poster, c.\"POSTDATE\" as timet FROM \"Comment\" c "
            + "JOIN \"Acc\" a "
            + "ON a.\"ID\"=c.\"PosterACC_ID\") "
            + "WHERE QID = " + postID + "ORDER BY timet");
            foreach (DataRow row in dt.Rows)
            {
                //Create comments
                commentstr.Add(String.Format("{0}: {1}", row["Poster"].ToString(), row["Post"].ToString()));
                Comments.Add(new Comment(
                   Convert.ToInt32(row["CID"]),
                   row["Post"].ToString()
                   ));
            }
            return commentstr;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class.
        /// </summary>
        private Comment(int postID, string title)
            : base(postID, title)
        {
            //nothing much
        }
    }
}

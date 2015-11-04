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
        public static void PlaceComment(int accountID, int questionID, string title)
        {
            //insert into database
            Database_Layer.Database.ExecuteQuery(String.Format("INSERT INTO \"Comment\" (\"PosterACC_ID\", \"QUESTION_ID\", \"Description\") VALUES ({0}, {1}, '{2}')"
                , accountID, questionID, title));
        }

        /// <summary>
        /// Retrieves a list of comments matching the question
        /// </summary>
        /// <param name="postID">The question post ID</param>
        /// <param name="Comments">The comments objects which are created</param>
        /// <returns>A single line of a comment</returns>
        public static List<string> GetQuestionComments(int postID, out List<Comment> Comments)
        {
            Comments = new List<Comment>();
            List<string> commentinfo = new List<string>();
            //retrieve every comment matching to that question
            DataTable dtComment = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Comment\" WHERE \"QUESTION_ID\" = " + postID + " ORDER BY \"ID\"");
            foreach (DataRow row in dtComment.Rows)
            {
                Comments.Add(new Comment(
                    Convert.ToInt32(row["ID"]),
                    row["Description"].ToString()
                    ));
            }
            foreach (Comment c in Comments)
            {
                //(addrange in geval van aanpassing onder))
                commentinfo.Add(c.GetFullComment(c.PostID));
            }
            return commentinfo;
        }

        /// <summary>
        /// Finds the user(name) of the posted comment
        /// </summary>
        /// <param name="postid">THe comment post id</param>
        /// <returns>The name of the user</returns>
        public static string GetOP(int postid)
        {
            //
            // VERANDER DEZE NAAR EEN MOGELIJK JOIN
            // EN MAAK HIERVAN EEN LIST
            //
            string name = String.Empty;
            DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc\" WHERE \"ID\" = (SELECT \"PosterACC_ID\" FROM \"Comment\" WHERE \"ID\" = " + postid + ")");
            foreach (DataRow row in dt.Rows)
            {
                name = row["Name"].ToString();
            }
            return name;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Comment"/> class.
        /// </summary>
        private Comment(int postID, string title)
            : base(postID, title)
        {
            //nothing much
        }

        /// <summary>
        /// Yields the entire comment in format
        /// </summary>
        /// <param name="postid"></param>
        /// <returns>The comment</returns>
        public string GetFullComment(int postid)
        {
            return String.Format("{0}: {1}", GetOP(postid), Title);
        }
    }
}

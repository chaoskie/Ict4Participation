//-----------------------------------------------------------------------
// <copyright file="Post.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
namespace Class_Layer
{
    using Interfaces;

    /// <summary>
    /// The <see cref="Post"/> class is an abstract class to hold the subclasses of post.
    /// </summary>
    public abstract class Post : IPost
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Post"/> class.
        /// </summary>
        /// <param name="postID">The ID of the post.</param>
        /// <param name="posterID">The poster ID of the post.</param>
        public Post(int postID, int posterID)
        {
            this.PostID = postID;
            this.PosterID = posterID;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the ID of the post.
        /// </summary>
        /// <value>The ID of the post.</value>
        public int PostID { get; private set; }

        /// <summary>
        /// Gets the account ID of the author.
        /// </summary>
        /// <value>The account ID of the author.</value>
        public int PosterID { get; private set; }
        #endregion

        #region Non-Static Methods
        /// <summary>
        /// Creates a post and uploads it to the database.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the post has been successfully created or not.</returns>
        public abstract bool Create();

        /// <summary>
        /// Deletes a post from the database.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the post has been successfully deleted or not.</returns>
        public abstract bool Delete();

        /// <summary>
        /// Updates a post from the database.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the post has been successfully updated or not.</returns>
        public abstract bool Update();
        #endregion
    }
}

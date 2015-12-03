//-----------------------------------------------------------------------
// <copyright file="Post.cs" company="ICT4Participation">
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
    /// Abstract class to hold the subclasses of post
    /// </summary>
    public abstract class Post
    {
        /// <summary>
        /// Gets the ID of the post
        /// </summary>
        public int PostID { get; private set; }
        /// <summary>
        /// 
        /// Gets the accountID of the author
        /// </summary>
        public int PosterID { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Post"/> class.
        /// </summary>
        /// <param name="postID">The ID of the post</param>
        /// <param name="title">The title of the post</param>
        public Post(int postID, int posterID)
        {
            this.PostID = postID;
            this.PosterID = posterID;
        }
    }
}

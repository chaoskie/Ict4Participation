//-----------------------------------------------------------------------
// <copyright file="Accounttype.cs" company="ICT4Participation">
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
    /// Different kinds of account types
    /// </summary>
    public enum Accounttype
    {
        /// <summary>
        /// Administrator, has the most rights
        /// </summary>
        Administrator,

        /// <summary>
        /// Hulpbehoevende, may post posts and reviews
        /// </summary>
        Hulpbehoevende,

        /// <summary>
        /// Hulpverlener, may view posts and review, and may chat
        /// </summary>
        Hulpverlener
    }
}

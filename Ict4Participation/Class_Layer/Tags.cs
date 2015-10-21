//-----------------------------------------------------------------------
// <copyright file="Tags.cs" company="ICT4Participation">
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
    /// Skills a user can have
    /// </summary>
    public enum Tags  //TODO ADD DESCRIPTION PROPERTIES
    {
        /// <summary>
        /// The user has a car
        /// </summary>
        Auto,

        /// <summary>
        /// The user has a drivers license
        /// </summary>
        Rijbewijs,

        /// <summary>
        /// The user is muscular
        /// </summary>
        Getraind,

        /// <summary>
        /// The user has long endurance
        /// </summary>
        Goede_conditie,

        /// <summary>
        /// The user knows alot about tech
        /// </summary>
        Technisch,

        /// <summary>
        /// The user is socialable
        /// </summary>
        Spraakzaam
    }
}

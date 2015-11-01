//-----------------------------------------------------------------------
// <copyright file="Accounttype.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Layer
{
    /// <summary>
    /// Different kinds of account types
    /// </summary>
    public enum Accounttype
    {   /*
        [Description("Administrator, this user has the most rights")]
        Administrator,*/
        [Description("Hulpbehoevende, this user may post posts and reviews")]
        Hulpbehoevende,
        [Description("Hulpverlener, this user may view posts and reviews")]
        Hulpverlener,
        [Description("Administrator, this user may unleash hell upon all the users")]
        Administrator
    }
}

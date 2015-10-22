//-----------------------------------------------------------------------
// <copyright file="Tags.cs" company="ICT4Participation">
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
    /// Skills a user can have
    /// </summary>
    public enum Tags  //TODO ADD DESCRIPTION PROPERTIES
    {
        [Description("The user has a car")]
        Auto,
        [Description("The user has a drivers license")]
        Rijbewijs,
        [Description("The user is muscular")]
        Getraind,
        [Description("The user has a long endurance")]
        Goede_conditie,
        [Description("The user knows a lot about technology")]
        Technisch,
        [Description("The user is sociable")]
        Spraakzaam
    }
}

//-----------------------------------------------------------------------
// <copyright file="Location.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Class_Layer
{    
    /// <summary>
    /// Location in a PointF format or in string format
    /// </summary>
    public class Location
    {
        #region Properties
        /// <summary>
        /// Gets the precise location in PointF format
        /// </summary>
        private PointF PreciseLocation;

        public string Long
        {
            get { return PreciseLocation.X.ToString().Replace(',','.'); }
        }
        public string Lat
        {
            get { return PreciseLocation.Y.ToString().Replace(',','.'); }
        }

        /// <summary>
        /// Gets the described location in string format
        /// </summary>
        public string DescribedLocation { get; private set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="preciseLocation">The precise location</param>
        public Location(PointF preciseLocation)
        {
            this.PreciseLocation = preciseLocation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="describedLocation">The described location</param>
        public Location(string describedLocation)
        {
            this.DescribedLocation = describedLocation;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="preciseLocation">The precise location</param>
        /// <param name="describedLocation">The described location</param>
        public Location(PointF preciseLocation, string describedLocation)
        {
            this.PreciseLocation = preciseLocation;
            this.DescribedLocation = describedLocation;
        }
        #endregion

        public override string ToString()
        {
            return String.Format("{0} op {1} , {2}", DescribedLocation, PreciseLocation.X, PreciseLocation.Y);
        }
    }
}
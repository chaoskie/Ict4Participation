//-----------------------------------------------------------------------
// <copyright file="Location.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Data;
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
            get { return PreciseLocation.X.ToString().Replace(',', '.'); }
        }
        public string Lat
        {
            get { return PreciseLocation.Y.ToString().Replace(',', '.'); }
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

        /// <summary>
        /// Initializes a new instance of the Location class through the ID
        /// </summary>
        /// <param name="LocationID">The ID of the location</param>
        public Location(int LocationID)
        {
            DataTable dtLocation = Database_Layer.Database.RetrieveQuery(
                      String.Format("SELECT * FROM \"Location\" WHERE \"ID\" = '{0}'", LocationID));
            foreach (DataRow rowLoc in dtLocation.Rows)
            {
                this.PreciseLocation = new PointF(
                    (float)(Convert.ToDecimal(rowLoc["Longitude"])),
                    (float)(Convert.ToDecimal(rowLoc["Latitude"]))
                    );
                this.DescribedLocation = rowLoc["Description"].ToString();
            }
        }
        #endregion

        /// <summary>
        /// Validates if the location already exists in the database
        /// </summary>
        /// <param name="l">The location to be validated</param>
        /// <returns>Whether it exists or not</returns>
        public static bool ValidateLocation(Location l, out int locID)
        {
            bool exists = false;
            locID = 0;
            DataTable dtLocation = Database_Layer.Database.RetrieveQuery(
                       String.Format("SELECT ID FROM \"Location\" WHERE \"Longitude\" = '{0}' AND \"Latitude\" = '{1}' AND \"Description\" = '{2}'",
                       l.Long, l.Lat, l.DescribedLocation));
            exists = dtLocation.Rows.Count == 0 ? false : true;
            foreach (DataRow row in dtLocation.Rows)
            {
                locID = Convert.ToInt32(row["ID"]);
            }
            return exists;
        }

        /// <summary>
        /// Inserts the location into the database, and returns the ID of the newly inserted location
        /// </summary>
        /// <param name="l">The location which needs to be added</param>
        /// <returns>an int, regarding the ID of the location</returns>
        public static int InsertLocation(Location l)
        {
            int locID = 0;

            //Insert the location into the database
            Database_Layer.Database.InsertLocation(l.Long, l.Lat, l.DescribedLocation);
            //Retrieve location ID of the newly inserted location
            DataTable dtLocation = Database_Layer.Database.GetLocation(l.Long, l.Lat, l.DescribedLocation);

            foreach (DataRow row in dtLocation.Rows)
            {
                locID = Convert.ToInt32(row["ID"]);
            }
            return locID;
        }

        public override string ToString()
        {
            return String.Format("{0} op {1} , {2}", DescribedLocation, PreciseLocation.X, PreciseLocation.Y);
        }
    }
}
//-----------------------------------------------------------------------
// <copyright file="Account.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Database_Layer;

namespace Class_Layer
{

    /// <summary>
    /// Account class which represents a user
    /// </summary>
    public class Account
    {
        /// <summary>
        /// Gets the ID of the user
        /// </summary>
        public int AccountID { get; private set; }

        /// <summary>
        /// Gets the name of the user
        /// </summary>
        public string Naam { get; private set; }

        /// <summary>
        /// Gets the location of the user
        /// </summary>
        public Location Loc { get; private set; }

        /// <summary>
        /// Gets the role of the user
        /// </summary>
        public Accounttype Role { get; private set; }

        /// <summary>
        /// Gets the path of the avatar of the user
        /// </summary>
        public string AvatarPath { get; private set; }

        /// <summary>
        /// Gets the path of the VOG document
        /// </summary>
        public string VOGPath { get; private set; }

        /// <summary>
        /// Gets information about the user
        /// </summary>
        public string Information { get; private set; }

        /// <summary>
        /// Gets the sex (male/female) of the user
        /// </summary>
        public string Sex { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Account"/> class.
        /// </summary>
        /// <param name="accountID">The ID of the user</param>
        /// <param name="name">The name of the user</param>
        /// <param name="loc">The location of the user</param>
        /// <param name="role">The role of the user</param>
        /// <param name="avatarPath">The path of the avatar of the user</param>
        /// <param name="information">Information about the user</param>
        /// <param name="sex">The sex (male/female) of the user</param>
        /// <param name="vogPath">The path of the VOG document</param>
        public Account(int accountID, string name, Location loc, Accounttype role, string avatarPath, string information, string sex, string vogPath = "")
        {
            this.AccountID = accountID;
            this.Naam = name;
            this.Loc = loc;
            this.Role = role;
            this.AvatarPath = avatarPath;
            this.Information = information;
            this.Sex = sex;

            if (Role == Accounttype.Hulpverlener)
            {
                this.VOGPath = vogPath;
            }
        }

        /// <summary>
        /// Edit the user's information
        /// </summary>
        /// <param name="accountID">The ID of the user</param>
        /// <param name="name">The name of the user</param>
        /// <param name="loc">The location of the user</param>
        /// <param name="role">The role of the user</param>
        /// <param name="avatarPath">The path of the avatar of the user</param>
        /// <param name="information">Information about the user</param>
        /// <param name="sex">The sex (male/female) of the user</param>
        /// <param name="vogPath">The path of the VOG document</param>
        public void EditAccount(int accountID, string name, Location loc, Accounttype role, string avatarPath, string information, string sex, string vogPath)
        {
            this.AccountID = accountID;
            this.Naam = name;
            this.Loc = loc;
            this.Role = role;
            this.AvatarPath = avatarPath;
            this.Information = information;
            this.Sex = sex;
            this.VOGPath = vogPath;
        }

        //testmethode voor database
        static public void testdatabase()
        {
            Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc\"");
        }
    }
}

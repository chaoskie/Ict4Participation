﻿//-----------------------------------------------------------------------
// <copyright file="Account.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        #region properties
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
        /// Gets the email of the user
        /// </summary>
        public string Email { get; private set; }

        /// Gets information about the user
        /// </summary>
        public string Information { get; private set; }

        /// <summary>
        /// Gets the sex (male/female) of the user
        /// </summary>
        public string Sex { get; private set; }
        #endregion

        public static Account Register(string name, Location loc, string password, string avatarPath, string VOG, string description, Accounttype role, string sex, string email, out int id)
        {
            //TODO
            //Returns: Account to set as MainUser in the admin class
            //Outs: the ID of the newly created account
            //Insert into the database
            //Retrieve the exact same stuff from the database, fetch the ID
            //Out the ID
            string passTotal = PasswordHashing.CreateHash(password);
            string[] passArray = passTotal.Split(':');

            // Second string in array is the salt
            string passSalt = passArray[0] + ":";
            // Third string in the array is the hash
            string passHash = passArray[1] + ":" + passArray[2];
            int locID =0;
            Location.ValidateLocation(loc, out locID);

            string roleText = string.Empty;
            
            //V = hulpverlener B = administrator H = hulpbehoevende
            switch(role) {
                case Accounttype.Administrator:
                    roleText = "B";
                    break;
                case Accounttype.Hulpbehoevende:
                    roleText = "H";
                    break;
                case Accounttype.Hulpverlener:
                    roleText = "V";
                    break;
            }

            string query1 = "INSERT INTO \"Acc\" (\"Name\", \"LOCATION_ID\", \"PassHash\", \"Salt\", \"Avatar\", \"VOG\", \"Description\", \"Role\", \"Sex\", \"Email\") VALUES(" +
                "'" + name + "'" + ", " + locID + ", " + "'" + passHash + "'" + ", " + "'" + passSalt + "'" + ", " + "'" + avatarPath + "'" + ", " + "'" + VOG + "'" + ", " + 
                "'" + description + "'" + ", " + "'" + roleText + "'" + ", " + "'" + sex + "'" + ", " + "'" + email + "'" + ")";

            string query2 = "SELECT ID FROM \"Acc\" WHERE \"Name\" = " + name + " AND \"LOCATION_ID\" = " + locID + " AND \"PassHash\" = " + passHash + " AND \"Salt\" = " + passSalt + " AND \"Avatar\" = " +
                avatarPath + " AND \"VOG\" = " + VOG + " AND \"Description\" = " + description + " AND \"Role\" = " + role + " AND \"Sex\" = " + sex + " AND \"Email\" = " + email;

            Database.ExecuteQuery(query1);
            DataTable dt = Database.RetrieveQuery(query2);

            id = 0;
            return null;
        }

        /// <summary>
        /// Creates the main user account
        /// </summary>
        /// <param name="username">the username / id of the account</param>
        /// <param name="password">the password of the matching account</param>
        /// <param name="acc">the account with all the details</param>
        /// <returns>whether acc is null or not</returns>
        public static bool CreateMainAccount(string username, string password, out Account acc)
        {
            //By default, there is no user found, and no user will be given
            bool matchingaccount = false;
            acc = null;
            //Find username in database
            DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc\" WHERE \"ID\" = " + username);

            //Check if there's a username with this password
            foreach (DataRow row in dt.Rows)
            {
                //If exists && matches
                if (PasswordHashing.ValidatePassword(password, (row["Salt"].ToString() + row["PassHash"].ToString())))
                {
                    #region Find account credentials, fill in account information
                    matchingaccount = true;
                    //Find location
                    Location loc = null;
                    DataTable dtLoc = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Location\" WHERE \"ID\" = " + row["LOCATION_ID"]);
                    foreach (DataRow locRow in dtLoc.Rows)
                    {
                        loc = new Location(new PointF(
                            (float)(Convert.ToDecimal(locRow["Longitude"])),
                            (float)(Convert.ToDecimal(locRow["Latitude"]))),
                            locRow["Description"].ToString());
                    }
                    //Cast role 
                    Accounttype t;
                    if (row["Role"].ToString() != "B")
                    {
                        t = row["Role"].ToString() == "H" ? Accounttype.Hulpbehoevende : Accounttype.Hulpverlener;
                    }
                    else
                        t = Accounttype.Administrator;

                    //Create account
                    acc = new Account(Convert.ToInt32(row["ID"]),
                        row["Name"].ToString(),
                        loc,
                        t,
                        row["Avatar"].ToString(),
                        row["Description"].ToString(),
                        row["Sex"].ToString(),
                        row["Email"].ToString(),
                        row["VOG"].ToString()
                        );
                    #endregion

                    break;
                }
            }
            return matchingaccount;
        }

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
        private Account(int accountID, string name, Location loc, Accounttype role, string avatarPath, string information, string sex, string email, string vogPath = "")
        {
            this.AccountID = accountID;
            this.Naam = name;
            this.Loc = loc;
            this.Role = role;
            this.AvatarPath = avatarPath;
            this.Information = information;
            this.Sex = sex;
            this.Email = email;

            if (Role == Accounttype.Hulpverlener)
            {
                this.VOGPath = vogPath;
            }
        }

        //testmethode voor database
        static public bool testdatabase()
        {
            if (Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc\"") == null)
                return false;
            else return true;
        }
    }
}

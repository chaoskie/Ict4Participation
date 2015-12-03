//-----------------------------------------------------------------------
// <copyright file="Account.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------

namespace Class_Layer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Database_Layer;
    using Enums;

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

        /// <summary>
        /// Gets information about the user
        /// </summary>
        public string Information { get; private set; }

        /// <summary>
        /// Gets the sex (male/female) of the user
        /// </summary>
        public string Sex { get; private set; }
        #endregion

        /// <summary>
        /// Register an account
        /// </summary>
        /// <param name="name">The name of the new user</param>
        /// <param name="loc">The location of the new user</param>
        /// <param name="password">The password of the new user</param>
        /// <param name="avatarPath">The path of the avatar</param>
        /// <param name="VOG">The path of the VOG document</param>
        /// <param name="description">A description about the user</param>
        /// <param name="role">The role of the new user</param>
        /// <param name="sex">The gender of the new user</param>
        /// <param name="email">The email of the new user</param>
        /// <param name="id">The ID of the new user</param>
        /// <returns>Returns the new user as an account class</returns>
        public static Account Register(string name, Location loc, string password, string avatarPath, string VOG, string description, Accounttype role, string sex, string email, out int id)
        {
            //Returns: Account to set as MainUser in the admin class
            //Outs: the ID of the newly created account
            //Insert into the database
            //Retrieve the exact same stuff from the database, fetch the ID
            //Out the ID
            string passTotal = PasswordHashing.CreateHash(password);
            string[] passArray = passTotal.Split(':');

            //// Second string in array is the salt
            string passSalt = passArray[0] + ":";
            //// Third string in the array is the hash
            string passHash = passArray[1] + ":" + passArray[2];
            int locID = 0;
            
            if (Location.ValidateLocation(loc, out locID) == false)
            {
                locID = Location.InsertLocation(loc);
            }

            string roleText = string.Empty;

            //V = hulpverlener B = administrator H = hulpbehoevende
            switch (role)
            {
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
            id = 0;
            Database_Layer.Database.NewUser(name, locID, passHash, passSalt, avatarPath, VOG, description, roleText, sex, email);
            DataTable dt = Database.GetUserID(passHash);
            foreach (DataRow row in dt.Rows)
            {
                id = Convert.ToInt32(row["ID"]);
            }
            return new Account(id, name, loc, role, avatarPath, description, sex, email, VOG);
        }

        /// <summary>
        /// Creates the main user account
        /// </summary>
        /// <param name="username">the username / id of the account</param>
        /// <param name="password">the password of the matching account</param>
        /// <param name="acc">the account with all the details</param>
        /// <returns>Returns whether account is null or not</returns>
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
                    matchingaccount = true;
                    acc = CreateAccount(row);

                    break;
                }
            }
            return matchingaccount;
        }

        /// <summary>
        /// Inserts skills for specified account
        /// </summary>
        /// <param name="skill">The skill to insert</param>
        /// <param name="userid">The ID of the account</param>
        public static void CreateAccountSkills(string skill, int userid)
        {
            Database_Layer.Database.SkillInsertAcc(skill, userid);
        }

        /// <summary>
        /// Retrieves all the accounts from the database
        /// </summary>
        /// <returns>Returns all the accounts made on this point</returns>
        public static List<Account> FetchAllAccounts()
        {
            List<Account> accs = new List<Account>();

            DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc\"");
            foreach (DataRow row in dt.Rows)
            {
                accs.Add(CreateAccount(row));
            }
            return accs;
        }

        /// <summary>
        /// Get the password hash associated with an account ID
        /// </summary>
        /// <param name="ID">The ID of the account</param>
        /// <returns>Returns the password hash</returns>
        public static string GetPasswordHash(int ID)
        {
            string salt = string.Empty;
            string hash = string.Empty;
            DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc\" WHERE \"ID\" = " + ID);
            foreach (DataRow row in dt.Rows)
            {
              hash = row["PassHash"].ToString();
               salt = row["Salt"].ToString();
            }
            return (salt + hash);
        }

        /// <summary>
        /// Update the information of an account
        /// </summary>
        /// <param name="ID">The ID of the account</param>
        /// <param name="name">The new name of the account</param>
        /// <param name="loc">The new location of the account</param>
        /// <param name="sex">The new gender of the account</param>
        /// <param name="password">The new password of the account</param>
        /// <param name="avatarPath">The path of the new avatar</param>
        /// <param name="email">The new email of the account</param>
        /// <returns>Returns the updated account</returns>
        public static Account Update(int ID, string name, Location loc, string sex, string password, string avatarPath, string email)
        {
            int locID = 0;
            ////If location does not exist
            if (!Location.ValidateLocation(loc, out locID))
            {
                locID = Location.InsertLocation(loc);
            }

            string passTotal = PasswordHashing.CreateHash(password);
            string[] passArray = passTotal.Split(':');

            //// Third string in the array is the hash
            string passHash = passArray[1] + ":" + passArray[2];

            Database_Layer.Database.UpdateUser(ID, name, locID, sex, passHash, avatarPath, email);
            Account acc = null;
            Account.CreateMainAccount(ID.ToString(), password, out acc);
            return acc;
        }
        /// <summary>
        /// Update query if the user profile is update by an admin
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        /// <param name="acctype">The new account type of the user</param>
        /// <param name="name">The new name of the user</param>
        /// <param name="desc">The new description of the user</param>
        /// <param name="loc">The new location of the user</param>
        /// <param name="sex">The new gender of the user</param>
        /// <param name="avatarPath">The path of the new avatar</param>
        /// <param name="email">The new email of the user</param>
        public static void UpdateAdmin(int ID, Accounttype acctype, string name, string desc, Location loc, string sex, string avatarPath, string email)
        {
            int locID = 0;
            //If location does not exist
            if (!Location.ValidateLocation(loc, out locID))
            {
                locID = Location.InsertLocation(loc);
            }
            Database_Layer.Database.UpdateUser(ID, acctype.ToString(), name, locID, sex, avatarPath, email, desc);
        }

        /// <summary>
        /// Sets an user to the inactive state
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        public static void SetInactive(int ID)
        {
            Database_Layer.Database.DeleteUser(ID);
        }

        /// <summary>
        /// Finds account credentials and fills in account information
        /// </summary>
        /// <param name="row">The DataRow to process</param>
        /// <returns>Returns an account</returns>
        private static Account CreateAccount(DataRow row)
        {
            Account acc = null;
            Location loc = null;
            //Find location
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
            return acc;
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
        /// <param name="email">The email of the user</param>
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

        /// <summary>
        /// A test method for the database
        /// </summary>
        /// <returns>Returns a bool, indicating whether or not the database is functioning properly</returns>
        static public bool testdatabase()
        {
            if (Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc\"") == null)
                return false;
            else return true;
        }
    }
}

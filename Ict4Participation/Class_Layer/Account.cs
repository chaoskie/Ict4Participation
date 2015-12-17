//-----------------------------------------------------------------------
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
using Class_Layer.Enums;
using Class_Layer.Utility_Classes;

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
        public int ID { get; private set; }
        /// <summary>
        /// Gets the username of the user
        /// </summary>
        public string Username { get; private set; }
        /// <summary>
        /// Gets the name of the user
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Gets the email of the user
        /// </summary>
        public string Email { get; private set; }
        /// <summary>
        /// Gets the address of the user
        /// </summary>
        public string Address { get; private set; }
        /// <summary>
        /// Gets the city of the user
        /// </summary>
        public string City { get; private set; }
        /// <summary>
        /// Gets the phonenumber of the user
        /// </summary>
        public string Phonenumber { get; private set; }
        private Accounttype role;
        /// <summary>
        /// Gets the role of the user
        /// </summary>
        public Accounttype Role
        {
            get
            {
                return String.IsNullOrWhiteSpace(VOGPath) ? Accounttype.Hulpbehoevende : Accounttype.Hulpverlener;
            }
            private set { role = value; }
        }
        /// <summary>
        /// Gets the bool regarding whether the user has a license or not
        /// </summary>
        public bool hasDriverLicense { get; private set; }
        /// <summary>
        /// Gets the bool regarding whether the user owns a vehicle or not
        /// </summary>
        public bool hasVehicle { get; private set; }
        /// <summary>
        /// Gets the last login time (date) of the user
        /// </summary>
        public DateTime Lastlogin { get; private set; }
        /// <summary>
        /// Gets the bool regarding whether the user has the possibility to use OV or not
        /// </summary>
        public bool OVPossible { get; private set; }
        /// <summary>
        /// Gets the birthdate of the user
        /// </summary>
        public DateTime Birthdate { get; private set; }
        /// <summary>
        /// Gets the path of the avatar of the user
        /// </summary>
        public string AvatarPath { get; private set; }
        /// <summary>
        /// Gets the path of the VOG document
        /// </summary>
        public string VOGPath { get; private set; }
        /// <summary>
        /// Gets the gender of the user
        /// </summary>
        public string Gender { get; private set; }

        /// <summary>
        /// Gets the list of availability of the user
        /// </summary>
        public List<Availability> Availability { get; private set; }
        /// <summary>
        /// Gets the list of skills of this user
        /// </summary>
        public List<Skill> Skills { get; private set; }

        #endregion

        #region DataCollection
        /// <summary>
        /// Retrieves all the accounts from the database
        /// </summary>
        /// <returns>Returns all the accounts made on this point</returns>
        public static List<Account> GetAll()
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
        /// Retrieves a matching account from the database
        /// </summary>
        /// <param name="ID">The ID to match to</param>
        /// <returns>Returns the account matching this ID</returns>
        public static Account GetUser(int ID)
        {
            Account acc = null;
            DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc\" WHERE \"ID\" = " + ID);
            foreach (DataRow row in dt.Rows)
            {
                acc = CreateAccount(row);
            }
            return acc;
        }
        #endregion

        #region Logging in and out
        /// <summary>
        /// Logs a user in
        /// </summary>
        /// <param name="username">The given username</param>
        /// <param name="password">The given password</param>
        /// <param name="acc">The account if it exists and matches</param>
        /// <returns>Whether it is a valid combination or not</returns>
        public static bool LogIn(string username, string password, out Account acc)
        {
            //By default, there is no user found, and no user will be given
            bool matchingaccount = false;
            acc = null;
            //Find username in database
            DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc\" WHERE \"Gebruikersnaam\" = '" + username + "'");

            //Check if there's a username with this password
            foreach (DataRow row in dt.Rows)
            {
                //If exists && matches
                if (PasswordHashing.ValidatePassword(password, (row["Wachtwoord"].ToString())))
                {
                    matchingaccount = true;
                    acc = CreateAccount(row);

                    break;
                }
            }
            return matchingaccount;
        }

        //TODO
        public static void LogOut(Account acc)
        {
            //Log the given user out
        }
        #endregion

        #region Account altering
        /// <summary>
        /// Registers a new account
        /// </summary>
        /// <param name="username">The desired username</param>
        /// <param name="password">The desired password</param>
        /// <param name="email">The desired email</param>
        /// <param name="name">The full name</param>
        /// <param name="address">The full address</param>
        /// <param name="city">The city</param>
        /// <param name="phonenumber">The phonenumber (where +31 and such are allowed)</param>
        /// <param name="hasLicense">The desired license status</param>
        /// <param name="hasVehicle">The desired vehicle status</param>
        /// <param name="OVPossible">The desired OV status</param>
        /// <param name="birthdate">The birthdate of the user</param>
        /// <param name="avatarPath">The avatarpath of the user</param>
        /// <param name="VOG">The VOG of the user</param>
        /// <param name="gender">The gender of the user</param>
        /// <returns>The newly created account</returns>
        public static Account Register(string username, string password, string email, string name, string address, string city, string phonenumber,
            bool hasLicense, bool hasVehicle, bool OVPossible, DateTime birthdate, string avatarPath, string VOG, string gender)
        {
            string passTotal = PasswordHashing.CreateHash(password);
            string now = ConvertTo.OracleDateTime(DateTime.Now);
            string bday = ConvertTo.OracleDateTime(birthdate);

            Database.InsertUser(username, passTotal, email, name, address, city, phonenumber, hasLicense, hasVehicle, now, OVPossible, bday, avatarPath, gender, VOG);
            return null;
        }

        /// <summary>
        /// Inserts skills for specified account
        /// </summary>
        /// <param name="skill">The skill to insert</param>
        /// <param name="userid">The ID of the account</param>
        public static void AddSkill(string skill, int userid)
        {
            //Call Skill class to add
            Skill s = new Skill(userid, skill);
            s.Add();
        }

        public static void RemoveSkill(string skill, int userid)
        {
            //Call Skill class to remove
            Skill s = new Skill(userid, skill);
            s.Remove();
        }

        public static void AddAvailability(string day, string daytime, int userid)
        {
            //Call Availability class to add
            Availability av = new Availability(userid, day, daytime);
            av.Add();
        }

        public static void RemoveAvailability(string day, string daytime, int userid)
        {
            //Call Availability class to remove
            Availability av = new Availability(userid, day, daytime);
            av.Remove();
        }

        public static Account Update(int ID, string username, string password, string email, string name, string address, string city,
            string phonenumber, bool hasLicense, bool hasVehicle, bool OVPossible, DateTime birthdate, string avatarPath, string VOG,
            List<Skill> skills, List<Availability> availability, List<Skill> oldSkills, List<Availability> oldAvailability)
        {
            Account acc = null;
            //TODO
            //Call database to update account with ID
            //Check for different skill names: 
            //      remove ones that are no longer there
            //      add ones that are new
            //Retrieve updated account
            Account.LogIn(ID.ToString(), password, out acc);
            return acc;
        }

        /// <summary>
        /// Sets an user to the inactive state
        /// </summary>
        /// <param name="ID">The ID of the user</param>
        public static void SetInactive(int ID)
        {
            Database_Layer.Database.DeleteUser(ID);
        }
        #endregion

        #region Validation
        /// <summary>
        /// Get the password hash associated with an account ID
        /// </summary>
        /// <param name="ID">The ID of the account</param>
        /// <returns>Returns the password hash</returns>
        public static string FindHash(int ID)
        {
            string passwordHash = string.Empty;
            DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Acc\" WHERE \"ID\" = " + ID);
            foreach (DataRow row in dt.Rows)
            {
                passwordHash = row["Wachtwoord"].ToString();
            }
            return passwordHash;
        }

        #endregion

        /// <summary>
        /// Finds account credentials and fills in account information
        /// </summary>
        /// <param name="row">The DataRow to process</param>
        /// <returns>Returns an account</returns>
        private static Account CreateAccount(DataRow row)
        {
            int userid = Convert.ToInt32(row["ID"]);
            //Get availability and skills
            Account acc = null;
            //Create account
            acc = new Account(
                userid,
                row["Gebruikersnaam"].ToString(),
                row["Email"].ToString(),
                row["Naam"].ToString(),
                row["Adres"].ToString(),
                row["Woonplaats"].ToString(),
                row["Telefoonnummer"].ToString(),
                row["HeeftRijbewijs"].ToString(),
                row["HeeftAuto"].ToString(),
                Convert.ToDateTime(row["Uitschrijvingsdatum"]),
                row["OVMogelijk"].ToString(),
                Convert.ToDateTime(row["Geboortedatum"]),
                row["Foto"].ToString(),
                row["VOG"].ToString(),
                row["Geslacht"].ToString(),
                Skill.GetAll(userid),
                Class_Layer.Availability.GetAll(userid)
                );
            return acc;
        }

        /// <summary>
        /// Creates a new instance of the account class
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="name"></param>
        /// <param name="address"></param>
        /// <param name="city"></param>
        /// <param name="phonenumber"></param>
        /// <param name="hasLicense"></param>
        /// <param name="hasVehicle"></param>
        /// <param name="lastLogin"></param>
        /// <param name="OVPossible"></param>
        /// <param name="birthdate"></param>
        /// <param name="avatarPath"></param>
        /// <param name="VOG"></param>
        /// <param name="skills"></param>
        /// <param name="availability"></param>
        public Account(int ID, string username, string email, string name, string address, string city, string phonenumber,
            string hasLicense, string hasVehicle, DateTime lastLogin, string OVPossible, DateTime birthdate, string avatarPath, string VOG, string gender,
            List<Skill> skills, List<Availability> availability)
        {
            this.ID = ID;
            this.Username = username;
            this.Email = email;
            this.Name = name;
            this.Address = address;
            this.City = city;
            this.Phonenumber = phonenumber;
            this.hasDriverLicense = hasLicense == "1" ? true : false;
            this.hasVehicle = hasVehicle == "1" ? true : false;
            this.Lastlogin = lastLogin;
            this.OVPossible = OVPossible == "1" ? true : false;
            this.Birthdate = birthdate;
            this.AvatarPath = avatarPath;
            this.VOGPath = VOG;
            this.Skills = skills;
            this.Availability = availability;
        }
    }
}

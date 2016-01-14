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
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Database_Layer;
using Class_Layer.Enums;
using Class_Layer.Exceptions;
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
        /// <summary>
        /// Gets the description of the user
        /// </summary>
        public string Description { get; private set; }

        #endregion

        #region Data collection
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
        /// <para>Exceptions:</para>
        /// <para>:NoAccountFoundException</para>
        /// <para>:NoAccountCreatedException</para>
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
            bool hasLicense, bool hasVehicle, bool OVPossible, DateTime birthdate, string avatarPath, string VOG, string gender, List<Skill> iskills  )
        {
            string passTotal = PasswordHashing.CreateHash(password);
            string now = ConvertTo.OracleDateTime(DateTime.Now);
            string bday = ConvertTo.OracleDateTime(birthdate);

            if (Database.InsertUser(username, passTotal, email, name, address, city, phonenumber, hasLicense, hasVehicle, now, OVPossible, bday, avatarPath, gender, VOG))
            {
                //Find recently made account
                DataRow dtRow = Database.RetrieveQuery("SELECT * FROM \"Acc\" WHERE "
                    + "\"Gebruikersnaam\" = '" + username + "' AND "
                    + "\"Wachtwoord\" = '" + passTotal + "' AND "
                    + "\"Email\" = '" + email + "'").Rows[0];
                if (dtRow != null)
                {
                    Account acc;
                    Account.LogIn(username, password, out acc);
                    //Update skills
                    foreach (Skill s in iskills)
                    {
                        s.UserID = acc.ID;
                        s.Add();
                        acc.Skills.Add(s);
                    }
                    return acc;
                }
                else
                {
                    throw new NoAccountFoundException();
                }
            }
            else
            {
                throw new NoAccountCreatedException();
            }
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

        // These methods are obsolete as the availabilities are added and removed through the Availability class
        //public static void AddAvailability(string day, string daytime, int userid)
        //{
        //    //Call Availability class to add
        //    Availability av = new Availability(userid, day, daytime);
        //    av.Add();
        //}

        //public static void RemoveAvailability(string day, string daytime, int userid)
        //{
        //    //Call Availability class to remove
        //    Availability av = new Availability(userid, day, daytime);
        //    av.Remove();
        //}

        public void AddAvailability(string day, string daytime)
        {
            Availability av = new Availability(ID, day, daytime);
            Availability.Add(av);
        }

        public void RemoveAvailability(string day, string daytime)
        {
            Availability.Remove(Availability.Where(i => i.Day == day).Single(i => i.Daytime == daytime));
        }

        public static Account Update(int ID, string username, string email, string name, string address, string city,
            string phonenumber, bool hasLicense, bool hasVehicle, bool OVPossible, DateTime birthdate, string avatarPath, string VOG, string sex,
            List<Skill> skills, List<Availability> availability, List<Skill> oldSkills, List<Availability> oldAvailability, string description, string password = "")
        {
            string passhash = "";
            //If pass is blank, then don't update the password
            if (String.IsNullOrWhiteSpace(password))
            {
                Database.UpdateUser(ID, username, email, name, address, city, phonenumber, hasLicense, hasVehicle, OVPossible, ConvertTo.OracleDateTime(birthdate), avatarPath, sex, VOG, description);
            }
            //Else, update the password as well
            else
            {
                passhash = PasswordHashing.CreateHash(password);
                Database.UpdateUser(ID, username, passhash, email, name, address, city, phonenumber, hasLicense, hasVehicle, OVPossible, ConvertTo.OracleDateTime(birthdate), avatarPath, sex, VOG, description);
            }

            //Check for different skill names: 
            //      remove ones that are no longer there
            //      add ones that are new
            foreach (Skill s in skills)
            {
                //If the old skill list does not contain this new skill, add it
                if (!oldSkills.Select(sk => sk.Name).Contains(s.Name))
                {
                    if (s.UserID != 0)
                    {
                        s.Add();
                    }
                    else
                    {
                        throw new NotBoundToUserException();
                    }
                }
            }
            foreach (Skill s in oldSkills)
            {
                //If the new skill list does not contain this old skill, remove it
                if (!skills.Select(sk => sk.Name).Contains(s.Name))
                {
                    if (s.UserID != 0)
                    {
                        s.Remove();
                    }
                    else
                    {
                        throw new NotBoundToUserException();
                    }
                }
            }

            //Check for different availability: 
            //      remove ones that are no longer there
            //      add ones that are new
            foreach (Availability a in availability)
            {
                //If the old availability list does not contain this new availability, add it
                if (!oldAvailability.Select(av => av.Day + av.Daytime).Contains(a.Day + a.Daytime))
                {
                    if (a.UserID != 0)
                    {
                        a.Add();
                    }
                    else
                    {
                        throw new NotBoundToUserException();
                    }
                }
            }
            foreach (Availability a in oldAvailability)
            {
                //If the new availability list does not contain this old availability, remove it
                if (!availability.Select(av => av.Day + av.Daytime).Contains(a.Day + a.Daytime))
                {
                    if (a.UserID != 0)
                    {
                        a.Remove();
                    }
                    else
                    {
                        throw new NotBoundToUserException();
                    }
                }
            }

            //Retrieve updated account
            return Account.GetUser(ID);
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
                Class_Layer.Availability.GetAll(userid),
                row["Beschrijving"].ToString()
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
            List<Skill> skills, List<Availability> availability, string description)
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
            this.Skills = skills;
            this.Availability = availability;
            this.Gender = gender;
            this.Description = description;

            //If accessed normally
            if (System.Web.HttpContext.Current != null)
            {
                //Loop through the unvalidated folder
                bool found = false;
                string physicalPath = System.Web.HttpContext.Current.Request.MapPath("/");
                string[] fileEntries = Directory.GetFiles(physicalPath + "ProfileVOGs_Unvalidated");
                foreach (string fileName in fileEntries)
                {
                    //If the VOG was found, show a reference to it
                    if (Path.GetFileName(fileName).ToLower() == ID + ".pdf")
                    {
                        this.VOGPath = @"~\ProfileVOGs_Unvalidated\" + Path.GetFileName(fileName);
                        found = true;
                        break;
                    }
                }
                //If the VOG was not found in there, it was validated and looking at it is unnecessary
                if (!found)
                {
                    this.VOGPath = VOG;
                }


                //Loop through the avatar folder
                found = false;
                physicalPath = System.Web.HttpContext.Current.Request.MapPath("/");
                fileEntries = Directory.GetFiles(physicalPath + "ProfileAvatars");
                foreach (string fileName in fileEntries)
                {
                    //If the image was found, show a reference to it
                    if (Path.GetFileName(fileName).ToLower().Split('.').First() == ID.ToString())
                    {
                        this.AvatarPath = @"..\ProfileAvatars\" + Path.GetFileName(fileName);
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    switch (this.ID % 10)
                    {
                        case (0):
                            this.AvatarPath = @"..\ProfileAvatars\bear.jpg";
                            break;
                        case (1):
                            this.AvatarPath = @"..\ProfileAvatars\bunny.jpg";
                            break;
                        case (2):
                            this.AvatarPath = @"..\ProfileAvatars\emoe.jpg";
                            break;
                        case (3):
                            this.AvatarPath = @"..\ProfileAvatars\gekko.jpg";
                            break;
                        case (4):
                            this.AvatarPath = @"..\ProfileAvatars\hedgehog.jpg";
                            break;
                        case (5):
                            this.AvatarPath = @"..\ProfileAvatars\koala.jpg";
                            break;
                        case (6):
                            this.AvatarPath = @"..\ProfileAvatars\llama.jpg";
                            break;
                        case (7):
                            this.AvatarPath = @"..\ProfileAvatars\otter.jpg";
                            break;
                        case (8):
                            this.AvatarPath = @"..\ProfileAvatars\redbear.jpg";
                            break;
                        case (9):
                            this.AvatarPath = @"..\ProfileAvatars\sloth.jpg";
                            break;

                    }
                }
            }
            else //If accessed through admin form
            {
                this.VOGPath = VOG;
                this.AvatarPath = ID.ToString() + "." + avatarPath.Split('.').Last();
            }
        }

        /// <summary>
        /// Adds a password recovery request to the database for user
        /// </summary>
        /// <param name="url"></param>
        public string RequestPass()
        {
            //Call database to insert a new value into the "RecoveryPass" table, where
            //Hash = hashed username
            string hashedUsername = PasswordHashing.CreateHash(this.Username);
            Database.AddRequest(hashedUsername);
            return hashedUsername;
        }

        /// <summary>
        /// Uses a password recovery
        /// </summary>
        /// <param name="hash"></param>
        public static void ExpireRequest(string hash)
        {
            //Call database to set the "RecoveryPass" table, column "used" to false where hash = url
            Database.UseRequest(hash);
        }

        /// <summary>
        /// Checks if the password recovery is expired or not
        /// </summary>
        /// <param name="hash"></param>
        /// <returns></returns>
        public static bool isPRExpired(string hash)
        {
            return Database.isValidRequest(hash);
        }
    }
}

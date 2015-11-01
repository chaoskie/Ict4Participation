//-----------------------------------------------------------------------
// <copyright file="Administration.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Class_Layer;

namespace Admin_Layer
{

    /// <summary>
    /// Communicates between the GUI and classes
    /// </summary>
    public class Administration
    {
        public Account MainUser;
        private List<Account> Accounts;

        /// <summary>
        /// Initializes a new instance of the <see cref="Administration"/> class.
        /// </summary>
        public Administration()
        {
            // Implement
        }

        /// <summary>
        /// Post a comment
        /// </summary>
        /// <returns>Returns the result of the action</returns>
        public bool PostComment()
        {
            return false;
        }

        /// <summary>
        /// Post a question
        /// </summary>
        /// <returns>Returns the result of the action</returns>
        public string PostQuestion(string title, DateTime schedule, string description)
        {
            Question q = null;
            if (Question.CreateQuestion(MainUser.AccountID, title, schedule, description, MainUser.Loc, out q))
            {
                return String.Format("De volgende vraag is succesvol gepost: \n {0}", q.Title);
            }
            else
                return "Er ging iets fout! Raadpleeg de administrator indien deze fout blijft voordoen.";
        }

        /// <summary>
        /// Post a review
        /// </summary>
        /// <returns>Returns the result of the action</returns>
        public bool PostReview()
        {
            return false;
        }

        /// <summary>
        /// Arrange a meeting
        /// </summary>
        /// <returns>Returns the result of the action</returns>
        public bool ArrangeMeeting()
        {
            return false;
        }

        /// <summary>
        /// Logs the user in with the matching credentials
        /// </summary>
        /// <param name="gebruikersnaam">the username</param>
        /// <param name="password">the password</param>
        /// <returns>Whether this user exists / success of creation</returns>
        public bool LogIn(string gebruikersnaam, string password)
        {
            return Account.CreateMainAccount(gebruikersnaam, password, out MainUser);
        }

        public bool LogOut()
        {
            MainUser = null;
            return true;
        }

        //Since the GUI doesn't know what an account is, it has to be done the long way (without a reference)
        #region fetch account data
        /// <summary>
        /// Contains the following account data:
        /// <para>1 ID</para> 
        /// <para>2 Name </para>
        /// <para>3 Location </para>
        /// <para>4 AvatarPath </para>
        /// <para>5 Information </para>
        /// <para>6 Role </para>
        /// <para>7 Sex </para>
        /// <para>8 Email </para>
        /// </summary>
        /// <param name="index">The index of the one you want to select (ID = 1, Name = 2, etc)</param>
        /// <returns>The selected value of the index</returns>
        public string MainAccountData(int index)
        {
            return AllAccountData(MainUser)[index - 1];
        }

        public List<string> AllAccountTypes()
        {
            return Enum.GetValues(typeof(Accounttype)).Cast<Accounttype>().Select(x => x.ToString()).ToList();
        }

        private List<string> AllAccountData(Account a)
        {
            List<string> rt = new List<string>();
            rt.Add(AccountID(a));
            rt.Add(AccountName(a));
            rt.Add(AccountLocation(a));
            rt.Add(AccountAvatarPath(a));
            rt.Add(AccountInformation(a));
            rt.Add(AccountRole(a));
            rt.Add(AccountSex(a));
            rt.Add(AccountEmail(a));
            return rt;
        }
        private string AccountID(Account a)
        {
            return a.AccountID.ToString();
        }
        private string AccountAvatarPath(Account a)
        {
            return a.AvatarPath;
        }
        private string AccountEmail(Account a)
        {
            return a.Email;
        }
        private string AccountInformation(Account a)
        {
            return a.Information;
        }
        private string AccountLocation(Account a)
        {
            return a.Loc.ToString();
        }
        private string AccountName(Account a)
        {
            return a.Naam;
        }
        private string AccountRole(Account a)
        {
            return a.Role.ToString();
        }
        private string AccountSex(Account a)
        {
            return a.Sex;
        }
        #endregion

        #region Testing Methods
        //testmethod voor database
        static public bool testDatabase()
        {
            return Account.testdatabase();
        }
        #endregion
    }
}

//-----------------------------------------------------------------------
// <copyright file="Administration.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
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
        private List<Question> LoadedQuestions;
        private List<Comment> LoadedComments;
        private int lastloadedOPID;
        string nameTEMP; string locTEMP; string passwordTEMP; string avatarPathTEMP; string roleTEMP; string sexTEMP;

        /// <summary>
        /// Initializes a new instance of the <see cref="Administration"/> class.
        /// </summary>
        public Administration()
        {
            Accounts = new List<Account>();
            LoadedQuestions = new List<Question>();
            LoadedComments = new List<Comment>();
        }

        #region Question handling

        /// <summary>
        /// Post a question
        /// </summary>
        /// <returns>Returns the result of the action</returns>
        public string PostQuestion(string title, DateTime schedule, string description, List<string> skills)
        {
            Question q = null;
            if (Question.CreateQuestion(MainUser.AccountID, title, schedule, description, MainUser.Loc, skills, out q))
            {
                return String.Format("De volgende vraag is succesvol gepost: \n {0}", q.Title);
            }
            else
                return "Er ging iets fout! Raadpleeg de administrator indien deze fout blijft voordoen.";
        }

        /// <summary>
        /// Retrieves a list of all the question titles
        /// </summary>
        /// <param name="all">Whether they have to be all the questions, or just the main user</param>
        /// <returns>A list regarding these names</returns>
        public List<string> GetQuestionNames(bool all = true)
        {
            LoadedQuestions = Question.FindQuestions(all, MainUser.AccountID);
            return LoadedQuestions.Cast<Question>().Select(x => x.Title).ToList();
        }

        /// <summary>
        /// Retrieves the information of a selected question title, by index
        /// </summary>
        /// <param name="index">The index of the selected title</param>
        /// <param name="all">Whether there's a selection from the complete list, or just the main user</param>
        /// <returns></returns>
        public string GetQuestionDetails(int index, bool all = true)
        {
            return LoadedQuestions[index].GetDescription(LoadedQuestions[index].PostID, out lastloadedOPID);
        }

        public List<string> GetQuestionSkills(int index, bool all = true)
        {
            return LoadedQuestions[index].Skills;
        }

        /// <summary>
        /// Retrieves the comments about a post
        /// </summary>
        /// <param name="postID"></param>
        /// <returns></returns>
        public List<string> GetQuestionComments(int index)
        {
            return Comment.GetQuestionComments(LoadedQuestions[index].PostID, out LoadedComments);
        }

        /// <summary>
        /// Places a new comment for said question
        /// </summary>
        /// <param name="title">The comment</param>
        /// <param name="index">The index of the selected question</param>
        public void PlaceQuestionComment(string title, int index)
        {
            Comment.PlaceComment(MainUser.AccountID, LoadedQuestions[index].PostID, title);
        }

        #endregion

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


        #region Account handling

        /// <summary>
        /// Validates the first half of the account (for the first form / screen)
        /// </summary>
        /// <param name="name">Name to validate</param>
        /// <param name="loc">Location to validate</param>
        /// <param name="password">Password to validate</param>
        /// <param name="avatarPath">AvatarPath to validate</param>
        /// <param name="role">Role to validate</param>
        /// <param name="sex">Sex to validate</param>
        /// <param name="Message">Error message given upon invalid parameters</param>
        /// <returns>Whether it is a full success, or there is at least 1 invalid parameter</returns>
        public bool CreateAccount(string name, string address, string city, string password, string avatarPath, string role, string sex, out string Message)
        {
            bool filledIn = true;
            bool rightFormat = false;
            string error = string.Empty;

            //Check if everything is filled in
            if (String.IsNullOrWhiteSpace(name))
                error += "De naam is niet ingevuld!\n"; filledIn = false;
            if (String.IsNullOrWhiteSpace(address))
                error += "Het adres is niet ingevuld!\n"; filledIn = false;
            if (String.IsNullOrWhiteSpace(city))
                error += "De woonplaats is niet ingevuld!\n"; filledIn = false;
            if (String.IsNullOrWhiteSpace(sex))
                error += "Het geslacht is niet ingevuld!\n"; filledIn = false;
            if (String.IsNullOrWhiteSpace(role))
                error += "De rol is niet ingevuld!\n"; filledIn = false;
            if (String.IsNullOrWhiteSpace(avatarPath))
                error += "Er is geen profielfoto gekozen!\n"; filledIn = false;
            if (String.IsNullOrWhiteSpace(password))
                error += "Er is is geen wachtwoord ingevuld!\n"; filledIn = false;

            //If so, check if everything is in the right format
            if (filledIn)
            {
                rightFormat = true;
                if (Regex.IsMatch(name.Trim(), @"^[A-Z][A-Za-z]+$") == false)
                {
                    rightFormat = false;
                    error += "Naam is niet correct!\n";
                }
                //if (!Regex.IsMatch(adress, @"^[A-Z]\D{1,}\s?\d{1,}$"))
                //{
                //    allOK = false;
                //    error += "Addres is niet correct!\n";
                //}
                //if (!Regex.IsMatch(city, @"^[A-Z']\D{1,}$"))
                //{
                //    allOK = false;
                //    error += "Woonplaats is niet correct!\n";
                //}
                if (!Regex.IsMatch(sex, @"^[MF]$"))
                {
                    rightFormat = false;
                    error += "Geslacht is niet correct!\n";
                }
                if (avatarPath != string.Empty)
                {
                    rightFormat = false;
                    error += "Geen foto geselecteerd!\n";
                }
                if (!Regex.IsMatch(password, @"^(?=.*[^a-zA-Z])(?=.*[a-z])(?=.*[A-Z])\S{8,}$"))
                {
                    rightFormat = false;
                    error += "Het wachtwoord is niet sterk genoeg! Minimaal 1 hoofdletter, 1 kleine letter en 1 nummer/speciaal karakter.";
                }
                //If everything is in the right format, set the temporaries for the next screen
                if (rightFormat)
                {
                    this.nameTEMP = name;
                    this.locTEMP = String.Format("{0}, {1}", address, city);
                    this.passwordTEMP = password;
                    this.avatarPathTEMP = avatarPath;
                    this.roleTEMP = role;
                    this.sexTEMP = sex;
                }
            }
            Message = error;
            return rightFormat;
        }

        /// <summary>
        /// Validates the second half of the account (for the second form / screen)
        /// </summary>
        /// <param name="VOG">The VOG to validate</param>
        /// <param name="description">The description to validate</param>
        /// <param name="email">The email to validate</param>
        /// <param name="Message">The error message given upon invalid parameters</param>
        /// <returns></returns>
        public bool CreateAccountFinal(string VOG, string description, string email, out string Message)
        {
            //TODO: Check the other strings
            //Out error message
            //Create account through
            //Account.Register();
            Message = "Function not yet fully implemented!";
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

        /// <summary>
        /// Logs the user out
        /// </summary>
        /// <returns>if succeeded (always)</returns>
        public bool LogOut()
        {
            MainUser = null;
            return true;
        }

        #endregion

        #region encoding and decoding of text to HTML and back

        public string ToHtmlText(string text)
        {
            return WebUtility.HtmlEncode(text);
        }

        public string FromHtmlText(string text)
        {
            return WebUtility.HtmlDecode(text);
        }

        #endregion

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

        public List<string> AllSkillTypes()
        {
            return Enum.GetValues(typeof(Tags)).Cast<Tags>().Select(x => x.ToString()).ToList();
        }

        public List<string> AllAccountTypes()
        {
            return Enum.GetValues(typeof(Accounttype)).Cast<Accounttype>().Select(x => x.ToString()).ToList();
        }

        private List<string> AllAccountData(Account a)
        {
            List<string> rt = new List<string>();
            rt.Add(a.AccountID.ToString());
            rt.Add(a.Naam);
            rt.Add(a.Loc.ToString());
            rt.Add(a.AvatarPath);
            rt.Add(a.Information);
            rt.Add(a.Role.ToString());
            rt.Add(a.Sex);
            rt.Add(a.Email);
            return rt;
        }
        #endregion

        #region Testing Methods
        //testmethod voor database
        static public bool testDatabase()
        {
            return Account.testdatabase();
        }
        static public string giveTestHash()
        {
            return PasswordHashing.CreateHash("default");
        }
        #endregion
    }
}

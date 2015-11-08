//-----------------------------------------------------------------------
// <copyright file="Administration.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
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
        private List<Account> LoadedAccounts;
        private List<Account> AllAccounts;
        private List<Question> LoadedQuestions;
        private List<Comment> LoadedComments;
        private List<Review> LoadedReviews;
        private int lastloadedOPID;
        string emailTEMP; string nameTEMP; Location locTEMP; string passwordTEMP; string avatarPathTEMP;
        Accounttype roleTEMP; string sexTEMP; string VOGTEMP; string descriptionTEMP; List<string> skillsTEMP;

        /// <summary>
        /// Initializes a new instance of the <see cref="Administration"/> class.
        /// </summary>
        public Administration()
        {
            AllAccounts = new List<Account>();
            LoadedAccounts = new List<Account>();
            LoadedQuestions = new List<Question>();
            LoadedComments = new List<Comment>();
        }

        #region Comment handling

        /// <summary>
        /// Edits the specified comment
        /// </summary>
        /// <param name="index">index as the same as in the loaded comment list</param>
        /// <param name="text">text as wanted to have text</param>
        public void EditComment(int index, string text)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                Comment.EditComment(LoadedComments[index].PostID, text);
            }
        }

        /// <summary>
        /// Removes the specified comment
        /// </summary>
        /// <param name="index">index as the same as in the loaded comment list</param>
        public void DeleteComment(int index, bool isAdmin = false)
        {
            Comment.DeleteComment(LoadedComments[index].PostID, isAdmin);
        }

        /// <summary>
        /// Gets the ID of the user who posted a comment
        /// </summary>
        /// <param name="index">Index of the comment in the loaded comments</param>
        /// <returns>a string of the ID</returns>
        public string GetCommentPosterID(int index)
        {
            return LoadedComments[index].PosterID.ToString();
        }

        #endregion

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
        /// Places a new comment for said question
        /// </summary>
        /// <param name="title">The comment</param>
        /// <param name="index">The index of the selected question</param>
        public void PostQuestionComment(string title, int index)
        {
            Comment.PlaceComment(MainUser.AccountID, LoadedQuestions[index].PostID, title);
        }

        #region Question Editing
        /// <summary>
        /// Changes the question original poster
        /// </summary>
        /// <param name="index">Index of the question as selected in the list</param>
        /// <param name="name">Name or ID of the user</param>
        /// <param name="error">Error message given upon... error.</param>
        /// <returns>Whether it succeeded or not</returns>
        public bool ChangeQuestionPoster(int index, string name, out string error)
        {
            error = "Niets ingevuld!";
            if (String.IsNullOrWhiteSpace(name))
            {
                return false;
            }
            if (!String.IsNullOrWhiteSpace(name))
            {
                //Create a list containing all the 'hulpbehoevenden' (the ones with the rights to post these questions) matching the name
                List<string> accs = GetAccounts("Hulpbehoevende", true, name);
                //Create a list containing all the 'hulpbehoevenden' matching the ID
                List<Account> accsWithID = LoadedAccounts.FindAll(a => a.AccountID.ToString() == name && a.Role == Accounttype.Hulpbehoevende);
                //If no correct ID or name is filled in
                if (accs.Count == 0 && accsWithID.Count == 0)
                {
                    error = "Oeps! Hulpbehoevende met deze naam / ID bestaat niet";
                    return false;
                }
                //If a correct name is filled in, but matches more accounts
                if (accs.Count > 1 && accsWithID.Count == 0)
                {
                    error = "Oeps! Er bestaan meerdere gebruikers met deze naam:";
                    foreach (Account a in LoadedAccounts.FindAll(ac => ac.Naam == name))
                    {
                        error += a.AccountID + " " + a.Naam + Environment.NewLine;
                    }
                    error += "Geef het juiste ID op in plaats van de naam";
                    return false;
                }
                //If a correct name is filled in, and matches only a single account
                if (accs.Count == 1)
                {
                    //Get IDs
                    int userID = LoadedAccounts.Find(a => a.Naam.ToString() == name && a.Role == Accounttype.Hulpbehoevende).AccountID;
                    int questionID = LoadedQuestions[index].PostID;
                    //Change the question poster
                    Question.Update(
                        LoadedQuestions[index].PostID,
                        LoadedQuestions[index].Title,
                        LoadedQuestions[index].Schedule,
                        LoadedQuestions[index].Description,
                        LoadedQuestions[index].QuestionLocation,
                        LoadedQuestions[index].Skills,
                        userID
                        );
                    return true;
                }
                //If a correct ID is filled in (always matches 1 account)
                if (accsWithID.Count == 1)
                {
                    //Get IDs
                    int userID = accsWithID[0].AccountID;
                    int questionID = LoadedQuestions[index].PostID;
                    //Change the question poster
                    Question.Update(
                        LoadedQuestions[index].PostID,
                        LoadedQuestions[index].Title,
                        LoadedQuestions[index].Schedule,
                        LoadedQuestions[index].Description,
                        LoadedQuestions[index].QuestionLocation,
                        LoadedQuestions[index].Skills,
                        userID
                        );
                    return true;
                }
            }
            error = "Oeps! Geen naam of ID ingevuld!";
            return false;
        }

        /// <summary>
        /// Changes the question help wanted time
        /// </summary>
        /// <param name="index">Index of the question as selected in the list</param>
        /// <param name="time">String of time to be parsed</param>
        /// <param name="error">Error message</param>
        /// <returns>Whether it succeeded or not</returns>
        public bool ChangeQuestionTime(int index, string time, out string error)
        {
            error = "Niets ingevuld!";
            if (String.IsNullOrWhiteSpace(time))
            {
                return false;
            }
            DateTime dt;
            if (DateTime.TryParse(time, out dt))
            {
                //Change the time
                Question.Update(
                    LoadedQuestions[index].PostID,
                    LoadedQuestions[index].Title,
                    dt,
                    LoadedQuestions[index].Description,
                    LoadedQuestions[index].QuestionLocation,
                    LoadedQuestions[index].Skills,
                    LoadedQuestions[index].UserID
                    );
                return true;
            }
            else
            {
                error += "Oeps, tijd is niet correct!";
            }
            return false;
        }

        /// <summary>
        /// Changes the question help wanted time
        /// </summary>
        /// <param name="index">Index of the question as selected in the list</param>
        /// <param name="description">Description to update to</param>
        /// <param name="error">Error message</param>
        /// <returns>Whether it succeeded or not</returns>
        /// <returns></returns>
        public bool ChangeQuestionDescription(int index, string description, out string error)
        {
            error = "Niets ingevuld!";
            if (String.IsNullOrWhiteSpace(description))
            {
                return false;
            }
            Question.Update(
                    LoadedQuestions[index].PostID,
                    LoadedQuestions[index].Title,
                    LoadedQuestions[index].Schedule,
                    description,
                    LoadedQuestions[index].QuestionLocation,
                    LoadedQuestions[index].Skills,
                    LoadedQuestions[index].UserID
                    );
            return true;
        }

        /// <summary>
        /// Changes the question help wanted time
        /// </summary>
        /// <param name="index">Index of the question as selected in the list</param>
        /// <param name="location">Location to parse</param>
        /// <param name="error">Error message</param>
        /// <returns>Whether it succeeded or not</returns>
        /// <returns></returns>
        public bool ChangeQuestionLocation(int index, string location, out string error)
        {
            error = "Niets ingevuld!";
            if (String.IsNullOrWhiteSpace(location))
            {
                return false;
            }
            Location loc = new Location(location);
            int locID = 0;
            //If location does not exist
            if (!Location.ValidateLocation(loc, out locID))
            {
                locID = Location.InsertLocation(loc);
            }
            Question.Update(
                    LoadedQuestions[index].PostID,
                    LoadedQuestions[index].Title,
                    LoadedQuestions[index].Schedule,
                    LoadedQuestions[index].Description,
                    loc,
                    LoadedQuestions[index].Skills,
                    LoadedQuestions[index].UserID
                    );
            return true;
        }

        #endregion

        /// <summary>
        /// Retrieves a list of all the question titles
        /// </summary>
        /// <param name="all">Whether they have to be all the questions, or just the main user</param>
        /// <returns>A list regarding these names</returns>
        public List<string> GetQuestionNames(bool all = true)
        {
            if (!all)
            {
                LoadedQuestions = Question.FindQuestions(all, MainUser.AccountID);
            }
            else
            {
                LoadedQuestions = Question.FindQuestions(all);
            }
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

        /// <summary>
        /// Retrieves all the skills matching to a question
        /// </summary>
        /// <param name="index">The index of the selected title</param>
        /// <param name="all">Whether its the own questions, or all the questions</param>
        /// <returns>A list of skills</returns>
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
        /// Deletes the specified question
        /// </summary>
        /// <param name="index">The index of the question in the list</param>
        /// <returns>A string regarding the message of deletion</returns>
        public string DeleteQuestion(int index)
        {
            Question.Delete(LoadedQuestions[index].PostID);
            return "Vraag succesvol verwijderd";
        }

        #endregion

        #region Review handling

        /// <summary>
        /// Posts a review about a user
        /// </summary>
        /// <param name="userID">The userID of the reviewed user</param>
        /// <param name="title">The title of the review</param>
        /// <param name="description">The description of the review</param>
        /// <param name="rating">The rating of the review</param>
        /// <param name="Message">The message given upon review postage</param>
        /// <returns>Whether it was a success or not</returns>
        public bool PostReview(int userID, string title, string description, int rating, out string Message)
        {
            Message = Review.PlaceReview(rating, title, userID, MainUser.AccountID, description);
            return true;
        }

        /// <summary>
        /// Deletes the specified review
        /// </summary>
        /// <param name="index">The index as in loaded reviews</param>
        /// <returns>A string regarding the deletion</returns>
        public string DeleteReview(int index)
        {
            Review.Delete(LoadedComments[index].PostID);
            return "Review succesvol verwijderd!";
        }

        /// <summary>
        /// Changes the review rating
        /// </summary>
        /// <param name="index">Index as loaded</param>
        /// <param name="edit">Rating to edit to</param>
        /// <param name="error">The error message</param>
        /// <returns>Whether it succeeded or not</returns>
        public bool ChangeReviewRating(int index, string edit, out string error)
        {
            error = "Niets ingevuld!";
            if (String.IsNullOrWhiteSpace(edit))
            {
                return false;
            }
            int rating;
            if (Int32.TryParse(edit, out rating))
            {
                if (rating > 0 && rating < 6)
                {
                    Review.Update(
                        LoadedReviews[index].PostID,
                        rating,
                        LoadedReviews[index].Title,
                        LoadedReviews[index].Description
                        );
                    return true;
                }
                else
                {
                    error = "Aantal sterren ligt niet tussen 0 en 6! (1-5 geaccepteerd)";
                }
            }
            else
            {
                error = "Geen geldig nummer ingevoerd!";
            }
            return false;
        }

        /// <summary>
        /// Changes the review title
        /// </summary>
        /// <param name="index">Index as loaded</param>
        /// <param name="edit">Title to edit to</param>
        /// <param name="error">The error message</param>
        /// <returns>Whether it succeeded or not</returns>
        public bool ChangeReviewTitle(int index, string edit, out string error)
        {
            error = "Niets ingevuld!";
            if (String.IsNullOrWhiteSpace(edit))
            {
                return false;
            }
            else
            {
                Review.Update(
                        LoadedReviews[index].PostID,
                        LoadedReviews[index].Rating,
                        edit,
                        LoadedReviews[index].Description
                        );
                return true;
            }
        }

        /// <summary>
        /// Changes the review description
        /// </summary>
        /// <param name="index">Index as loaded</param>
        /// <param name="edit">Description to edit to</param>
        /// <param name="error">The error message</param>
        /// <returns>Whether it succeeded or not</returns>
        public bool ChangeReviewDescription(int index, string edit, out string error)
        {
            error = "Niets ingevuld!";
            if (String.IsNullOrWhiteSpace(edit))
            {
                return false;
            }
            else
            {
                Review.Update(
                        LoadedReviews[index].PostID,
                        LoadedReviews[index].Rating,
                        LoadedReviews[index].Title,
                        edit
                        );
                return true;
            }
        }

        /// <summary>
        /// Returns all the account reviews of either the poster, or the posted, specified by a bool and ID
        /// </summary>
        /// <param name="userid">The poster, or receiver of a review</param>
        /// <param name="isPoster">Whether it is a poster, or a receiver (false)</param>
        /// <returns>A list with all the details of the reviews</returns>
        public List<string> GetAccountReviews(int userid, bool isPoster = false)
        {
            return Review.GetUserReviews(userid, out LoadedReviews, isPoster);
        }

        /// <summary>
        /// Returns all the account reviews
        /// </summary>
        /// <returns>A list with all the details of the reviews</returns>
        public List<string> GetAccountReviews()
        {
            return Review.GetAllUserReviews(out LoadedReviews);
        }

        /// <summary>
        /// Returns all the account reviews of the main user
        /// </summary>
        /// <returns>A list with all the details of the reviews</returns>
        public List<string> GetAccountReviews(bool isPoster = false)
        {
            return Review.GetUserReviews(MainUser.AccountID, out LoadedReviews, isPoster);
        }
        #endregion

        #region Meeting handling
        /// <summary>
        /// Arrange a meeting
        /// </summary>
        /// <returns>Returns the result of the action</returns>
        public string CreateMeeting(int otheruserID, DateTime time, string location)
        {
            int locID = 0;
            Location loc = new Location(location);
            if (!Location.ValidateLocation(loc, out locID))
            {
                locID = Location.InsertLocation(loc);
            }

            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            
            string retu = Meeting.CreateMeeting(MainUser.AccountID, otheruserID, time, locID);

            mail.From = new MailAddress("s21mplumbum@gmail.com");
            mail.To.Add(LoadedAccounts.First(c => c.AccountID == otheruserID).Email);
            mail.Subject = "U bent uitgenodigd voor een ontmoeting!";
            mail.Body = String.Format("Hallo! \nEr is een ontmoeting ingepland voor u met {0} \nTijd: {1}, \nLocatie: {2}",
                MainUser.Naam, time.ToString(), location);

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("s21mplumbum@gmail.com", "Em72@Gmai111");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            return retu;
        }

        /// <summary>
        /// Retrieves all the detailed information about ALL the meetings
        /// </summary>
        /// <returns>Yields a list of the tostrings</returns>
        public List<string> GetAllAccountMeetings()
        {
            return Meeting.GetAllMeetings().Select(meeting => meeting.Details).ToList();
        }

        /// <summary>
        /// Retrieves all the detailed information about ALL the meetings OF THE MAIN USER
        /// </summary>
        /// <returns>Yields a list of the tostrings</returns>
        public List<string> GetMainAccountMeetings()
        {
            return Meeting.GetAllMeetings(MainUser.AccountID).Select(meeting => meeting.Details).ToList();
        }
        #endregion

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
        public bool CreateAccount(string name, string address, string city, string password, string avatarPath, string role, string sex, string email, out string Message)
        {
            bool filledIn = true;
            bool rightFormat = false;
            string error = string.Empty;
            name = name.Trim();

            //Check if everything is filled in
            if (String.IsNullOrWhiteSpace(name))
            {
                error += "De naam is niet ingevuld!\n"; filledIn = false;
            }
            if (String.IsNullOrWhiteSpace(address))
            {
                error += "Het adres is niet ingevuld!\n"; filledIn = false;
            }
            if (String.IsNullOrWhiteSpace(city))
            {
                error += "De woonplaats is niet ingevuld!\n"; filledIn = false;
            }
            if (String.IsNullOrWhiteSpace(sex))
            {
                error += "Het geslacht is niet ingevuld!\n"; filledIn = false;
            }
            if (String.IsNullOrWhiteSpace(role))
            {
                error += "De rol is niet ingevuld!\n"; filledIn = false;
            }
            if (String.IsNullOrWhiteSpace(email))
            {
                error += "Het email is niet ingevuld!\n"; filledIn = false;
            }
            if (String.IsNullOrWhiteSpace(avatarPath))
            {
                error += "Er is geen profielfoto gekozen!\n"; filledIn = false;
            }
            if (String.IsNullOrWhiteSpace(password))
            {
                error += "Er is is geen wachtwoord ingevuld!\n"; filledIn = false;
            }

            //If so, check if everything is in the right format
            if (filledIn)
            {
                rightFormat = true;
                if (Regex.IsMatch(name, @"^[A-Z][A-Za-z\.]*(?:\s[A-Za-z][a-z]+)+$") == false)
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
                if (avatarPath == string.Empty)
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
                    this.locTEMP = new Location(String.Format("{0}, {1}", address, city));
                    this.passwordTEMP = password;
                    this.avatarPathTEMP = avatarPath;
                    Enum.TryParse(role, out roleTEMP);
                    this.sexTEMP = sex;
                    this.emailTEMP = email;
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
        public bool CreateAccountHPart(string VOG, string description, List<string> skills, out string Message)
        {
            //Out error message
            bool filledIn = true;
            bool rightformat = false;

            string error = string.Empty;

            //Check if everything is filled in
            if (String.IsNullOrWhiteSpace(VOG))
            {
                error += "Het VOG is niet opgegeven!\n"; filledIn = false;
            }

            if (filledIn)
            {
                rightformat = true;

                if (!VOG.ToLower().Contains(".pdf"))
                {
                    rightformat = false;
                }

                if (rightformat)
                {
                    this.VOGTEMP = VOG;
                    this.descriptionTEMP = description;
                    this.skillsTEMP = skills;
                }
            }
            Message = error;
            return rightformat;
        }

        /// <summary>
        /// Registers an account with the saved credentials from CreateAccount (and CreateAccountHPart)
        /// </summary>
        /// <returns>If it succeeded or not</returns>
        public bool RegisterAccount()
        {
            //Create account through
            int createdID = 0;
            MainUser = Account.Register(nameTEMP, locTEMP, passwordTEMP, avatarPathTEMP, VOGTEMP, descriptionTEMP, roleTEMP, sexTEMP, emailTEMP, out createdID);
            //Create skill references if 'hulpverlener'
            if (roleTEMP == Accounttype.Hulpverlener)
            {
                foreach (string skill in skillsTEMP)
                {
                    Account.CreateAccountSkills(skill, MainUser.AccountID);
                }
            }

            //Send email with credentials
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            string cID = createdID.ToString();
            while (cID.Length < 3)
            {
                cID = 0 + cID;
            }

            mail.From = new MailAddress("s21mplumbum@gmail.com");
            mail.To.Add(emailTEMP);
            mail.Subject = "ICT4Participation inlog gegevens";
            mail.Body = "Hallo en bedankt voor het registreren van een ICT4Participation account! \nGebruik het volgende ID om in te loggen: \nUser ID:" + createdID;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("s21mplumbum@gmail.com", "Em72@Gmai111");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            return true;
        }

        /// <summary>
        /// Edits the account with the specified credentials. If a credential is not filled in, no checks will be performed over it
        /// </summary>
        /// <param name="name">The name to update to</param>
        /// <param name="address">The address to update to</param>
        /// <param name="sex">The sex to update to</param>
        /// <param name="password">The password to update to</param>
        /// <param name="avatarPath">The avatarpath to update to</param>
        /// <param name="email">The email to update to (mail will be sent to both old and new email)</param>
        /// <param name="error">The error in case anything went wrong</param>
        /// <returns>Whether it was a success or not</returns>
        public bool EditAccount(string name, string address, string sex, string password, string avatarPath, string email, out string error)
        {
            bool rightFormat = true;
            error = string.Empty;

            if (!string.IsNullOrWhiteSpace(name))
            {
                if (Regex.IsMatch(name, @"^[A-Z][A-Za-z\.]*(?:\s[A-Za-z][a-z]+)+$") == false)
                {
                    rightFormat = false;
                    error += "Naam is niet correct!\n";
                }
            }

            if (!string.IsNullOrWhiteSpace(sex))
            {
                if (!Regex.IsMatch(sex, @"^[MF]$"))
                {
                    rightFormat = false;
                    error += "Geslacht is niet correct!\n";
                }
            }

            if (!string.IsNullOrWhiteSpace(password))
            {
                if (!Regex.IsMatch(password, @"^(?=.*[^a-zA-Z])(?=.*[a-z])(?=.*[A-Z])\S{8,}$"))
                {
                    rightFormat = false;
                    error += "Het wachtwoord is niet sterk genoeg! Minimaal 1 hoofdletter, 1 kleine letter en 1 nummer/speciaal karakter.";
                }
            }
            if (rightFormat)
            {
                MainUser = Account.Update(MainUser.AccountID, name, new Location(address), sex, password, avatarPath, email);
            }

            return rightFormat;
        }

        /// <summary>
        /// Sets an account to inactive, leaving their posts unharmed, but disallowing log in
        /// </summary>
        /// <param name="index">The index as specified in loaded users</param>
        /// <returns>A message regarding the inactivation</returns>
        public string SetInactiveAccount(int index)
        {
            Account.SetInactive(LoadedAccounts[index].AccountID);
            return "Gebruiker succesvol inactief gezet!";
        }

        /// <summary>
        /// Changes the user's name
        /// </summary>
        /// <param name="index">Index of the user as loaded</param>
        /// <param name="edit">The edit of the name</param>
        /// <param name="error">The error message</param>
        /// <returns>Whether it succeeded or not</returns>
        public bool ChangeAccountName(int index, string edit, out string error)
        {
            error = "Niets ingevuld!";
            if (!string.IsNullOrWhiteSpace(edit))
            {
                if (Regex.IsMatch(edit, @"^[A-Z][A-Za-z\.]*(?:\s[A-Za-z][a-z]+)+$"))
                {
                    Account.UpdateAdmin(
                        LoadedAccounts[index].AccountID,
                        LoadedAccounts[index].Role,
                        edit,
                        LoadedAccounts[index].Information,
                        LoadedAccounts[index].Loc,
                        LoadedAccounts[index].Sex,
                        LoadedAccounts[index].AvatarPath,
                        LoadedAccounts[index].Email
                        );
                    return true;
                }
                else
                    error = "Naam is niet correct!";
            }
            return false;
        }

        /// <summary>
        /// Changes the user's location
        /// </summary>
        /// <param name="index">Index of the user as loaded</param>
        /// <param name="edit">The edit of the location</param>
        /// <param name="error">The error message</param>
        /// <returns></returns>
        public bool ChangeAccountLocation(int index, string edit, out string error)
        {
            error = "Niets ingevuld!";
            if (String.IsNullOrWhiteSpace(edit))
            {
                return false;
            }
            Location loc = new Location(edit);
            int locID = 0;
            //If location does not exist
            if (!Location.ValidateLocation(loc, out locID))
            {
                locID = Location.InsertLocation(loc);
            }
            Account.UpdateAdmin(
                        LoadedAccounts[index].AccountID,
                        LoadedAccounts[index].Role,
                        LoadedAccounts[index].Naam,
                        LoadedAccounts[index].Information,
                        loc,
                        LoadedAccounts[index].Sex,
                        LoadedAccounts[index].AvatarPath,
                        LoadedAccounts[index].Email
                        );

            return true;
        }

        /// <summary>
        /// Changes the user's description
        /// </summary>
        /// <param name="index">Index of the user as loaded</param>
        /// <param name="edit">The edit of the description</param>
        /// <param name="error">The error message</param>
        public bool ChangeAccountDescription(int index, string edit, out string error)
        {
            error = "Niets ingevuld!";
            if (!string.IsNullOrWhiteSpace(edit))
            {
                Account.UpdateAdmin(
                    LoadedAccounts[index].AccountID,
                    LoadedAccounts[index].Role,
                    LoadedAccounts[index].Naam,
                    edit,
                    LoadedAccounts[index].Loc,
                    LoadedAccounts[index].Sex,
                    LoadedAccounts[index].AvatarPath,
                    LoadedAccounts[index].Email
                    );
                return true;
            }
            error = "Beschrijving is niet correct!";
            return false;
        }

        /// <summary>
        /// Changes the user's role
        /// </summary>
        /// <param name="index">Index of the user as loaded</param>
        /// <param name="edit">The edit of the role</param>
        /// <param name="error">The error message</param>
        public bool ChangeAccountRole(int index, string edit, out string error)
        {
            error = "Niets ingevuld!";
            if (!string.IsNullOrWhiteSpace(edit))
            {
                Accounttype act;
                if (Enum.TryParse(edit, out act))
                {
                    Account.UpdateAdmin(
                        LoadedAccounts[index].AccountID,
                        act,
                        LoadedAccounts[index].Naam,
                        LoadedAccounts[index].Information,
                        LoadedAccounts[index].Loc,
                        LoadedAccounts[index].Sex,
                        LoadedAccounts[index].AvatarPath,
                        LoadedAccounts[index].Email
                        );
                    return true;
                }
            }
            error = "Rol is niet correct!";
            return false;
        }

        /// <summary>
        /// Changes the user's sex
        /// </summary>
        /// <param name="index">Index of the user as loaded</param>
        /// <param name="edit">The edit of the sex</param>
        /// <param name="error">The error message</param>
        public bool ChangeAccountSex(int index, string edit, out string error)
        {
            error = "Niets ingevuld!";
            if (!string.IsNullOrWhiteSpace(edit))
            {
                if (edit == "M" || edit == "F")
                {
                    Account.UpdateAdmin(
                        LoadedAccounts[index].AccountID,
                        LoadedAccounts[index].Role,
                        LoadedAccounts[index].Naam,
                        LoadedAccounts[index].Information,
                        LoadedAccounts[index].Loc,
                        edit,
                        LoadedAccounts[index].AvatarPath,
                        LoadedAccounts[index].Email
                        );
                    return true;
                }
            }
            error = "Geslacht is niet correct!";
            return false;
        }

        /// <summary>
        /// Changes the user's email
        /// </summary>
        /// <param name="index">Index of the user as loaded</param>
        /// <param name="edit">The edit of the email</param>
        /// <param name="error">The error message</param>
        public bool ChangeAccountEmail(int index, string edit, out string error)
        {
            error = "Niets ingevuld!";
            if (!string.IsNullOrWhiteSpace(edit))
            {
                Account.UpdateAdmin(
                    LoadedAccounts[index].AccountID,
                    LoadedAccounts[index].Role,
                    LoadedAccounts[index].Naam,
                    LoadedAccounts[index].Information,
                    LoadedAccounts[index].Loc,
                    LoadedAccounts[index].Sex,
                    LoadedAccounts[index].AvatarPath,
                    edit
                    );
                return true;
            }
            error = "email is niet correct!";
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

        /// <summary>
        /// Returns all the accounts of specified account type
        /// </summary>
        /// <param name="accType"></param>
        /// <returns></returns>
        public List<string> GetAccounts(string accType = "", bool bsearch = false, string search = "")
        {
            if (!String.IsNullOrWhiteSpace(accType))
            {
                if (bsearch)
                {
                    LoadedAccounts = Account.FetchAllAccounts().FindAll(item => (item.Role.ToString() == accType) && (item.Naam.ToLower()).Contains(search.ToLower()));
                    return LoadedAccounts.Select(s => s.Naam).ToList();
                }
                else
                {
                    LoadedAccounts = Account.FetchAllAccounts().FindAll(item => (item.Role.ToString() == accType));
                    return LoadedAccounts.Select(s => s.Naam).ToList();
                }
            }
            else
            {
                LoadedAccounts = Account.FetchAllAccounts();
                return LoadedAccounts.Select(s => s.Naam).ToList();
            }
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
        public string AccountData(int index, int userinfoindex)
        {
            return AllAccountData(LoadedAccounts[index])[userinfoindex - 1];
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password">given password of the user</param>
        /// <param name="ID">id number of the current user</param>
        /// <returns>a boolean that confirms if the password provided is correct with the original</returns>
        public bool CheckPass(string password)
        {
            string hash = Class_Layer.Account.GetPasswordHash(MainUser.AccountID);
            if ((hash == string.Empty) || (hash == "0"))
            {
                return false;
            }
            else
            {
                bool correct = Class_Layer.PasswordHashing.ValidatePassword(password, hash);
                return correct;
            }
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

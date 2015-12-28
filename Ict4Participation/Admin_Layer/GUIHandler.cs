//-----------------------------------------------------------------------
// <copyright file="GUIHandler.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Class_Layer;
using Class_Layer.Enums;

namespace Admin_Layer
{
    /// <summary>
    /// Communicates between the GUI and classes
    /// </summary>
    public class GUIHandler
    {
        /// <summary>
        /// The main user's account
        /// </summary>
        public Account MainUser;

        /// <summary>
        /// A list of loaded accounts
        /// </summary>
        private List<Account> LoadedAccounts;

        /// <summary>
        /// A list of all accounts
        /// </summary>
        private List<Account> AllAccounts;

        /// <summary>
        /// A list of loaded questions
        /// </summary>
        private List<Question> LoadedQuestions;

        /// <summary>
        /// A list of loaded comments
        /// </summary>
        private List<Comment> LoadedComments;

        /// <summary>
        /// A list of loaded reviews
        /// </summary>
        private List<Review> LoadedReviews;

        /// <summary>
        /// A list of loaded meetings
        /// </summary>
        private List<Meeting> LoadedMeetings;

        /// <summary>
        /// Initializes a new instance of the <see cref="Administration"/> class.
        /// </summary>
        public GUIHandler()
        {
            AllAccounts = new List<Account>();
            LoadedAccounts = new List<Account>();
            LoadedQuestions = new List<Question>();
            LoadedComments = new List<Comment>();
        }

        #region Account Handling

        /// <summary>
        /// Logs the user in with given credentials
        /// </summary>
        /// <param name="username">The username</param>
        /// <param name="password">The given password</param>
        /// <param name="message">The error message</param>
        /// <returns>Yields a true if the user could be logged in</returns>
        public bool LogIn(string username, string password, out string message)
        {
            message = string.Empty;
            //Fetch matching account
            if (string.IsNullOrEmpty(username))
            {
                message = "Email is niet ingevuld!";
                return false;
            }
            else if (string.IsNullOrEmpty(password))
            {
                message = "Wachtwoord is niet ingevuld!";
                return false;
            }
            else if (!Account.LogIn(username, password, out MainUser))
            {
                message = "De combinatie van email en wachtwoord bestaat niet!";
                return false;
            }
            return true;
        }

        /// <summary>
        /// Logs the last user out
        /// </summary>
        public void LogOut()
        {
            //Log user out
            Account.LogOut(MainUser);
            MainUser = null;
        }

        /// <summary>
        /// Registers a new account
        /// </summary>
        /// <param name="acc">The account details</param>
        /// <param name="message">The error message</param>
        /// <returns>Yields a true if the user could be created</returns>
        public bool Register(Accountdetails acc, string password1, string password2, out string message)
        {
            message = string.Empty;
            //Validate details
            if (!Check.CheckAccount(acc, out message))
            {
                return false;
            }
            if (password1 != password2)
            {
                message = "Wachtwoorden komen niet overeen!";
                return false;
            }
            //Register account
            MainUser = Account.Register(acc.Username, password1, acc.Email, acc.Name, acc.Address, acc.City, acc.Phonenumber,
                Convert.ToBoolean(acc.hasDriverLicense),
                Convert.ToBoolean(acc.hasVehicle),
                Convert.ToBoolean(acc.OVPossible), acc.Birthdate, acc.AvatarPath, acc.VOGPath, acc.Gender);
            //Send email
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            mail.From = new MailAddress("no-reply@plumbum.com");
            mail.To.Add(acc.Email);
            mail.Subject = "U hebt een account geregistreerd voor ICT4Participation";
            mail.Body = "Hallo!"
                + "\nU kunt nu registreren door middel van uw account:"
                + "\n" + acc.Username
                + "\nVoor vragen en contact kunt u het volgende emailadres mailen: s21mplumbum@gmail.com"
                + "\n"
                + " \nMet vriendelijke groet,"
                + "\nHet ICT4Participation-Team";

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("s21mplumbum@gmail.com", "Em72@Gmai111");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            return true;
        }

        public bool Validate(string password, string username, out string message)
        {
            message = String.Empty;
            //Return whether the username and password is a match
            Account no;
            bool validation = Account.LogIn(username, password, out no);
            if (validation == true)
            {
                message = "Account and password match";
            }
            else
            {
                message = "Account and password do not match";
            }
            return validation;
        }

        /// <summary>
        /// Get the details of a specified account, through its index
        /// </summary>
        /// <param name="all">Whether through a list of all the accounts should be searched</param>
        /// <param name="accountIndex">The index as specified in the list</param>
        /// <returns></returns>
        public Accountdetails GetInfo(bool all, int accountIndex)
        {
            return all ? (Accountdetails)Creation.getDetailsObject(AllAccounts[accountIndex])
                : (Accountdetails)Creation.getDetailsObject(LoadedAccounts[accountIndex]);
        }

        /// <summary>
        /// Searches through the list of accounts
        /// </summary>
        /// <param name="all">Specifies whether there is a search going through a smaller list or the full list</param>
        /// <param name="search">The account details to search by</param>
        /// <returns>The accounts that match</returns>
        public List<Accountdetails> Search(Accountdetails search, bool all = true)
        {
            //Search through all the accounts where the account-details match
            return Searcher.Detailed(LoadedAccounts, search);
        }

        /// <summary>
        /// Get all accounts and their matching details
        /// </summary>
        /// <returns>A list of the accounts with the details required</returns>
        public List<Accountdetails> GetAll()
        {
            //Get all the accounts and convert these to account-details objects. Then create a list out of these.
            LoadedAccounts = Account.GetAll();
            List<Accountdetails> returnable = LoadedAccounts.Select(acc => Creation.getDetailsObject(acc)).Cast<Accountdetails>().ToList();
            //Add skill list for every account
            //Add availability list for every account
            foreach (Accountdetails accd in returnable)
            {
                foreach (Account acc in LoadedAccounts)
                {
                    //Only if the ID's match
                    if (accd.ID == acc.ID)
                    {
                        //Add skills
                        foreach (Skill s in acc.Skills)
                        {
                            //As skilldetails
                            accd.SkillsDetailList.Add((Skilldetails)Creation.getDetailsObject(s));
                        }
                        //Add availability
                        foreach (Availability a in acc.Availability)
                        {
                            //As availabilitydetails
                            accd.AvailabilityDetailList.Add((Availabilitydetails)Creation.getDetailsObject(a));
                        }
                        break;
                    }
                }
            }
            return returnable;
        }

        /// <summary>
        /// Edits an account
        /// </summary>
        /// <param name="acc">The account details</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Edit(Accountdetails acc, string password1, string password2, out string message)
        {
            message = string.Empty;
            //Validate details
            if (!Check.CheckAccount(acc, out message))
            {
                return false;
            }
            //Update account
            if (password1 == password2)
            {
                Account.Update(MainUser.ID,
                    acc.Username,
                    password1,
                    acc.Email,
                    acc.Name,
                    acc.Address,
                    acc.City,
                    acc.Phonenumber,
                    Convert.ToBoolean(acc.hasDriverLicense),
                    Convert.ToBoolean(acc.hasVehicle),
                    Convert.ToBoolean(acc.OVPossible),
                    acc.Birthdate,
                    acc.AvatarPath,
                    acc.VOGPath,
                    acc.SkillsDetailList.Select(s => new Skill(MainUser.ID, s.Name)).Cast<Skill>().ToList(),
                    acc.AvailabilityDetailList.Select(a => new Availability(MainUser.ID, a.Day, a.Daytime)).Cast<Availability>().ToList(),
                    MainUser.Skills,
                    MainUser.Availability
                    );
                message = "Account edited";
                return true;
            }
            else
            {
                message = "Wachtwoorden komen niet overeen!";
                return false;
            }
        }
        #endregion

        #region Comment Handling
        /// <summary>
        /// Places a comment
        /// </summary>
        /// <param name="comment">The comment details</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Place(Commentdetails comment, out string message)
        {
            //Place comment
            Comment c = new Comment(0, comment.Description, MainUser.ID, comment.PostedToID, comment.PostDate);
            c.Create();
            message = "Comment placed";
            return true;
        }

        /// <summary>
        /// Edits a comment
        /// </summary>
        /// <param name="comment">The comment details</param>
        /// <param name="index">The index of the comment as loaded from the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Edit(Commentdetails comment, int commentIndex, out string message)
        {
            if (LoadedComments[commentIndex].PosterID == MainUser.ID)
            {
                //Edit comment
                message = "Comment aangepast";
                Comment c = new Comment(LoadedComments[commentIndex].PostID, comment.Description, MainUser.ID, comment.PostedToID, comment.PostDate);
                return true;
            }
            else
            {
                message = "U hebt geen rechten om deze comment aan te passen";
                return false;
            }
        }

        /// <summary>
        /// Removes a comment
        /// </summary>
        /// <param name="commentIndex">The index of the comment as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Remove(int commentIndex, out string message)
        {
            if (LoadedComments[commentIndex].PosterID == MainUser.ID)
            {
                //Remove comment
                LoadedComments[commentIndex].Delete();
                message = "Comment verwijderd!";
                return true;
            }
            else
            {
                message = "U hebt geen rechten om deze comment te verwijderen";
                return false;
            }
        }

        /// <summary>
        /// Gets all the comments belonging to a question
        /// </summary>
        /// <param name="questionID">The ID of specified question</param>
        /// <returns>A list of all the comments</returns>
        public List<Commentdetails> GetAll(int questionID)
        {
            //Fetch all the comments matching for this question
            LoadedComments = Comment.GetAll(questionID);
            return LoadedComments.Select(com => Creation.getDetailsObject(com)).Cast<Commentdetails>().ToList();
        }
        #endregion

        #region Question Handling
        /// <summary>
        /// Load in questions
        /// </summary>
        /// <param name="all">Whether all the questions should be loaded, or the main users</param>
        /// <returns>A list of all the details regarding the questions</returns>
        public List<Questiondetails> GetAll(bool all)
        {
            //Load in questions
            LoadedQuestions = all ? Question.GetAll(null) : Question.GetAll(MainUser.ID);
            //Return all questions
            return LoadedQuestions.Cast<Question>().Select(x => Creation.getDetailsObject(x)).Cast<Questiondetails>().ToList();
        }

        /// <summary>
        /// Searches through the list of questions
        /// </summary>
        /// <param name="all">Specifies whether there is a search going through a smaller list or the full list</param>
        /// <param name="search">The question details to search by</param>
        /// <returns>The questions that match</returns>
        public List<Questiondetails> Search(Questiondetails search, bool all = true)
        {
            //Search through the questions
            return Searcher.Detailed(LoadedQuestions, search);
        }

        /// <summary>
        /// Places a question
        /// </summary>
        /// <param name="question">The question details</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Place(Questiondetails question, out string message)
        {
            //Check for rights
            if (MainUser.Role == Accounttype.Hulpbehoevende)
            {
                // Validate details
                if (string.IsNullOrEmpty(question.Title))
                {
                    message = "Voer een geldige titel in!";
                    return false;
                }
                if (string.IsNullOrEmpty(question.Description))
                {
                    message = "Voer een geldige beschrijving in!";
                    return false;
                }
                if (question.Skills.Count == 0)
                {
                    message = "Geen skills toegevoegd!";
                    return false;
                }
                if (string.IsNullOrEmpty(question.Location))
                {
                    message = "Voer een geldige locatie in!";
                    return false;
                }
                DateTime? Now = DateTime.Now;
                if (question.StartDate < Now)
                {
                    message = "De startdatum is al geweest!";
                    return false;
                }
                if (question.EndDate < Now)
                {
                    message = "De einddatum is al geweest!";
                    return false;
                }
                if (question.AmountAccs < 0)
                {
                    message = "Het maximaal aantal hulpverleners is te laag!";
                    return false;
                }
                if (question.AmountAccs > 8)
                {
                    message = "Het maximaal aantal hulpverleners is te hoog!";
                    return false;
                }

                //Place question
                Question q = new Question(0, MainUser.ID, question.Title, question.StartDate, question.EndDate, question.Description, question.Urgent, question.Location, question.AmountAccs, question.Skills, new List<int>());
                q.Create();
                message = "Vraag gepost!";
                return true;
            }
            else
            {
                message = "U hebt niet de rechten om een vraag te plaatsen";
                return false;
            }
        }

        /// <summary>
        /// Edits a question
        /// </summary>
        /// <param name="question">The question details</param>
        /// <param name="questionIndex">The index of the question as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Edit(Questiondetails question, int questionIndex, out string message)
        {
            //Check for rights
            if (LoadedQuestions[questionIndex].PosterID == MainUser.ID)
            {
                if (!Check.QuestionDetails(question, out message))
                {
                    return false;
                }

                //Edit question
                Question q = new Question(LoadedQuestions[questionIndex].PostID, MainUser.ID, question.Title, question.StartDate, question.EndDate, question.Description, question.Urgent, question.Location, question.AmountAccs, question.Skills, LoadedQuestions[questionIndex].Volunteers);
                q.Update();
                message = "Vraag succesvol aangepast!";
                return true;

            }
            else
            {
                message = "U hebt niet de rechten om deze vraag aan te passen";
                return false;
            }
        }

        /// <summary>
        /// Removes a question
        /// </summary>
        /// <param name="questionIndex">The index of the question as loaded</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool RemoveQuestion(int questionIndex, out string message)
        {
            //Check for rights
            if (LoadedQuestions[questionIndex].PosterID == MainUser.ID)
            {
                //Remove question
                LoadedQuestions[questionIndex].Delete();
                message = "Question deleted";
                return true;
            }
            else
            {
                message = "U hebt niet de rechten om deze vraag aan te passen";
                return false;
            }
        }
        #endregion

        #region Review Handling
        /// <summary>
        /// Gets all the reviews from a user
        /// </summary>
        /// <param name="userid">The userID of the user</param>
        /// <param name="isPoster">Whether the user has posted the reviews, or received them</param>
        /// <returns>A list regarding all the details of the reviews</returns>
        public List<Reviewdetails> GetAllReviews(int userid, bool isPoster = false)
        {
            LoadedReviews = Review.GetAll(userid, isPoster);
            return LoadedReviews.Select(r => Creation.getDetailsObject(r)).Cast<Reviewdetails>().ToList();
        }

        /// <summary>
        /// Places a review
        /// </summary>
        /// <param name="review">The review details</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Place(Reviewdetails review, out string message)
        {
            if (MainUser.ID != review.PostedToID)
            {
                //Place review
                Review r = new Review(0, review.Rating, MainUser.ID, review.PostedToID, review.Description);
                r.Create();
                message = "Review succesvol geplaatst";
                return true;
            }
            else
            {
                message = "Het is niet mogelijk om een review te plaatsen op uzelf!";
                return false;
            }
        }

        /// <summary>
        /// Edits a review
        /// </summary>
        /// <param name="review">The review details</param>
        /// <param name="reviewIndex">The index of the review as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Edit(Reviewdetails review, int reviewIndex, out string message)
        {
            if (LoadedReviews[reviewIndex].PosterID == MainUser.ID)
            {
                //TODO: validate details
                //Edit review
                Review r = new Review(LoadedReviews[reviewIndex].PostID, review.Rating, MainUser.ID, review.PostedToID, review.Description);
                r.Update();
                message = "Review aangepast!";
                return true;
            }
            else
            {
                message = "U hebt niet de rechten om deze review aan te passen";
                return false;
            }
        }

        /// <summary>
        /// Removes a review
        /// </summary>
        /// <param name="reviewIndex">The index of the review as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool RemoveReview(int reviewIndex, out string message)
        {
            if (LoadedReviews[reviewIndex].PosterID == MainUser.ID)
            {
                //Remove review
                LoadedReviews[reviewIndex].Delete();
                message = "Review verwijderd";
                return true;
            }
            else
            {
                message = "U hebt niet de rechten om deze review aan te passen";
                return false;
            }
        }
        #endregion

        #region Meeting Handling
        /// <summary>
        /// Get all meetings planned in for the main user
        /// </summary>
        /// <returns>All details regarding these meetings</returns>
        public List<Meetingdetails> GetAllMeetings()
        {
            LoadedMeetings = Meeting.GetAll(MainUser.ID);
            return LoadedMeetings.Select(meeting => Creation.getDetailsObject(meeting)).Cast<Meetingdetails>().ToList();
        }

        /// <summary>
        /// Edits a meeting
        /// </summary>
        /// <param name="meeting">The details of the meeting</param>
        /// <param name="meetingIndex">The index of the meeting, as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Edit(Meetingdetails meeting, int meetingIndex, out string message)
        {
            //Check for rights
            if (meeting.RequestedID != MainUser.ID)
            {
                //Edit meeting
                Meeting m = new Meeting(LoadedMeetings[meetingIndex].PostID, meeting.RequestedID, meeting.RequesterID, meeting.StartDate, meeting.EndDate, meeting.Location);
                m.Update();
                message = "Meeting aangepast";
                return true;
            }
            else
            {
                message = "U kunt geen meeting aanmaken met uzelf";
                return false;
            }
        }

        /// <summary>
        /// Creates a meeting
        /// </summary>
        /// <param name="meeting">The details of the meeting</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Create(Meetingdetails meeting, out string message)
        {
            //Check user
            if (meeting.RequestedID != MainUser.ID)
            {
                //Create meeting
                Meeting m = new Meeting(0, meeting.RequestedID, meeting.RequesterID, meeting.StartDate, meeting.EndDate, meeting.Location);
                m.Create();
                message = "Meeting aangemaakt!";
                return true;
            }
            else
            {
                message = "U kunt geen meeting aanmaken met uzelf";
                return false;
            }
        }

        /// <summary>
        /// Removes a meeting
        /// </summary>
        /// <param name="meetingIndex">The index as loaded in the meeting list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool RemoveMeeting(int meetingIndex, out string message)
        {
            if (LoadedMeetings[meetingIndex].PosterID == MainUser.ID && LoadedMeetings[meetingIndex].RequesterID == MainUser.ID)
            {
                //Remove meeting
                LoadedMeetings[meetingIndex].Delete();
                message = "Meeting verwijderd";
                return true;
            }
            else
            {
                message = "U hebt geen rechten om deze meeting te verwijderen";
                return false;
            }
        }
        #endregion

        #region Skill Handling
        /// <summary>
        /// Gets all the skills belonging to a user
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        /// <returns>A list of all the user's specified skills</returns>
        public List<Skilldetails> GetAllSkills(Nullable<int> userID = null)
        {
            //Get a list of all the demanded skills and convert these to the usable skillDetails, then create a list out of this.
            return Skill.GetAll(userID).Select(skill => Creation.getDetailsObject(skill)).Cast<Skilldetails>().ToList();
        }

        /// <summary>
        /// Removes a skill from the main user
        /// </summary>
        /// <param name="name">The name of the skill</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool RemoveSkill(string name, out string message)
        {
            Skill s = new Skill(MainUser.ID, name);
            s.Remove();
            message = "Skill removed";
            return true;
        }

        /// <summary>
        /// Adds a skill to the main user
        /// </summary>
        /// <param name="name">The name of the skill</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool AddSkill(string name, out string message)
        {
            Skill s = new Skill(MainUser.ID, name);
            s.Add();
            message = "Skill added";
            return true;
        }
        #endregion

        #region Availability Handling
        /// <summary>
        /// Gets all the availability of a user
        /// </summary>
        /// <param name="userid">The ID of the user</param>
        /// <returns>A list of the availability</returns>
        public List<Availabilitydetails> GetAllAvailabilities(int userid)
        {
            //Load in all the availabilities of a specified user 
            return Availability.GetAll(userid).Select(av => Creation.getDetailsObject(av)).Cast<Availabilitydetails>().ToList();
        }

        /// <summary>
        /// Removes availability from the main user
        /// </summary>
        /// <param name="av">The details of the availability</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool RemoveAvailability(Availabilitydetails av, out string message)
        {
            Availability a = new Availability(MainUser.ID, av.Day, av.Daytime);
            a.Remove();
            message = "Availability added";
            return true;
        }

        /// <summary>
        /// Adds availability to the main user
        /// </summary>
        /// <param name="av">The details of the availability</param>
        /// <param name="message">The message of the error</param>
        /// <returns></returns>
        public bool AddAvailability(Availabilitydetails av, out string message)
        {
            Availability a = new Availability(MainUser.ID, av.Day, av.Daytime);
            a.Add();
            message = "Availability added";
            return true;
        }
        #endregion

        #region Download Handling

        public bool Download(System.Web.UI.WebControls.FileUpload File1, out string message)
        {
            //Data storage
            string
                SaveLocation,
                fn = System.IO.Path.GetFileName(File1.PostedFile.FileName),
                loc,
                //Filename
                file = File1.PostedFile.FileName;

            //Get extension
            string ext = "." + file.Split('.').Last();

            //If it's a PDF, upload to the folder called "ProfileVOG_Unvalidated"
            if (ext.ToLower() == ".pdf")
            {
                loc = "ProfileVOGs_Unvalidated";
            }
            //Else it's an image, so upload to the folder called "ProfileAvatars"
            else
            {
                loc = "ProfileAvatars";
            }
            string appPath = System.Web.HttpContext.Current.Request.ApplicationPath;
            string physicalPath = System.Web.HttpContext.Current.Request.MapPath(appPath);
            SaveLocation =  physicalPath + loc + "\\" + MainUser.ID + ext;
            try
            {
                File1.PostedFile.SaveAs(SaveLocation);
                message = "The file has been uploaded.";
                return true;
            }
            catch (Exception ex)
            {
                message = "Error: " + ex.Message;
                return false;
            }

            throw new NotSupportedException();
        }

        #endregion

        /// <summary>
        /// If the GUI is unloaded, log the user out
        /// </summary>
        ~GUIHandler()
        {
            Console.WriteLine("User log out state entered. Check if true!");
            //LogOut();
        }







        // Extra methodes


        /// <summary>
        /// Check if the user is logged in
        /// </summary>
        /// <returns>Returns true if a mainuser has been found, and false if mainuser is null</returns>
        public bool UserIsLoggedIn()
        {
            if (MainUser == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the main user information, including skills and availability
        /// </summary>
        /// <returns>the main user information</returns>
        public Accountdetails GetMainuserInfo()
        {
            Accountdetails acc = (Accountdetails)Creation.getDetailsObject(MainUser);

            foreach (Skill s in MainUser.Skills)
            {
                acc.SkillsDetailList.Add((Skilldetails)Creation.getDetailsObject(s));
            }

            foreach (Availability a in MainUser.Availability)
            {
                acc.AvailabilityDetailList.Add((Availabilitydetails)Creation.getDetailsObject(a));
            }

            return acc;
        }
    }
}

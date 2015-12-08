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
    class GUIHandler
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
            message = String.Empty;
            //Fetch matching account
            if (!Account.LogIn(username, password, out MainUser))
            {
                message = "Gebruikersnaam en wachtwoord komen niet overeen!";
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
        public bool Register(Accountdetails acc, out string message)
        {
            message = String.Empty;
            //TODO
            //Validate details
            if (!Check.Birthday(acc.Birthdate))
            {
                message = "Verjaardag is fout ingegeven.";
                return false;
            }
            if (!Check.Name(acc.Name))
            {
                message = "Naam is fout ingegeven. \r\nDeze mag geen nummers of speciale tekens bevatten!";
                return false;
            }
            if (!Check.LiteralUsername(acc.Username))
            {
                message = "Gebruikersnaam is fout ingegeven. \r\nUw gebruikersnaam mag geen speciale tekens bevatten!";
                return false;
            }
            if (!Check.Phonenumber(acc.Phonenumber))
            {
                message = "Telefoonnummer is fout ingegeven. \r\nUw telefoon voldoet niet aan ons format: \r\nProbeer: XXX-XXX-XXXX";
                return false;
            }
            if (acc.VOGPath != null)
            {
                if (!Check.isOfFileExt(acc.VOGPath, ".pdf"))
                {
                    message = "Uw VOG is geen pdf.";
                    return false;
                }
            }
            if (!Check.isImage(acc.AvatarPath))
            {
                message = "Uw avatar is geen afbeelding.";
                return false;
            }
            if (!Check.isLocation(acc.City, acc.Address))
            {
                message = "Uw locatie kon niet gevonden worden.";
                return false;
            }
            if (!Check.isEmail(acc.Email))
            {
                message = "Uw email kon niet gevonden worden.";
                return false;
            }

            //Register account
            //Account.Register();
            return false;
        }

        public bool Validate(string password, string username, out string message)
        {
            //TODO
            //Return whether the username and password is a match
            message = "Not implemented";
            return false;
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

        public List<Accountdetails> Search(bool all, Accountdetails search)
        {
            //TODO
            //Search through all the accounts where the accountdetails match
            return null;
        }

        /// <summary>
        /// Get all accounts and their matching details
        /// </summary>
        /// <returns>A list of the accounts with the details required</returns>
        public List<Accountdetails> GetAll()
        {
            //Get all the accounts and convert these to accountdetails objects. Then create a list out of these.
            AllAccounts = Account.GetAll();
            return AllAccounts.Select(acc => Creation.getDetailsObject(acc)).Cast<Accountdetails>().ToList();
        }

        public bool Edit(Accountdetails acc, out string message)
        {
            //TODO
            //Update account
            //Account updatedAccount = new Account(MainUser ID... acc stuff)
            message = "Not implemented";
            return false;
        }
        #endregion

        #region Comment Handling
        public Nullable<Commentdetails> GetCommentInfo(int commentID)
        {
            //TODO
            //Fetch comment details from commentID
            return null;
        }

        public bool Place(Commentdetails comment, out string message)
        {
            //Place comment
            Comment c = new Comment(0, comment.Description, MainUser.ID, comment.PostedToID, comment.PostDate);
            c.Create();
            message = "Comment placed";
            return true;
        }

        public bool Edit(Commentdetails comment, int index, out string message)
        {
            //Edit comment
            message = "Comment edited";
            Comment c = new Comment(LoadedComments[index].PostID, comment.Description, MainUser.ID, comment.PostedToID, comment.PostDate);
            return true;
        }

        public bool Remove(int commentIndex, out string message)
        {
            //Remove comment
            LoadedComments[commentIndex].Delete();
            message = "Comment removed";
            return true;
        }

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
            if (!all)
            {
                LoadedQuestions = Question.GetAll(MainUser.ID);
            }
            else
            {
                LoadedQuestions = Question.GetAll(null);
            }
            //Return all questions
            return LoadedQuestions.Cast<Question>().Select(x => Creation.getDetailsObject(x)).Cast<Questiondetails>().ToList();
        }

        public Nullable<Questiondetails> GetQuestionInfo(int questionIndex)
        {
            //TODO
            //Return information from a question that is loaded
            return null;
        }

        public bool Place(Questiondetails question, out string message)
        {
            //Place question
            Question q = new Question(0, MainUser.ID, question.Title, question.StartDate, question.EndDate, question.Description, question.Urgent, question.Location, question.AmountAccs, question.Skills);
            q.Create();
            message = "Question placed";
            return true;
        }

        public bool Edit(Questiondetails question, int questionIndex, out string message)
        {
            //Edit question
            Question q = new Question(LoadedQuestions[questionIndex].PostID, MainUser.ID, question.Title, question.StartDate, question.EndDate, question.Description, question.Urgent, question.Location, question.AmountAccs, question.Skills);
            q.Update();
            message = "Question updated";
            return true;
        }

        public bool RemoveQuestion(int questionIndex, out string message)
        {
            //Remove question
            LoadedQuestions[questionIndex].Delete();
            message = "Question deleted";
            return true;
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

        public Nullable<Reviewdetails> GetReviewInfo(int reviewIndex)
        {
            //TODO
            //Return all the details about specified review
            return null;
        }

        public bool Place(Reviewdetails review, out string message)
        {
            //Place review
            Review r = new Review(0, review.Rating, MainUser.ID, review.PostedToID, review.Description);
            r.Create();
            message = "Review placed";
            return true;
        }

        public bool Edit(Reviewdetails review, int reviewIndex, out string message)
        {
            //Edit review
            Review r = new Review(LoadedReviews[reviewIndex].PostID, review.Rating, MainUser.ID, review.PostedToID, review.Description);
            r.Update();
            message = "Review updated";
            return true;
        }

        public bool RemoveReview(int reviewIndex, out string message)
        {
            //Remove review
            LoadedReviews[reviewIndex].Delete();
            message = "Review removed";
            return true;
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

        public Nullable<Meetingdetails> GetMeetingInfo(int meetingindex)
        {
            //TODO
            //Return the details of a meeting
            return null;
        }

        public bool Edit(Meetingdetails meeting, int meetingIndex, out string message)
        {
            //Edit meeting
            Meeting m = new Meeting(LoadedMeetings[meetingIndex].PostID, meeting.RequestedID, meeting.RequesterID, meeting.StartDate, meeting.EndDate, meeting.Location);
            m.Update();
            message = "Meeting updated";
            return true;
        }

        public bool Create(Meetingdetails meeting, out string message)
        {
            //Create meeting
            Meeting m = new Meeting(0, meeting.RequestedID, meeting.RequesterID, meeting.StartDate, meeting.EndDate, meeting.Location);
            m.Create();
            message = "Meeting created";
            return true;
        }

        public bool RemoveMeeting(int meetingIndex, out string message)
        {
            //Remove meeting
            LoadedMeetings[meetingIndex].Delete();
            message = "Meeting removed";
            return true;
        }
        #endregion

        #region Skill Handling
        //TODO
        //Add Skill class
        //Use this class to load in all unique skills

        //GETALL
        //ADD
        //REMOVE
        #endregion

        #region Availability Handling
        //TODO
        //Add Availability class
        //Use this class to load in all the availability of specified account

        //GETALL
        //ADD (details)
        //REMOVE (details)
        #endregion
    }
}

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
        /// The last loaded ID
        /// </summary>
        private int lastloadedOPID;

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

        public bool LogIn(string username, string password, out string message)
        {
            //TODO
            //Fetch matching account
            message = "Not implemented";
            return false;
        }

        public void LogOut()
        {
            //TODO
            //Log user out
        }

        public bool Register(Accountdetails acc, out string message)
        {
            //TODO
            //Validate details
            //Register account
            message = "Not implemented";
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
            message = "Not implemented";
            return false;
        }
        #endregion

        #region Comment Handling
        public Nullable<Commentdetails> GetInfo(int commentID)
        {
            //TODO
            //Fetch comment details from commentID
            return null;
        }

        public bool Place(Commentdetails comment, out string message)
        {
            //TODO
            //Place comment
            message = "Not implemented";
            return false;
        }

        public bool Edit(Commentdetails comment, out string message)
        {
            //TODO
            //Edit comment
            message = "Not implemented";
            return false;
        }

        public bool Remove(int commentIndex, out string message)
        {
            //TODO
            //Remove comment
            message = "Not implemented";
            return false;
        }

        public List<Commentdetails> GetAll(int questionID)
        {
            //TODO
            //Fetch all the comments matching for this question
            return null;
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
            //TODO
            //Place question
            message = "Not implemented";
            return false;
        }

        public bool Edit(Questiondetails question, out string message)
        {
            //TODO
            //Edit question
            message = "Not implemented";
            return false;
        }

        public bool RemoveQuestion(int questionIndex, out string message)
        {
            //TODO
            //Remove question
            message = "Not implemented";
            return false;
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
            LoadedReviews = Review.GetAll(userid,isPoster);
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
            //TODO
            //Place review
            message = "Not implemented";
            return false;
        }

        public bool Edit(Reviewdetails review, out string message)
        {
            //TODO
            //Edit review
            message = "Not implemented";
            return false;
        }

        public bool RemoveReview(int reviewIndex, out string message)
        {
            //TODO
            //Remove review
            message = "Not implemented";
            return false;
        }
        #endregion

        #region Meeting Handling
        /// <summary>
        /// Get all meetings planned in for the main user
        /// </summary>
        /// <returns>All details regarding these meetings</returns>
        public List<Meetingdetails> GetAllMeetings()
        {
            return Meeting.GetAll(MainUser.ID).Select(meeting => Creation.getDetailsObject(meeting)).Cast<Meetingdetails>().ToList();
        }

        public Nullable<Meetingdetails> GetMeetingInfo(int meetingindex)
        {
            //TODO
            //Return the details of a meeting
            return null;
        }

        public bool Edit(Meetingdetails meeting, out string message)
        {
            //TODO
            //Edit meeting
            message = "Not implemented";
            return false;
        }

        public bool Create(Meetingdetails meeting, out string message)
        {
            //TODO
            //Create meeting
            message = "Not implemented";
            return false;
        }

        public bool RemoveMeeting(int meetingIndex, out string message)
        {
            //TODO
            //Remove meeting
            message = "Not implemented";
            return false;
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

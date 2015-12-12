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
                Convert.ToBoolean(acc.OVPossible), acc.Birthdate, acc.AvatarPath, acc.VOGPath);
            //TODO
            //Send email
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
        public List<Accountdetails> Search(bool all, Accountdetails search)
        {
            //Search through all the accounts where the account-details match
            return LoadedAccounts.Where(
                av => av.Address.Contains(search.Address) &&
                av.Username.Contains(search.Username) &&
                av.Name.Contains(search.Name) &&
                av.Email.Contains(search.Email) &&
                av.City.Contains(search.City) &&
                av.Phonenumber.Contains(search.Phonenumber) &&
                (search.hasDriverLicense != null ? av.hasDriverLicense == search.hasDriverLicense : av.hasDriverLicense != search.hasDriverLicense) && //If null, return both true and false
                (search.hasVehicle != null ? av.hasVehicle == search.hasVehicle : av.hasVehicle != search.hasVehicle) && //If null, return both true and false
                (search.OVPossible != null ? av.OVPossible == search.OVPossible : av.OVPossible != search.OVPossible) //If null, return both true and false
                ).Select(av => Creation.getDetailsObject(av))
                .Cast<Accountdetails>().ToList();
        }

        /// <summary>
        /// Get all accounts and their matching details
        /// </summary>
        /// <returns>A list of the accounts with the details required</returns>
        public List<Accountdetails> GetAll()
        {
            //Get all the accounts and convert these to account-details objects. Then create a list out of these.
            LoadedAccounts = Account.GetAll();
            return LoadedAccounts.Select(acc => Creation.getDetailsObject(acc)).Cast<Accountdetails>().ToList();
        }

        /// <summary>
        /// Edits an account
        /// </summary>
        /// <param name="acc">The account details</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Edit(Accountdetails acc, string password1, string password2, out string message)
        {
            //TODO
            //Validate details
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
        public bool Edit(Commentdetails comment, int index, out string message)
        {
            //Edit comment
            message = "Comment edited";
            Comment c = new Comment(LoadedComments[index].PostID, comment.Description, MainUser.ID, comment.PostedToID, comment.PostDate);
            return true;
        }

        /// <summary>
        /// Removes a comment
        /// </summary>
        /// <param name="commentIndex">The index of the comment as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Remove(int commentIndex, out string message)
        {
            //Remove comment
            LoadedComments[commentIndex].Delete();
            message = "Comment removed";
            return true;
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

        /// <summary>
        /// Places a question
        /// </summary>
        /// <param name="question">The question details</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Place(Questiondetails question, out string message)
        {
            //TODO: Validate details, check for rights
            //Place question
            Question q = new Question(0, MainUser.ID, question.Title, question.StartDate, question.EndDate, question.Description, question.Urgent, question.Location, question.AmountAccs, question.Skills, new List<int>());
            q.Create();
            message = "Question placed";
            return true;
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
            //TODO: Validate details, check for rights
            //Edit question
            Question q = new Question(LoadedQuestions[questionIndex].PostID, MainUser.ID, question.Title, question.StartDate, question.EndDate, question.Description, question.Urgent, question.Location, question.AmountAccs, question.Skills, LoadedQuestions[questionIndex].Volunteers);
            q.Update();
            message = "Question updated";
            return true;
        }

        /// <summary>
        /// Removes a question
        /// </summary>
        /// <param name="questionIndex">The index of the question as loaded</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool RemoveQuestion(int questionIndex, out string message)
        {
            //TODO: check for rights
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

        /// <summary>
        /// Places a review
        /// </summary>
        /// <param name="review">The review details</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Place(Reviewdetails review, out string message)
        {
            //TODO: Check user
            //Place review
            Review r = new Review(0, review.Rating, MainUser.ID, review.PostedToID, review.Description);
            r.Create();
            message = "Review placed";
            return true;
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
            //TODO: check for rights
            //Edit review
            Review r = new Review(LoadedReviews[reviewIndex].PostID, review.Rating, MainUser.ID, review.PostedToID, review.Description);
            r.Update();
            message = "Review updated";
            return true;
        }

        /// <summary>
        /// Removes a review
        /// </summary>
        /// <param name="reviewIndex">The index of the review as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool RemoveReview(int reviewIndex, out string message)
        {
            //TODO: check for rights
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

        /// <summary>
        /// Edits a meeting
        /// </summary>
        /// <param name="meeting">The details of the meeting</param>
        /// <param name="meetingIndex">The index of the meeting, as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Edit(Meetingdetails meeting, int meetingIndex, out string message)
        {
            //TODO: check for rights
            //Edit meeting
            Meeting m = new Meeting(LoadedMeetings[meetingIndex].PostID, meeting.RequestedID, meeting.RequesterID, meeting.StartDate, meeting.EndDate, meeting.Location);
            m.Update();
            message = "Meeting updated";
            return true;
        }

        /// <summary>
        /// Creates a meeting
        /// </summary>
        /// <param name="meeting">The details of the meeting</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Create(Meetingdetails meeting, out string message)
        {
            //TODO: check user
            //Create meeting
            Meeting m = new Meeting(0, meeting.RequestedID, meeting.RequesterID, meeting.StartDate, meeting.EndDate, meeting.Location);
            m.Create();
            message = "Meeting created";
            return true;
        }

        /// <summary>
        /// Removes a meeting
        /// </summary>
        /// <param name="meetingIndex">The index as loaded in the meeting list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool RemoveMeeting(int meetingIndex, out string message)
        {
            //Remove meeting
            LoadedMeetings[meetingIndex].Delete();
            message = "Meeting removed";
            return true;
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

        /// <summary>
        /// If the GUI is unloaded, log the user out
        /// </summary>
        ~GUIHandler() 
        {
            Console.WriteLine("User log out state entered. Check if true!");
            //LogOut();
        }
    }
}

//-----------------------------------------------------------------------
// <copyright file="AdminGUIHandler.cs" company="ICT4Participation">
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
    public class AdminGUIHandler
    {
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
        public List<Question> LoadedQuestions;

        /// <summary>
        /// A list of loaded comments
        /// </summary>
        private List<Comment> LoadedComments;

        /// <summary>
        /// A list of loaded reviews
        /// </summary>
        private List<Review> LoadedReviews;

        /// <summary>
        /// Initializes a new instance of the <see cref="Administration"/> class.
        /// </summary>
        public AdminGUIHandler()
        {
            AllAccounts = new List<Account>();
            LoadedAccounts = new List<Account>();
            LoadedQuestions = new List<Question>();
            LoadedComments = new List<Comment>();
        }

        #region Account Handling
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
            return Searcher.Global(LoadedAccounts, search.Name);
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
        /// <para>Make sure the Skills in the account details are filled in, and have a userID</para>
        /// <para>Make sure the Availability in the account details are filled in, and have a userID</para>
        /// </summary>
        /// <param name="acc">The account details</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Edit(Accountdetails acc, out string message, int userID, string password1 = "", string password2 = "")
        {
            message = string.Empty;
            //Validate details
            if (!Check.CheckAccount(acc, out message, true))
            {
                return false;
            }
            //Find account
            Account FoundAcc = LoadedAccounts.Where(user => user.ID == userID).First();

            //Update account
            if (password1 == password2)
            {
                Account.Update(userID,
                    acc.Username,
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
                    acc.Gender,
                    acc.SkillsDetailList.Select(s => new Skill(userID, s.Name)).Cast<Skill>().ToList(),
                    acc.AvailabilityDetailList.Select(a => new Availability(userID, a.Day, a.Daytime)).Cast<Availability>().ToList(),
                    FoundAcc.Skills,
                    FoundAcc.Availability,
                    password1
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

        /// <summary>
        /// Deactivated specified account
        /// </summary>
        /// <param name="ID">The ID of the account</param>
        public void DeactivateAccount(int ID, string email, string username, string reason)
        {
            Account.SetInactive(ID);
            EmailHandler.SendDeactivation(email, username, reason);
        }

        #endregion

        #region Comment Handling
        /// <summary>
        /// Edits a comment
        /// </summary>
        /// <param name="comment">The comment details</param>
        /// <param name="index">The index of the comment as loaded from the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Edit(Commentdetails comment, int userID , int commentID, out string message)
        {
            //Edit comment
            message = "Comment aangepast";
            Comment c = new Comment(commentID, comment.Description, userID, comment.PostedToID, false, comment.PostDate);
            c.Update();
            return true;
        }

        /// <summary>
        /// Removes a comment
        /// </summary>
        /// <param name="commentIndex">The index of the comment as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Remove(int commentID, string email, string question, string reason, out string message)
        {
            //Remove comment
            LoadedComments.Where(c => c.PostID == commentID).First().Delete();
            EmailHandler.SendWrongComment(email, question, reason);
            message = "Comment verwijderd!";
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
        public List<Questiondetails> GetAll(bool all = true)
        {
            //Load in questions
            LoadedQuestions = all ? Question.GetAll(null) : Question.GetAll(null);
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
        /// Edits a question
        /// </summary>
        /// <param name="question">The question details</param>
        /// <param name="questionIndex">The index of the question as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Edit(Questiondetails question, int questionID, int userID , out string message)
        {
            if (!Check.QuestionDetails(question, out message, true))
            {
                return false;
            }
            Class_Layer.Enums.Status status;
            Enum.TryParse(question.Status, out status);

            //Edit question
            Question q = new Question(questionID, userID, question.Title, question.StartDate, question.EndDate, question.Description, question.Urgent, question.Location, question.AmountAccs, question.Skills, LoadedQuestions.Where(qe=>qe.PostID == questionID).First().Volunteers, (int)status);
            if (!q.Update())
            {
                message = "Er ging iets fout, debug.";
            }
            return true;
        }

        /// <summary>
        /// Removes a question
        /// </summary>
        /// <param name="questionIndex">The index of the question as loaded</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool RemoveQuestion(int questionID, string email, string question, string reason, out string message)
        {
            //Remove question
            LoadedQuestions.Where(q=>q.PostID == questionID).First().Delete();
            //Send message
            EmailHandler.SendWrongQuestion(email, question, reason);
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
        /// Edits a review
        /// </summary>
        /// <param name="review">The review details</param>
        /// <param name="reviewIndex">The index of the review as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool Edit(Reviewdetails review, int reviewID, int userID, out string message)
        {
            //TODO: validate details
            //Edit review
            Review r = new Review(reviewID, review.Rating, userID, review.PostedToID, review.Description);
            r.Update();
            message = "Review aangepast!";
            return true;
        }

        /// <summary>
        /// Removes a review
        /// </summary>
        /// <param name="reviewIndex">The index of the review as loaded in the list</param>
        /// <param name="message">The message of the error</param>
        /// <returns>Success</returns>
        public bool RemoveReview(int reviewID, string email, string username, string reason, out string message)
        {
            //Remove review
            LoadedReviews.Where(r => r.PostID == reviewID).First().Delete();
            //Email user
            EmailHandler.SendWrongReview(email, username, reason);
            message = "Review verwijderd";
            return true;
        }
        #endregion
    }
}

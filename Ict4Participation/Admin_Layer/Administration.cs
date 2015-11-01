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

        /// <summary>
        /// Initializes a new instance of the <see cref="Administration"/> class.
        /// </summary>
        public Administration()
        {
            // Implement
        }

        /// <summary>
        /// Creates a new account
        /// </summary>
        /// <returns>Returns the result of the action</returns>
        public bool MaakAccount()
        {
            return false;
        }

        /// <summary>
        /// Adds account to list
        /// </summary>
        /// <returns>Returns the result of the action</returns>
        public bool VoegAccountToe()
        {
            return false;
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
        public bool PostQuestion()
        {
            return false;
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

        public List<string> getAccounttypes()
        {
            return Enum.GetNames(typeof(Accounttype)).ToList();
        }


        //testmethod voor database
        static public bool testDatabase()
        {
            return Account.testdatabase();
        }
    }
}

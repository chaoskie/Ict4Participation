//-----------------------------------------------------------------------
// <copyright file="QuestionAccount.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
namespace Class_Layer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Database_Layer;

    /// <summary>
    /// The <see cref="QuestionAccount"/> class is used to store the questions of an account.
    /// </summary>
    public class QuestionAccount
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestionAccount"/> class.
        /// </summary>
        /// <param name="accID">The ID of the account.</param>
        /// <param name="queID">The ID of the question.</param>
        /// <param name="acceptionDate">The acceptation date.</param>
        private QuestionAccount(int accID, int queID, DateTime acceptionDate)
        {
            this.AccID = accID;
            this.QueID = queID;
            this.AcceptionDate = acceptionDate;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the id of the account of the <see cref="QuestionAccount"/> object.
        /// </summary>
        /// <value>The id of the account of the <see cref="QuestionAccount"/> object.</value>
        public int AccID { get; private set; }

        /// <summary>
        /// Gets the id of the question of the <see cref="QuestionAccount"/> object.
        /// </summary>
        /// <value>The id of the question of the <see cref="QuestionAccount"/> object.</value>
        public int QueID { get; private set; }

        /// <summary>
        /// Gets the DateTime of the <see cref="QuestionAccount"/> object.
        /// </summary>
        /// <value>The DateTime of the <see cref="QuestionAccount"/> object.</value>
        public DateTime AcceptionDate { get; private set; }
        #endregion

        #region Static Methods
        /// <summary>
        /// Fetches all the actions belonging to a user through their questions.
        /// </summary>
        /// <param name="userID">The ID of the user.</param>
        /// <returns>A list of all the actions.</returns>
        public static List<QuestionAccount> FetchQuestionActions(int userID)
        {
            List<QuestionAccount> qactions = new List<QuestionAccount>();

            DataTable dt = Database.RetrieveQuery("SELECT * FROM \"Question_Acc\" WHERE \"QUESTION_ID\" IN (SELECT \"ID\" FROM \"Question\" WHERE \"PosterACC_ID\" = " + userID + ")");

            foreach (DataRow row in dt.Rows)
            {
                qactions.Add(new QuestionAccount(
                    Convert.ToInt32(row["ACC_ID"]),
                    Convert.ToInt32(row["QUESTION_ID"]),
                    Convert.ToDateTime(row["AcceptedDate"])));
            }

            return qactions;
        }
        #endregion
    }
}

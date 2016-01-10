//-----------------------------------------------------------------------
// <copyright file="Skill.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------
namespace Class_Layer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using Interfaces;

    /// <summary>
    /// The <see cref="Skill"/> class keeps track of the skill information.
    /// </summary>
    public class Skill : IAccInfo
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Skill"/> class.
        /// </summary>
        /// <param name="userid">The user ID of the skill.</param>
        /// <param name="name">The name of the skill.</param>
        public Skill(int userid, string name)
        {
            this.UserID = userid;
            this.Name = name;
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the user ID of the skill.
        /// </summary>
        /// <value>The user ID of the skill.</value>
        public int UserID { get; set; }

        /// <summary>
        /// Gets the name of the skill.
        /// </summary>
        /// <value>The name of the skill.</value>
        public string Name { get; }
        #endregion

        #region Static Methods
        /// <summary>
        /// Method to get all skills from the database.
        /// </summary>
        /// <param name="fID">The account or question ID.</param>
        /// <param name="isUser">A boolean which indicates if fID is an ID of an account or question.</param>
        /// <returns>Returns a list of skills.</returns>
        public static List<Skill> GetAll(int? fID = null, bool isUser = true)
        {
            List<Skill> skills = new List<Skill>();
            string query = isUser ? "Acc" : "Question";
            
            if (fID != null)
            {
                // Get all the user skills of specified user
                DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"" + query + "_Skill\" WHERE \"" + query.ToUpper() + "_ID\"=" + fID);
                foreach (DataRow row in dt.Rows)
                {
                    skills.Add(new Skill(Convert.ToInt32(fID), row["SKILL_NAME"].ToString()));
                }
            }
            else
            {
                // Get all skills if no ID is specified
                DataTable dt = Database_Layer.Database.RetrieveQuery("SELECT * FROM \"Skill\"");
                foreach (DataRow row in dt.Rows)
                {
                    skills.Add(new Skill(0, row["Name"].ToString()));
                }
            }

            return skills;
        }
        #endregion

        #region Non-Static Methods
        /// <summary>
        /// Add a skill in the database.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the skill has been added successfully or not.</returns>
        public bool Add()
        {         
            return Database_Layer.Database.InsertSkillAccount(this.Name, this.UserID);            
        }

        /// <summary>
        /// Remove a skill from the database.
        /// </summary>
        /// <returns>Returns a boolean, indicating whether the skill has been added successfully or not.</returns>
        public bool Remove()
        {
            return Database_Layer.Database.DeleteSkillAccount(this.Name, this.UserID);
        }
        #endregion
    }
}

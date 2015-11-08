//-----------------------------------------------------------------------
// <copyright file="Database.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------

namespace Database_Layer
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Oracle.DataAccess.Client;

    /// <summary>
    /// The database class to communicate between the application and the database
    /// </summary>
    public static class Database
    {
        /// <summary>
        /// The host IP address
        /// </summary>
        private static string host = "192.168.20.27";

        /// <summary>
        /// The username of the host
        /// </summary>
        private static string username = "PLUMBUM";

        /// <summary>
        /// The password of the host
        /// </summary>
        private static string dbpassword = "root";

        /// <summary>
        /// The connection string to connect to the host
        /// </summary>
        private static string connectionstring = "User Id=" + username + ";Password=" + dbpassword + ";Data Source= //" + host + ":1521/XE;";

        /// <summary>
        /// Selects and retrieves values from the database 
        /// </summary>
        /// <param name="query">The selection statement</param>
        /// <returns>A DataTable with the retrieved values></returns>
        public static DataTable RetrieveQuery(string query)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                try
                {
                    c.Open();
                    OracleCommand cmd = new OracleCommand(@query);
                    cmd.Connection = c;
                    try
                    {
                        OracleDataReader r = cmd.ExecuteReader();
                        DataTable result = new DataTable();
                        result.Load(r);
                        c.Close();
                        return result;
                    }
                    catch (OracleException e)
                    {
                        Console.Write(e.Message);
                        throw;
                    }
                }
                catch (OracleException e)
                {
                    Console.Write(e.Message);
                    return new DataTable();
                }
            }
        }

        #region OLD sql statements, not parameterized
        /*
        /// <summary>
        /// Selects and retrieves values from the database
        /// </summary>
        /// <param name="select">The selection statement</param>
        /// <param name="from">from</param>
        /// <param name="where">the where clause</param>
        /// <returns>A datatable with the retrieved values</returns>
        public static DataTable RetrieveQuery(string select, string from, string where)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("SELECT :x FROM :y WHERE :z");
                cmd.Parameters.Add(new OracleParameter("x", select));
                cmd.Parameters.Add(new OracleParameter("y", from));
                cmd.Parameters.Add(new OracleParameter("z", where));
                cmd.Connection = c;
                try
                {
                    OracleDataReader r = cmd.ExecuteReader();
                    DataTable result = new DataTable();
                    result.Load(r);
                    c.Close();
                    return result;
                }
                catch (Exception e)
                {
                    string debug = e.Message;
                    throw;
                }
            }
        }

        /// <summary>
        /// Sends a query to execute
        /// </summary>
        /// <param name="query"></param>
        public static void ExecuteQuery(string query)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand(query);
                //cmd.Parameters.Add(new OracleParameter("qq", query));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }
                c.Close();
            }
        }

        */
        #endregion

        #region comments
        /// <summary>
        /// Parameterizes the query send to the DB
        /// </summary>
        /// <param name="accountID">user that places response</param>
        /// <param name="questionID">question that receives new response</param>
        /// <param name="desc">user input text</param>
        public static void PlaceComment(int accountID, int questionID, string desc)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Comment\" (\"PosterACC_ID\", \"QUESTION_ID\", \"Description\") VALUES (:AI, :QI, :DC)");
                cmd.Parameters.Add(new OracleParameter("AI", accountID));
                cmd.Parameters.Add(new OracleParameter("QI", questionID));
                cmd.Parameters.Add(new OracleParameter("DC", desc));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Removes a comment from the database
        /// </summary>
        /// <param name="commentID">The ID of the comment</param>
        /// <param name="adminDel">Whether or not the admin or user has deleted the message</param>
        public static void RemoveComment(int commentID, bool adminDel)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                //// when an admin deletes the comment
                if (adminDel)
                {
                    OracleCommand cmd = new OracleCommand("UPDATE \"Comment\" SET \"Description\" = 'Administrator heeft reactie verwijderd.' WHERE \"ID\" = :A");
                    cmd.Parameters.Add(new OracleParameter("A", commentID));
                    cmd.Connection = c;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OracleException e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }

                    c.Close();
                }
                else
                {
                    //// when a user deletes the comment
                    OracleCommand cmd = new OracleCommand("UPDATE \"Comment\" SET \"Description\" = 'Gebruiker heeft reactie verwijderd.' WHERE \"ID\" = :A");
                    cmd.Parameters.Add(new OracleParameter("A", commentID));
                    cmd.Connection = c;
                    try
                    {
                        cmd.ExecuteNonQuery();
                    }
                    catch (OracleException e)
                    {
                        Console.WriteLine(e.Message);
                        throw;
                    }

                    c.Close();
                }
            }
        }

        /// <summary>
        /// Updates a comment in the database
        /// </summary>
        /// <param name="commentID">The ID of the comment</param>
        /// <param name="commentText">The new text of the comment</param>
        public static void UpdateComment(int commentID, string commentText)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Comment\" SET \"Description\" = :B WHERE \"ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("B", commentText));
                cmd.Parameters.Add(new OracleParameter("A", commentID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

                c.Close();
            }
        }

        #endregion

        #region Question
        /// <summary>
        /// Inserts a new question in the database
        /// </summary>
        /// <param name="title">The title of the message</param>
        /// <param name="accountid">The ID of of the user's account</param>
        /// <param name="schedule">The scheduled time</param>
        /// <param name="description">A description of the question</param>
        /// <param name="locID">The location ID</param>
        public static void NewQuestion(string title, int accountid, string schedule, string description, int locID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand(
                    "INSERT INTO \"Question\" (\"Title\", \"PosterACC_ID\", \"Timetable\", \"Description\", \"LOCATION_ID\") " +
                    "VALUES (:A, :B, TO_DATE(:C, 'dd-mon-yyyy HH24:mi:ss'), :D, :E)");
                cmd.Parameters.Add(new OracleParameter("A", title));
                cmd.Parameters.Add(new OracleParameter("B", accountid));
                cmd.Parameters.Add(new OracleParameter("C", schedule));
                cmd.Parameters.Add(new OracleParameter("D", description));
                cmd.Parameters.Add(new OracleParameter("E", locID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Insert a skill associated with a question in the database
        /// </summary>
        /// <param name="skill">The skill to add</param>
        /// <param name="qID">The ID of the question</param>
        public static void SkillInsert(string skill, int qID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Question_Skill\" (\"SKILL_NAME\",\"QUESTION_ID\") VALUES (:A, :B)");
                cmd.Parameters.Add(new OracleParameter("A", skill));
                cmd.Parameters.Add(new OracleParameter("B", qID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Delete a question from the database
        /// </summary>
        /// <param name="qID">The ID of the question</param>
        public static void DeleteQuestion(int qID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE FROM \"Question_Skill\" WHERE \"QUESTION_ID\" = :A");
                OracleCommand cmd2 = new OracleCommand(" DELETE FROM \"Comment\" WHERE \"QUESTION_ID\" = :A");
                OracleCommand cmd3 = new OracleCommand(" DELETE FROM \"Question\" WHERE \"ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("A", qID));
                cmd.Connection = c;
                cmd2.Parameters.Add(new OracleParameter("A", qID));
                cmd2.Connection = c;
                cmd3.Parameters.Add(new OracleParameter("A", qID));
                cmd3.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Update a question from the database
        /// </summary>
        /// <param name="qID">The ID of the question</param>
        /// <param name="title">The new title</param>
        /// <param name="timetable">The new scheduled time</param>
        /// <param name="desc">The new description</param>
        /// <param name="locID">The new location ID</param>
        public static void UpdateQuestion(int qID, string title, string timetable, string desc, int locID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Question\" SET \"Title\" = :A, \"Timetable\" = :B, \"Description\" = :C, \"LOCATION_ID\" = :D WHERE \"ID\" = :E ");
                cmd.Parameters.Add(new OracleParameter("A", title));
                cmd.Parameters.Add(new OracleParameter("B", timetable));
                cmd.Parameters.Add(new OracleParameter("C", desc));
                cmd.Parameters.Add(new OracleParameter("D", locID));
                cmd.Parameters.Add(new OracleParameter("E", qID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Delete an associated skill from a question
        /// </summary>
        /// <param name="qID">The ID of the question</param>
        public static void DelSkillQuestion(int qID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE FROM \"Question_Skill\" WHERE \"QUESTION_ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("A", qID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }
        
        #endregion

        #region account
        /// <summary>
        /// Add a user to the database
        /// </summary>
        /// <param name="name">The name of the user</param>
        /// <param name="locID">The location of the user</param>
        /// <param name="passHash">The password hash of the user</param>
        /// <param name="salt">The salt associated with the password hash</param>
        /// <param name="avatar">A path to the avatar picture of the user</param>
        /// <param name="vog">A path to the VOG-document of the user</param>
        /// <param name="description">A description of the user</param>
        /// <param name="roleText">The role of the user</param>
        /// <param name="sex">The gender of the user</param>
        /// <param name="email">The email of the user</param>
        public static void NewUser(string name, int locID, string passHash, string salt, string avatar, string vog, string description, string roleText, string sex, string email)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Acc\" (\"Name\", \"LOCATION_ID\", \"PassHash\", \"Salt\", \"Avatar\", \"VOG\", \"Description\", \"Role\", \"Sex\", \"Email\") " +
                   "VALUES( :x, :y, :z, :a, :b, :c, :d, :e, :f, :g)");
                cmd.Parameters.Add(new OracleParameter("x", name));
                cmd.Parameters.Add(new OracleParameter("y", locID));
                cmd.Parameters.Add(new OracleParameter("z", passHash));
                cmd.Parameters.Add(new OracleParameter("a", salt));
                cmd.Parameters.Add(new OracleParameter("b", avatar));
                cmd.Parameters.Add(new OracleParameter("c", vog));
                cmd.Parameters.Add(new OracleParameter("d", description));
                cmd.Parameters.Add(new OracleParameter("e", roleText));
                cmd.Parameters.Add(new OracleParameter("f", sex));
                cmd.Parameters.Add(new OracleParameter("g", email));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Get the ID of a user
        /// </summary>
        /// <param name="passHash">The password hash to compare with</param>
        /// <returns>Returns the ID of the user associated with the password hash</returns>
        public static DataTable GetUserID(string passHash)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand(
                    "SELECT \"ID\" FROM \"Acc\" WHERE \"PassHash\"=:z");
                cmd.Parameters.Add(new OracleParameter("z", passHash));
                cmd.Connection = c;
                try
                {
                    OracleDataReader r = cmd.ExecuteReader();
                    DataTable result = new DataTable();
                    result.Load(r);
                    c.Close();
                    return result;
                }
                catch (Exception e)
                {
                    string debug = e.Message;
                    c.Close();
                    throw;
                }
            }
        }

        /// <summary>
        /// Insert a skill associated with an account
        /// </summary>
        /// <param name="skill">The name of the skill</param>
        /// <param name="aID">The account ID</param>
        public static void SkillInsertAcc(string skill, int aID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Acc_Skill\" (\"SKILL_NAME\",\"ACC_ID\") VALUES (:A, :B)");
                cmd.Parameters.Add(new OracleParameter("A", skill));
                cmd.Parameters.Add(new OracleParameter("B", aID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Delete a user from the database
        /// </summary>
        /// <param name="userID">The ID of the user</param>
        public static void DeleteUser(int userID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Acc\" SET \"Name\" = CONCAT(\"Name\",'(VERWIJDERD)'), \"PassHash\" = '0' WHERE \"ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("A", userID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Update the information of a user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="name">The new name of the user</param>
        /// <param name="loc">The new location of the user</param>
        /// <param name="sex">The new gender of the user</param>
        /// <param name="hash">The new password hash of the user</param>
        /// <param name="avatarPath">The new avatar path of the user</param>
        /// <param name="email">The new email of the user</param>
        public static void UpdateUser(int id, string name, int loc, string sex, string hash, string avatarPath, string email)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Acc\" SET \"Name\" = :B , \"LOCATION_ID\" = :C, \"PassHash\" = :E, \"Avatar\" = :F, \"Sex\"= :D, \"Email\"= :G WHERE \"ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("B", name));
                cmd.Parameters.Add(new OracleParameter("C", loc));
                cmd.Parameters.Add(new OracleParameter("E", hash));
                cmd.Parameters.Add(new OracleParameter("F", avatarPath));
                cmd.Parameters.Add(new OracleParameter("D", sex));
                cmd.Parameters.Add(new OracleParameter("G", email));
                cmd.Parameters.Add(new OracleParameter("A", id));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Update the information of a user
        /// </summary>
        /// <param name="id">The ID of the user</param>
        /// <param name="acctype">The account type of the user</param>
        /// <param name="name">The new name of the user</param>
        /// <param name="loc">The new location of the user</param>
        /// <param name="sex">The new gender of the user</param>
        /// <param name="avatarPath">The new avatar path of the user</param>
        /// <param name="email">The new email of the user</param>
        /// <param name="desc">The new description of the user</param>
        public static void UpdateUser(int id, string acctype, string name, int loc, string sex, string avatarPath, string email, string desc)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                //// Ding dat je wilt aanpassen = (statement) ? (waarde als true) : (waarde als false)
                //// Werkt niet als je methodes wilt uitvoeren
                acctype = acctype == "Hulpverlener" ? "V" : "H";

                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Acc\" SET \"Name\" = :B , \"LOCATION_ID\" = :C, \"Avatar\" = :F, \"Description\" = :I, \"Role\" = :H, \"Sex\"= :D, \"Email\"= :G WHERE \"ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("B", name));
                cmd.Parameters.Add(new OracleParameter("C", loc));
                cmd.Parameters.Add(new OracleParameter("F", avatarPath));
                cmd.Parameters.Add(new OracleParameter("I", desc));
                cmd.Parameters.Add(new OracleParameter("H", acctype));
                cmd.Parameters.Add(new OracleParameter("D", sex));
                cmd.Parameters.Add(new OracleParameter("G", email));
                cmd.Parameters.Add(new OracleParameter("A", id));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }
        #endregion

        #region review
        /// <summary>
        /// Insert a new review in the database
        /// </summary>
        /// <param name="rating">The rating of the review</param>
        /// <param name="title">The title of the review</param>
        /// <param name="postedToID">The ID of the account associated with the review</param>
        /// <param name="posterID">The ID of the sender of the review</param>
        /// <param name="desc">The description of the review</param>
        public static void InsertReview(int rating, string title, int postedToID, int posterID, string desc)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Review\" (\"Rating\", \"Title\", \"PostedACC_ID\", \"PosterACC_ID\", \"Description\") " +
                    "VALUES (:a, :b, :c, :d, :e)");
                cmd.Parameters.Add(new OracleParameter("a", rating));
                cmd.Parameters.Add(new OracleParameter("b", title));
                cmd.Parameters.Add(new OracleParameter("c", postedToID));
                cmd.Parameters.Add(new OracleParameter("d", posterID));
                cmd.Parameters.Add(new OracleParameter("e", desc));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Delete a review from the database
        /// </summary>
        /// <param name="id">The ID of the review</param>
        public static void DeleteReview(int id)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE FROM \"Review\" WHERE \"ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("A", id));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Update the information of a review
        /// </summary>
        /// <param name="id">The ID of the review</param>
        /// <param name="rating">The new rating of the review</param>
        /// <param name="title">The new title of the review</param>
        /// <param name="desc">The new description of the review</param>
        public static void UpdateReview(int id, int rating, string title, string desc)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Review\" SET \"Rating\" = :a, \"Title\" = :b, \"Description\" = :c WHERE \"ID\" = :d ");
                cmd.Parameters.Add(new OracleParameter("a", rating));
                cmd.Parameters.Add(new OracleParameter("b", title));
                cmd.Parameters.Add(new OracleParameter("c", desc));
                cmd.Parameters.Add(new OracleParameter("d", id));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }
        #endregion

        #region location
        /// <summary>
        /// Insert a location in the database
        /// </summary>
        /// <param name="longitude">The location's longitude</param>
        /// <param name="latitude">The location's latitude</param>
        /// <param name="describedLocation">A description of the location</param>
        public static void InsertLocation(string longitude, string latitude, string describedLocation)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                //// String.Format("INSERT INTO \"Location\" (\"Longitude\", \"Latitude\", \"Description\") VALUES ('{0}', '{1}', '{2}')",
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Location\" (\"Longitude\", \"Latitude\", \"Description\") " +
                    "VALUES (:a, :b, :c)");
                cmd.Parameters.Add(new OracleParameter("a", longitude));
                cmd.Parameters.Add(new OracleParameter("b", latitude));
                cmd.Parameters.Add(new OracleParameter("c", describedLocation));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Get the ID of a location from the database
        /// </summary>
        /// <param name="longitude">The location's longitude</param>
        /// <param name="latitude">The location's latitude</param>
        /// <param name="describedLocation">A description of the location</param>
        /// <returns>Returns the ID of the location</returns>
        public static DataTable GetLocation(string longitude, string latitude, string describedLocation)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("SELECT ID FROM \"Location\" WHERE \"Longitude\" = :a AND \"Latitude\" = :b AND \"Description\" = :c");
                cmd.Parameters.Add(new OracleParameter("a", longitude));
                cmd.Parameters.Add(new OracleParameter("b", latitude));
                cmd.Parameters.Add(new OracleParameter("c", describedLocation));
                cmd.Connection = c;
                try
                {
                    OracleDataReader r = cmd.ExecuteReader();
                    DataTable result = new DataTable();
                    result.Load(r);
                    c.Close();
                    return result;
                }
                catch (Exception e)
                {
                    string debug = e.Message;
                    c.Close();
                    throw;
                }
            }
        }
        #endregion

        #region meeting
        /// <summary>
        /// Insert a new meeting in the database
        /// </summary>
        /// <param name="originID">The ID of the sender of the meeting</param>
        /// <param name="requestID">The ID of the receiver of the meeting</param>
        /// <param name="date">The date of the meeting</param>
        /// <param name="locID">The ID of the meeting's location</param>
        public static void InsertMeetingA(int originID, int requestID, string date, int locID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Meeting\" (\"RequesterACC_ID\", \"RequestedACC_ID\", \"Timetable\", \"LOCATION_ID\") " +
                "VALUES (:a, :b,  TO_DATE(:c, 'dd-mon-yyyy HH24:mi:ss'), :d)");
                cmd.Parameters.Add(new OracleParameter("a", originID));
                cmd.Parameters.Add(new OracleParameter("b", requestID));
                cmd.Parameters.Add(new OracleParameter("c", date));
                cmd.Parameters.Add(new OracleParameter("d", locID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Insert a new meeting in the database
        /// </summary>
        /// <param name="originID">The ID of the sender of the meeting</param>
        /// <param name="requestID">The ID of the receiver of the meeting</param>
        public static void InsertMeetingA(int originID, int requestID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Meeting\" (\"RequesterACC_ID\", \"RequestedACC_ID\") " +
                "VALUES (:a, :b)");
                cmd.Parameters.Add(new OracleParameter("a", originID));
                cmd.Parameters.Add(new OracleParameter("b", requestID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Insert a new meeting in the database
        /// </summary>
        /// <param name="originID">The ID of the sender of the meeting</param>
        /// <param name="requestID">The ID of the receiver of the meeting</param>
        /// <param name="date">The date of the meeting</param>
        public static void InsertMeetingA(int originID, int requestID, string date)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Meeting\" (\"RequesterACC_ID\", \"RequestedACC_ID\", \"Timetable\") " +
                "VALUES (:a, :b, TO_DATE(:c, 'dd-mon-yyyy HH24:mi:ss'))");
                cmd.Parameters.Add(new OracleParameter("a", originID));
                cmd.Parameters.Add(new OracleParameter("b", requestID));
                cmd.Parameters.Add(new OracleParameter("c", date));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// Insert a meeting in the database
        /// </summary>
        /// <param name="originID">The ID of the sender of the meeting</param>
        /// <param name="requestID">The ID of the receiver of the meeting</param>
        /// <param name="locID">The ID of the meeting's location</param>
        public static void InsertMeetingA(int originID, int requestID, int locID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Meeting\" (\"RequesterACC_ID\", \"RequestedACC_ID\", \"LOCATION_ID\") " +
                "VALUES (:a, :b, :d)");
                cmd.Parameters.Add(new OracleParameter("a", originID));
                cmd.Parameters.Add(new OracleParameter("b", requestID));
                cmd.Parameters.Add(new OracleParameter("d", locID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }
        #endregion
    }
}

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
        /// creates a new question entry in the database
        /// </summary>
        /// <param name="title">Title of the question</param>
        /// <param name="accountid">account id from the person that places the request</param>
        /// <param name="startDate">starting date of the help</param>
        /// <param name="endDate">ending time of the help</param>
        /// <param name="description">description containing, method of travel, time to travel and further information</param>
        /// <param name="urgent">urgence of the question</param>
        /// <param name="location">location of the question</param>
        /// <param name="maxHulpverlener">maximum amount of people needed to solve the problem</param>
        /// <param name="status">status of the question range in 0,1,2,3</param>
        public static void NewQuestion(string title, int accountid, string startDate, string endDate,
                              string description, bool urgent, string location, int maxHulpverlener, int status)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                int Urgent = urgent ? 1 : 0;
                c.Open();
                OracleCommand cmd = new OracleCommand(
                    "INSERT INTO \"Question\" (\"Title\", \"PosterACC_ID\", \"StartDate\"," +
                    " \"EndDate\", \"Description\", \"Urgent\", \"Location\", \"AmountACCs\", \"Status\",) " +
                    "VALUES (:A, :B, TO_DATE(:C), TO_DATE(:D), :E, :F, :G, :H, :I)");
                cmd.Parameters.Add(new OracleParameter("A", title));
                cmd.Parameters.Add(new OracleParameter("B", accountid));
                cmd.Parameters.Add(new OracleParameter("C", startDate));
                cmd.Parameters.Add(new OracleParameter("D", endDate));
                cmd.Parameters.Add(new OracleParameter("E", description));
                cmd.Parameters.Add(new OracleParameter("F", Urgent));
                cmd.Parameters.Add(new OracleParameter("G", location));
                cmd.Parameters.Add(new OracleParameter("H", maxHulpverlener));
                cmd.Parameters.Add(new OracleParameter("I", status));
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
                OracleCommand cmd2 = new OracleCommand("DELETE FROM \"Question_Acc\" WHERE \"QUESTION_ID\" = :A");
                OracleCommand cmd3 = new OracleCommand(" DELETE FROM \"Comment\" WHERE \"QUESTION_ID\" = :A");
                OracleCommand cmd4 = new OracleCommand(" DELETE FROM \"Question\" WHERE \"ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("A", qID));
                cmd.Connection = c;
                cmd2.Parameters.Add(new OracleParameter("A", qID));
                cmd2.Connection = c;
                cmd3.Parameters.Add(new OracleParameter("A", qID));
                cmd3.Connection = c;
                cmd4.Parameters.Add(new OracleParameter("A", qID));
                cmd4.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                    cmd2.ExecuteNonQuery();
                    cmd3.ExecuteNonQuery();
                    cmd4.ExecuteNonQuery();
                }
                catch (OracleException)
                {
                    throw;
                }

                c.Close();
            }
        }

        /// <summary>
        /// A method to update a question entry, users and admins can change different parts of their question.
        /// </summary>
        /// <param name="qID">ID of the question that needs to be changed</param>
        /// <param name="title">Title of the question</param>
        /// <param name="accountid">account id from the person that places the request</param>
        /// <param name="startDate">starting date of the help</param>
        /// <param name="endDate">ending time of the help</param>
        /// <param name="description">description containing, method of travel, time to travel and further information</param>
        /// <param name="urgent">urgence of the question</param>
        /// <param name="location">location of the question</param>
        /// <param name="maxHulpverlener">maximum amount of people needed to solve the problem</param>
        /// <param name="status">status of the question range in 0,1,2,3</param>
        public static void UpdateQuestion(int qID, string title, int accountid, string startDate, string endDate,
                              string description, bool urgent, string location, int maxHulpverlener, int status)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                int Urgent = urgent ? 1 : 0;
                c.Open();
                OracleCommand cmd = new OracleCommand(
                 "UPDATE \"Question\" SET \"Title\" = :A, \"StartDate\" = :B, \"EndDate\" = :C, \"Description\" = :D, \"Urgent\" = :E , \"Location\" = :F, \"AmountACCs\" = :G, \"Status\" = :H WHERE \"ID\" = :I ");
                cmd.Parameters.Add(new OracleParameter("A", title));
                cmd.Parameters.Add(new OracleParameter("B", startDate));
                cmd.Parameters.Add(new OracleParameter("C", endDate));
                cmd.Parameters.Add(new OracleParameter("D", description));
                cmd.Parameters.Add(new OracleParameter("E", Urgent));
                cmd.Parameters.Add(new OracleParameter("F", location));
                cmd.Parameters.Add(new OracleParameter("G", maxHulpverlener));
                cmd.Parameters.Add(new OracleParameter("H", status));
                cmd.Parameters.Add(new OracleParameter("I", qID));
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

        public static void NewUser()
        {/*
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Acc\" (\"Name\", \"LOCATION_ID\", \"PassHash\", \"Salt\", \"Avatar\", \"VOG\", \"Description\", \"Role\", \"Sex\", \"Email\") " +
                   "VALUES( :x, :y, :z, :a, :b, :c, :d, :e, :f, :g)");
                cmd.Parameters.Add(new OracleParameter("x", name));
              
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
            }*/
            //TODO
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

        public static void UpdateUser()//USER
        {/*
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Acc\" SET \"Name\" = :B , \"LOCATION_ID\" = :C, \"PassHash\" = :E, \"Avatar\" = :F, \"Sex\"= :D, \"Email\"= :G WHERE \"ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("B", name));
              
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
            }*/
            //TODO
        }

        public static void UpdateUser()//ADMIN
        {/*
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                
                //// Ding dat je wilt aanpassen = (statement) ? (waarde als true) : (waarde als false)
                //// Werkt niet als je methodes wilt uitvoeren
                acctype = acctype == "Hulpverlener" ? "V" : "H";

                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Acc\" SET \"Name\" = :B , \"LOCATION_ID\" = :C, \"Avatar\" = :F, \"Description\" = :I, \"Role\" = :H, \"Sex\"= :D, \"Email\"= :G WHERE \"ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("B", name));
       
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
            }*/
            //TODO
        }
        #endregion

        #region review
        /// <summary>
        /// Insert a new review in the database
        /// </summary>
        /// <param name="rating">The rating of the review</param>
        /// <param name="postedToID">The ID of the account associated with the review</param>
        /// <param name="posterID">The ID of the sender of the review</param>
        /// <param name="desc">The description of the review</param>
        public static void InsertReview(int rating, int postedToID, int posterID, string desc)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Review\" (\"Rating\", \"PostedACC_ID\", \"PosterACC_ID\", \"Description\") " +
                    "VALUES (:a, :b, :c, :d)");
                cmd.Parameters.Add(new OracleParameter("a", rating));
                cmd.Parameters.Add(new OracleParameter("b", postedToID));
                cmd.Parameters.Add(new OracleParameter("c", posterID));
                cmd.Parameters.Add(new OracleParameter("d", desc));
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
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
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
        /// <param name="desc">The new description of the review</param>
        public static void UpdateReview(int id, int rating, string desc)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Review\" SET \"Rating\" = :a, \"Description\" = :b WHERE \"ID\" = :c ");
                cmd.Parameters.Add(new OracleParameter("a", rating));                
                cmd.Parameters.Add(new OracleParameter("b", desc));
                cmd.Parameters.Add(new OracleParameter("c", id));
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

        #region availability
                //TODO
        #endregion

        #region meeting
       
       
        public static void InsertMeeting()
        {/*
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Meeting\" (\"RequesterACC_ID\", \"RequestedACC_ID\", \"Timetable\", \"LOCATION_ID\") " +
                "VALUES (:a, :b,  TO_DATE(:c), :d)");
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
            }*/
            //TODO
        }

        /// <summary>
        /// Insert a new meeting in the database
        /// </summary>
        /// <param name="originID">The ID of the sender of the meeting</param>
        /// <param name="requestID">The ID of the receiver of the meeting</param>
        public static void InsertMeeting(int originID, int requestID)
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

        public static void InsertMeeting()//enkel date
        {/*
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Meeting\" (\"RequesterACC_ID\", \"RequestedACC_ID\", \"Timetable\") " +
                "VALUES (:a, :b, TO_DATE(:c, 'dd-mon-yyyy HH24:mi:ss'))");
                cmd.Parameters.Add(new OracleParameter("a", originID));
           
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
            }*/
            //TODO
        }

        
        public static void InsertMeeting()//no date just location
        {/*
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Meeting\" (\"RequesterACC_ID\", \"RequestedACC_ID\", \"LOCATION_ID\") " +
                "VALUES (:a, :b, :d)");
                cmd.Parameters.Add(new OracleParameter("a", originID));
          
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
            }*/
            //TODO
        }

        //TODO Update Meeting

        #endregion
    }
}

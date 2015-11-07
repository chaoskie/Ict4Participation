//-----------------------------------------------------------------------
// <copyright file="Database.cs" company="ICT4Participation">
//     Copyright (c) ICT4Participation. All rights reserved.
// </copyright>
// <author>ICT4Participation</author>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.DataAccess.Client;

namespace Database_Layer
{
    /// <summary>
    /// The database class to communicate between the application and the database
    /// </summary>
    public static class Database
    {
        /// HOST IP
        private static string host = "192.168.20.27";
        /// HOST USERNAME
        private static string username = "PLUMBUM";
        /// HOST PASSWORD
        private static string password = "root";
        private static string connectionstring = "User Id=" + username + ";Password=" + password + ";Data Source= //" + host + ":1521/XE;";

        /// <summary>
        /// Selects and retrieves values from the database 
        /// </summary>
        /// <param name="query">The selection statement</param>
        /// <returnsA datatable with the retrieved values></returns>
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
        /// Parameterizes the querry send to the DB
        /// </summary>
        /// <param name="accountID">user that places response</param>
        /// <param name="questionID">question that receives new response</param>
        /// <param name="Desc">user input text</param>
        public static void PlaceComment(int accountID, int questionID, string Desc)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Comment\" (\"PosterACC_ID\", \"QUESTION_ID\", \"Description\") VALUES (:AI, :QI, :DC)");
                cmd.Parameters.Add(new OracleParameter("AI", accountID));
                cmd.Parameters.Add(new OracleParameter("QI", questionID));
                cmd.Parameters.Add(new OracleParameter("DC", Desc));
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

        public static void RemoveComment(int commentID, bool adminDel)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                if (adminDel) //when an admin deletes the comment
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
                else //when a user deletes the comment
                {
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
        public static void NewQuestion(string title, int accountid, string schedule, string description, int locID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand(
                    "INSERT INTO \"Question\" (\"Title\", \"PosterACC_ID\", \"Timetable\", \"Description\", \"LOCATION_ID\") " +
                    "VALUES (:A, :B, TO_DATE(:C, 'dd-mon-yyyy HH24:mi:ss'), :D, :E)"
                    );
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
        public static void NewUser(string name, int locID, string passHash, string salt, string avatar, string vog, string description, string roleText, string sex, string email)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Acc\" (\"Name\", \"LOCATION_ID\", \"PassHash\", \"Salt\", \"Avatar\", \"VOG\", \"Description\", \"Role\", \"Sex\", \"Email\") " +
                   "VALUES( :x, :y, :z, :a, :b, :c, :d, :e, :f, :g)"
                   );
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

        public static DataTable GetUserID(string passHash)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand(
                    "SELECT \"ID\" FROM \"Acc\" WHERE \"PassHash\"=:z"
                   );
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

        public static void SkillInsertAcc(string skill, int aID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Acc_Skill\" (\"SKILL_NAME\",\"QUESTION_ID\") VALUES (:A, :B)");
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

        public static void DeleteUser(int userID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Acc\" SET \"Name\" = CONCAT(field,'(VERWIJDERD)') \"PassHash\" = '0' WHERE \"ID\" = :A");
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

        public static void UpdateUser(int ID, string name, int loc, string sex, string password, string avatarPath, string email)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Acc\" SET \"Name\" = :B , \"LOCATION_ID\" = :C, \"PassHash\" = :E, \"Avatar\" = :F, \"Sex\"= :D, \"Email\"= :G WHERE \"ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("A", ID));
                cmd.Parameters.Add(new OracleParameter("B", name));
                cmd.Parameters.Add(new OracleParameter("C", loc));
                cmd.Parameters.Add(new OracleParameter("D", sex));
                cmd.Parameters.Add(new OracleParameter("E", password));
                cmd.Parameters.Add(new OracleParameter("F", avatarPath));
                cmd.Parameters.Add(new OracleParameter("G", email));
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
        public static void UpdateUser(int ID, string acctype, string name, int loc, string sex, string avatarPath, string email, string desc)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                //Ding dat je wilt aanpassen = (statement) ? (waarde als true) : (waarde als false)
                //Werkt niet als je methodes wilt uitvoeren
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
                cmd.Parameters.Add(new OracleParameter("A", ID));
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
        public static void DeleteReview(int ID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE FROM \"Review\" WHERE \"ID\" = :A");
                cmd.Parameters.Add(new OracleParameter("A", ID));
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
        public static void UpdateReview(int ID, int rating, string title, string desc)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Review\" SET \"Rating\" = :a, \"Title\" = :b, \"Description\" = :c WHERE \"ID\" = :d ");
                cmd.Parameters.Add(new OracleParameter("a", rating));
                cmd.Parameters.Add(new OracleParameter("b", title));
                cmd.Parameters.Add(new OracleParameter("c", desc));
                cmd.Parameters.Add(new OracleParameter("d", ID));
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
        public static void InsertLocation(string Long, string Lat, string DescribedLocation)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                //String.Format("INSERT INTO \"Location\" (\"Longitude\", \"Latitude\", \"Description\") VALUES ('{0}', '{1}', '{2}')",
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Location\" (\"Longitude\", \"Latitude\", \"Description\") " +
                    "VALUES (:a, :b, :c)");
                cmd.Parameters.Add(new OracleParameter("a", Long));
                cmd.Parameters.Add(new OracleParameter("b", Lat));
                cmd.Parameters.Add(new OracleParameter("c", DescribedLocation));
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

        public static DataTable GetLocation(string Long, string Lat, string DescribedLocation)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("SELECT ID FROM \"Location\" WHERE \"Longitude\" = :a AND \"Latitude\" = :b AND \"Description\" = :c");
                cmd.Parameters.Add(new OracleParameter("a", Long));
                cmd.Parameters.Add(new OracleParameter("b", Lat));
                cmd.Parameters.Add(new OracleParameter("c", DescribedLocation));
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

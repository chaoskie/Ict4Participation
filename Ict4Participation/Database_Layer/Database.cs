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
        /// <returns>succes boolean</returns>
        public static bool InsertComment(int accountID, int questionID, string desc)
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
                    return false;
                }
                c.Close();
                return true;
            }
        }

        /// <summary>
        /// Removes a comment from the database
        /// </summary>
        /// <param name="commentID">The ID of the comment</param>
        /// <param name="adminDel">Whether or not the admin or user has deleted the message</param>
        /// <returns>succes boolean</returns>
        public static bool DeleteComment(int commentID, bool adminDel)
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
                        return false;
                    }
                    c.Close();
                    return true;
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
                        return false;
                    }
                    c.Close();
                    return true;
                }
            }
        }

        /// <summary>
        /// Updates a comment in the database
        /// </summary>
        /// <param name="commentID">The ID of the comment</param>
        /// <param name="commentText">The new text of the comment</param>
        /// <returns>succes boolean</returns>
        public static bool UpdateComment(int commentID, string commentText)
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
                    return false;
                }
                c.Close();
                return true;
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
        /// <param name="status">status of the question range in 0,1,2,3| 0=not accepted, 1=inprogress, 2=done, 3=canceled</param>
        /// <returns>succes boolean</returns>
        public static bool InsertQuestion(string title, int accountid, string startDate, string endDate,
                              string description, bool urgent, string location, int maxHulpverlener, int status, out Nullable<int> qID)
        {
            qID = null;
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                int Urgent = urgent ? 1 : 0;
                c.Open();
                OracleCommand cmd = new OracleCommand(
                    "INSERT INTO \"Question\" (\"Title\", \"PosterACC_ID\", \"StartDate\"," +
                    " \"EndDate\", \"Description\", \"Urgent\", \"Location\", \"AmountACCs\", \"Status\") " +
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

                OracleCommand cmd1 = new OracleCommand(
                 "SELECT \"ID\" FROM \"Question\" WHERE \"Title\" = :A AND \"PosterACC_ID\" = :X AND \"StartDate\" = :B AND \"EndDate\" = :C AND \"Description\" = :D AND \"Urgent\" = :E AND \"Location\" = :F AND \"AmountACCs\" = :G AND \"Status\" = :H");
                cmd1.Parameters.Add(new OracleParameter("A", title));
                cmd1.Parameters.Add(new OracleParameter("X", accountid));
                cmd1.Parameters.Add(new OracleParameter("B", startDate));
                cmd1.Parameters.Add(new OracleParameter("C", endDate));
                cmd1.Parameters.Add(new OracleParameter("D", description));
                cmd1.Parameters.Add(new OracleParameter("E", Urgent));
                cmd1.Parameters.Add(new OracleParameter("F", location));
                cmd1.Parameters.Add(new OracleParameter("G", maxHulpverlener));
                cmd1.Parameters.Add(new OracleParameter("H", status));
                OracleDataReader r = cmd.ExecuteReader();
                DataTable result = new DataTable();
                result.Load(r);
                foreach (DataRow row in result.Rows)
                {
                    qID = Convert.ToInt32(row["ID"]);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        /// <summary>
        /// Insert a skill associated with a question in the database
        /// </summary>
        /// <param name="skill">The skill to add</param>
        /// <param name="qID">The ID of the question</param>
        /// <returns>succes boolean</returns>
        public static bool InsertSkillQuestion(string skill, int qID)
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
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        /// <summary>
        /// Delete a question from the database
        /// </summary>
        /// <param name="qID">The ID of the question</param>
        /// <returns>succes boolean</returns>
        public static bool DeleteQuestion(int qID)
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
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
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
        /// <returns>succes boolean</returns>
        public static bool UpdateQuestion(int qID, string title, int accountid, string startDate, string endDate,
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
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        /// <summary>
        /// Delete skill question entry
        /// </summary>
        /// <param name="qID">question to delete from</param>
        /// <param name="name">skill to delete</param>
        /// <returns>succes boolean</returns>
        public static bool DeleteSkillQuestion(int qID, string name)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE FROM \"Question_Skill\" WHERE \"QUESTION_ID\" = :A AND \"SKILL_NAME\" = :B");
                cmd.Parameters.Add(new OracleParameter("A", qID));
                cmd.Parameters.Add(new OracleParameter("B", name));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        /// <summary>
        /// insert a volunteer on a question he accepted
        /// </summary>
        /// <param name="qID">question id</param>
        /// <param name="uID">volunteer id</param>
        /// <returns>succes boolean</returns>
        public static bool InsertQuestionAccount(int qID, int uID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Question_Acc\" (\"ACC_ID\", \"QUESTION_ID\") VALUES (:A, :B)");
                cmd.Parameters.Add(new OracleParameter("A", uID));
                cmd.Parameters.Add(new OracleParameter("B", qID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        /// <summary>
        /// delete a volunteers response on a question
        /// </summary>
        /// <param name="qID">question id</param>
        /// <param name="uID">volunteer id</param>
        /// <returns>succes boolean</returns>
        public static bool DeleteQuestionAccount(int qID, int uID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE \"Question_Acc\" WHERE \"ACC_ID\" = :A AND \"QUESTION_ID\" = :B)");
                cmd.Parameters.Add(new OracleParameter("A", uID));
                cmd.Parameters.Add(new OracleParameter("B", qID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        #endregion

        #region account
        /// <summary>
        /// Inserting a new account into the database
        /// </summary>
        /// <param name="Username">account username</param>
        /// <param name="PassHash">hashed password</param>
        /// <param name="Email">email-adress</param>
        /// <param name="Name">name of the user</param>
        /// <param name="Location">adress of the user</param>
        /// <param name="Village">hometown of the user</param>
        /// <param name="phone">phonenumber</param>
        /// <param name="driverLicense">has a driverlicense</param>
        /// <param name="HasCar">has a car</param>
        /// <param name="ov">has OV-card</param>
        /// <param name="Bday">birthday</param>
        /// <param name="Picture">path to picture</param>
        /// <param name="sex">sex</param>
        /// <param name="VOG">vog path</param>
        /// <returns>succes boolean</returns>
        public static bool InsertUser(string Username, string PassHash, string Email, string Name, string Location, string Village, string phone,
            bool driverLicense, bool HasCar, bool ov, string Bday, string Picture, string Sex, string VOG)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                int DriverLicense = driverLicense ? 1 : 0;
                int hasCar = HasCar ? 1 : 0;
                int OV = ov ? 1 : 0;

                c.Open();
                OracleCommand cmd = new OracleCommand("INSERT INTO \"Acc\" (\"Gebruikersnaam\" ,\"Wachtwoord\" ,\"Email\" ,\"Naam\" ,\"Adres\" ," +
                    "\"Woonplaats\" ,\"Telefoonnummer\" ,\"HeeftRijbewijs\" ,\"HeeftAuto\" ,\"OVMogelijk\" ,\"Geboortedatum\" ," +
                    "\"Foto\" ,\"Geslacht\" ,\"VOG\") " +
                   "VALUES(:un, :ph, :em, :na, :loc, :vil, :phon, :dl, :car, :ov, TO_DATE(:bd), :pic, :sex, :vog)");
                cmd.Parameters.Add(new OracleParameter("un", Username));
                cmd.Parameters.Add(new OracleParameter("ph", PassHash));
                cmd.Parameters.Add(new OracleParameter("em", Email));
                cmd.Parameters.Add(new OracleParameter("na", Name));
                cmd.Parameters.Add(new OracleParameter("loc", Location));
                cmd.Parameters.Add(new OracleParameter("vil", Village));
                cmd.Parameters.Add(new OracleParameter("phon", phone));
                cmd.Parameters.Add(new OracleParameter("dl", DriverLicense));
                cmd.Parameters.Add(new OracleParameter("car", hasCar));
                cmd.Parameters.Add(new OracleParameter("ov", OV));
                cmd.Parameters.Add(new OracleParameter("bd", Bday));
                cmd.Parameters.Add(new OracleParameter("pic", Picture));
                cmd.Parameters.Add(new OracleParameter("sex", Sex));
                cmd.Parameters.Add(new OracleParameter("vog", VOG));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        /// <summary>
        /// Updating an excisting user
        /// </summary>
        /// <param name="uID">Uswer that needs to be updated</param>
        /// <param name="Username">account username</param>
        /// <param name="PassHash">hashed password</param>
        /// <param name="Email">email-adress</param>
        /// <param name="Name">name of the user</param>
        /// <param name="Location">adress of the user</param>
        /// <param name="Village">hometown of the user</param>
        /// <param name="phone">phonenumber</param>
        /// <param name="driverLicense">has a driverlicense</param>
        /// <param name="HasCar">has a car</param>
        /// <param name="ov">has OV-card</param>
        /// <param name="Bday">birthday</param>
        /// <param name="Picture">path to picture</param>
        /// <param name="sex">sex</param>
        /// <param name="VOG">vog path</param>
        /// <returns>Succes boolean</returns>
        public static bool UpdateUser(int uID, string Username, string PassHash, string Email, string Name, string Location, string Village, string phone,
           bool driverLicense, bool HasCar, bool ov, string Bday, string Picture, string Sex, string VOG)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                int DriverLicense = driverLicense ? 1 : 0;
                int hasCar = HasCar ? 1 : 0;
                int OV = ov ? 1 : 0;

                c.Open();
                OracleCommand cmd = new OracleCommand("UPDATE \"Acc\" SET \"Gebruikersnaam\" = :un \"Wachtwoord\" = :ph \"Email\" = :em \"Naam\" = :na \"Adres\" = :loc " +
                    "\"Woonplaats\" = :vil \"Telefoonnummer\" = :phon \"HeeftRijbewijs\" = :dl \"HeeftAuto\" = :car \"OVMogelijk\" = :ov " +
                    "\"Geboortedatum\" = TO_DATE(:bd) \"Foto\" = :pic \"Geslacht\" = :sex \"VOG\" = :vog WHERE \"ID\" = :id");
                cmd.Parameters.Add(new OracleParameter("un", Username));
                cmd.Parameters.Add(new OracleParameter("ph", PassHash));
                cmd.Parameters.Add(new OracleParameter("em", Email));
                cmd.Parameters.Add(new OracleParameter("na", Name));
                cmd.Parameters.Add(new OracleParameter("loc", Location));
                cmd.Parameters.Add(new OracleParameter("vil", Village));
                cmd.Parameters.Add(new OracleParameter("phon", phone));
                cmd.Parameters.Add(new OracleParameter("dl", DriverLicense));
                cmd.Parameters.Add(new OracleParameter("car", hasCar));
                cmd.Parameters.Add(new OracleParameter("ov", OV));
                cmd.Parameters.Add(new OracleParameter("bd", Bday));
                cmd.Parameters.Add(new OracleParameter("pic", Picture));
                cmd.Parameters.Add(new OracleParameter("sex", Sex));
                cmd.Parameters.Add(new OracleParameter("vog", VOG));
                cmd.Parameters.Add(new OracleParameter("id", uID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        /// <summary>
        /// Insert a skill associated with an account
        /// </summary>
        /// <param name="skill">The name of the skill</param>
        /// <param name="aID">The account ID</param>
        /// <returns>Succes boolean</returns>
        public static bool InsertSkillAccount(string skill, int aID)
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
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        /// <summary>
        /// Delete a skill from a user
        /// </summary>
        /// <param name="skill">skill to delete</param>
        /// <param name="aID">User Id</param>
        /// <returns>succes boolean</returns>
        public static bool DeleteSkillAccount(string skill, int aID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE \"Acc_Skill\" WHERE \"SKILL_NAME\" = :A AND \"ACC_ID\" = :B");
                cmd.Parameters.Add(new OracleParameter("A", skill));
                cmd.Parameters.Add(new OracleParameter("B", aID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        /// <summary>
        /// delete a user from the database
        /// </summary>
        /// <param name="userID">user to remove</param>
        /// <returns>succes boolean</returns>
        public static bool DeleteUser(int userID)
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
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
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
        /// <returns>Succes boolean</returns>
        public static bool InsertReview(int rating, int postedToID, int posterID, string desc)
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
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        /// <summary>
        /// Delete a review from the database
        /// </summary>
        /// <param name="id">The ID of the review</param>
        /// <returns>Succes boolean</returns>
        public static bool DeleteReview(int id)
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
                    return false;
                }
                c.Close();
                return true;
            }
        }

        /// <summary>
        /// Update the information of a review
        /// </summary>
        /// <param name="id">The ID of the review</param>
        /// <param name="rating">The new rating of the review</param>
        /// <param name="desc">The new description of the review</param>
        /// <returns>Succes boolean</returns>
        public static bool UpdateReview(int id, int rating, string desc)
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
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        #endregion

        #region availability
        /// <summary>
        /// searches if the availability entry is already made, if not then it will be added, otherwise select and create reference to the user.
        /// </summary>
        /// <param name="uID">user id</param>
        /// <param name="day">day of the week</param>
        /// <param name="period">stance of the sun</param>
        /// <returns>succes boolean</returns>
        public static bool InsertAvailability(int uID, string day, string period)
        {
            Nullable<int> foundID = null;//zoek naar bestaan van entry
            DataTable tdb = RetrieveQuery("SELECT \"ID\" FROM \"Availability\" WHERE \"Day\" = " + day + ", \"Period\" = " + period);
            foreach (DataRow r in tdb.Rows)
            {
                foundID = Convert.ToInt32(r["ID"]);//haal id van bestaande entry op, zo niet dan null
            }
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                if (foundID == null)
                {//als entry niet bestaat, dan creëer
                    OracleCommand cmd = new OracleCommand("INSERT INTO \"Availability\" (\"Day\", \"Period\") VALUES (:a, :b)");
                    cmd.Parameters.Add(new OracleParameter("a", day));
                    cmd.Parameters.Add(new OracleParameter("b", period));

                    cmd.ExecuteNonQuery();
                    //haal id opnieuw op
                    DataTable tdb2 = RetrieveQuery("SELECT \"ID\" FROM \"Availability\" WHERE \"Day\" = " + day + ", \"Period\" = " + period);
                    foreach (DataRow r in tdb2.Rows)
                    {
                        foundID = Convert.ToInt32(r["ID"]);
                    }
                }
                //maak referentie tussen user en entry
                OracleCommand cmd1 = new OracleCommand("INSERT INTO \"Availability_Acc\" (\"ACC_ID\", \"AVAILABILITY_ID\") VALUES (:a, :b)");
                cmd1.Parameters.Add(new OracleParameter("a", uID));
                cmd1.Parameters.Add(new OracleParameter("b", foundID));
                try
                {
                    cmd1.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        public static bool DeleteAvailability(int userId, string day, string period)
        {
            Nullable<int> foundID = null;//zoek naar bestaan van entry
            DataTable tdb = RetrieveQuery("SELECT \"ID\" FROM \"Availability\" WHERE \"Day\" = " + day + ", \"Period\" = " + period);
            foreach (DataRow r in tdb.Rows)
            {
                foundID = Convert.ToInt32(r["ID"]);//haal id van bestaande entry op, zo niet dan null
            }
            if (foundID == null) return false;

            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE \"Availability_Acc\" WHERE \"ACC_ID\" = :a AND \"AVAILABILITY_ID\" = " + foundID);
                cmd.Parameters.Add(new OracleParameter("a", userId));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }

        }
        #endregion

        #region meeting

        /// <summary>
        /// Query to make meeting only if they are known
        /// </summary>
        /// <param name="requesterID">inviting perty</param>
        /// <param name="regeustedID">invited party(ies)</param>
        /// <param name="startDate">start date/time of the meeting</param>
        /// <param name="endDate">end date/time of the meeting</param>
        /// <param name="location">adress</param>
        /// <returns>succes boolean</returns>
        public static bool InsertMeeting(int requesterID, int regeustedID, string startDate, string endDate, string location)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                string commando = "INSERT INTO \"Meeting\" (\"RequesterACC_ID\", \"RequestedACC_ID\"";
                if (!String.IsNullOrWhiteSpace(startDate)) { commando += ", \"StartDate\""; }
                if (!String.IsNullOrWhiteSpace(endDate)) { commando += ", \"EndDate\""; }
                if (!String.IsNullOrWhiteSpace(location)) { commando += ", \"Location\""; }
                commando += ") VALUES (:a, :b";

                if (!String.IsNullOrWhiteSpace(startDate)) { commando += ", TO_DATE(:c)"; }
                if (!String.IsNullOrWhiteSpace(endDate)) { commando += ", TO_DATE(:d)"; }
                if (!String.IsNullOrWhiteSpace(location)) { commando += ", :e"; }
                commando += ")";
                c.Open();

                OracleCommand cmd = new OracleCommand(commando);
                cmd.Parameters.Add(new OracleParameter("a", requesterID));
                cmd.Parameters.Add(new OracleParameter("b", regeustedID));
                if (!String.IsNullOrWhiteSpace(startDate)) { cmd.Parameters.Add(new OracleParameter("c", startDate)); }
                if (!String.IsNullOrWhiteSpace(endDate)) { cmd.Parameters.Add(new OracleParameter("d", endDate)); }
                if (!String.IsNullOrWhiteSpace(location)) { cmd.Parameters.Add(new OracleParameter("e", location)); }
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.Write(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        /// <summary>
        /// delete the meeting
        /// </summary>
        /// <param name="mID">id of the meeting that needs to </param>
        /// <returns>succes boolean</returns>
        public static bool DeleteMeeting(int mID)
        {
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand("DELETE \"Meeting\" WHERE \"ID\" = :a");
                cmd.Parameters.Add(new OracleParameter("a", mID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.Write(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }
        /// <summary>
        /// update a meeting
        /// </summary>
        /// <param name="mID"id of the meeting that is updated</param>
        /// <param name="startDate">start of a meeting</param>
        /// <param name="endDate">end of a meeting</param>
        /// <param name="location">location where a meeting is taking place</param>
        /// <returns></returns>
        public static bool UpdateMeeting(int mID, string startDate, string endDate, string location)
        {
            if ((String.IsNullOrWhiteSpace(startDate)) && (String.IsNullOrWhiteSpace(endDate)) && (String.IsNullOrWhiteSpace(location))) { return false; }
            string commando = "UPDATE \"Meeting\" SET ";
            if (!String.IsNullOrWhiteSpace(startDate)) { commando += "\"StartDate\" = :a,"; }
            if (!String.IsNullOrWhiteSpace(endDate)) { commando += "\"EndDate\" = :b,"; }
            if (!String.IsNullOrWhiteSpace(location)) { commando += "\"Location\" = :c,"; }
            commando = commando.Substring(0, commando.Length - 1);
            commando += "WHERE \"ID\" = :d";
            using (OracleConnection c = new OracleConnection(@connectionstring))
            {
                c.Open();
                OracleCommand cmd = new OracleCommand(commando);
                if (!String.IsNullOrWhiteSpace(startDate)) { cmd.Parameters.Add(new OracleParameter("a", startDate)); }
                if (!String.IsNullOrWhiteSpace(endDate)) { cmd.Parameters.Add(new OracleParameter("b", endDate)); }
                if (!String.IsNullOrWhiteSpace(location)) { cmd.Parameters.Add(new OracleParameter("c", location)); }
                cmd.Parameters.Add(new OracleParameter("d", mID));
                cmd.Connection = c;
                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (OracleException e)
                {
                    Console.Write(e.Message);
                    return false;
                }
                c.Close();
                return true;
            }
        }

        #endregion
    }
}

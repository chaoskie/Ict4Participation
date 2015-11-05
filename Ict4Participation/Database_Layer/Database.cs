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
                OracleCommand cmd = new OracleCommand("SELECT @select FROM @from WHERE @where"
                        /*@"SELECT " + select +
                        @" FROM " + from +
                        @" WHERE " + where*/
                        );
                cmd.Parameters.Add(new OracleParameter("@select", select));
                cmd.Parameters.Add(new OracleParameter("@from", from));
                cmd.Parameters.Add(new OracleParameter("@where", where));
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
                OracleCommand cmd = new OracleCommand(@query);
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
    }
}

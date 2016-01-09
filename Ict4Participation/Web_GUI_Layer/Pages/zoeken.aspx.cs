using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer
{
    public partial class zoeken : System.Web.UI.Page
    {
        static GUIHandler GUIHandler;
        static List<Questiondetails> questions;
        static List<Accountdetails> accounts;

        protected void Page_Load(object sender, EventArgs e)
        {
            accounts = new List<Accountdetails>();
            // Check if GUIHandler exists
            if (Session["GUIHandler_obj"] == null)
            {
                // Go back if no GUIhandler can be found
                Response.Redirect("inloggen.aspx", false);
                return;
            }
            // Retrieve GUIHandler object from session
            GUIHandler = (GUIHandler)Session["GUIHandler_obj"];

            questions = GUIHandler.GetAll(true);
            accounts = GUIHandler.GetAll();
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("hoofdmenu.aspx", false);
        }

        private void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }

        private struct QuestionSetup
        {
            public string Title { get; set; }
            public string Owner { get; set; }
            public int PostID { get; set; }
            public int OwnerID { get; set; }
            public int Rank { get; set; }
            public int Relevance { get; set; }
        }

        private struct AccountSetup
        {
            public string AccName { get; set; }
            public int AccId { get; set; }
            public int Rank { get; set; }
            public int Relevance { get; set; }
        }

        [System.Web.Services.WebMethod]
        public static string SearchInfo(string str, string fvolunteers, string fhelpreq, string fquestions)
        {
            if (accounts == null)
            {
                accounts = new List<Accountdetails>();
            }
            if (accounts.Count == 0 && GUIHandler != null)
            {
                accounts = GUIHandler.GetAll();
            }

            List<Accountdetails> accTemp = accounts;
            if (fhelpreq == "false")
            {
                accTemp = accTemp.Where(a => a.VOGPath != "").ToList();
            }
            if (fvolunteers == "false")
            {
                accTemp = accTemp.Where(a => a.VOGPath == "").ToList();
            }
            string result = string.Empty;
            str = str.ToLower();
            int length = str.Length;

            if (str.Trim().Length > 0)
            {

                List<QuestionSetup> returnedQuestions = new List<QuestionSetup>();
                List<AccountSetup> returnedAccounts = new List<AccountSetup>();

                if (fquestions == "true")
                {
                    // Cast Questiondetails to QuestionSetup
                    foreach (Questiondetails qd in questions)
                    {
                        // SCORING SYSTEM:
                        // qd.Title = 3
                        // qd.Description = 2
                        // qd.Location = 1
                        // Higher point values get a higher priority
                        // Questions are then rated by their relevance

                        Accountdetails ad = accounts.Find(i => i.ID == qd.PosterID);

                        QuestionSetup vs = new QuestionSetup();
                        vs.Title = qd.Title;
                        vs.Owner = ad.Name;
                        vs.OwnerID = qd.PosterID;
                        vs.PostID = qd.PostID;

                        // Add a question to the list if one of the details matches the input string
                        if (qd.Title.ToLower().Contains(str) || str == "*")
                        {
                            vs.Rank = 3;
                            vs.Relevance = length / qd.Title.Length;
                        }
                        else if (qd.Description.ToLower().Contains(str))
                        {
                            vs.Rank = 2;
                            vs.Relevance = length / qd.Description.Length;
                        }
                        else if (qd.Location.ToLower().Contains(str))
                        {
                            vs.Rank = 1;
                            vs.Relevance = length / qd.Location.Length;
                        }

                        // Add VraagSetup if its rank has been set
                        if (vs.Rank > 0)
                        {
                            returnedQuestions.Add(vs);
                        }
                    }
                }

                // Cast Accountdetails to AccountSetup
                foreach (Accountdetails ad in accTemp)
                {
                    // SCORING SYSTEM:
                    // ad.Name = 5
                    // ad.Email = 4
                    // ad.Address = 3
                    // ad.Phonenumber = 2
                    // ad.City = 1
                    // Higher point values get a higher priority
                    // Accounts are then rated by their relevance

                    AccountSetup a_s = new AccountSetup();
                    a_s.AccId = ad.ID;
                    a_s.AccName = ad.Name;

                    // Add an account to the list if one of the details matches the input string
                    if (ad.Name.ToLower().Contains(str) || str == "*")
                    {
                        a_s.Rank = 5;
                        a_s.Relevance = length/ad.Name.Length;
                    }
                    else if (ad.Email.ToLower().Contains(str))
                    {
                        a_s.Rank = 4;
                        a_s.Relevance = length/ad.Email.Length;
                    }
                    else if (ad.Address.ToLower().Contains(str))
                    {
                        a_s.Rank = 3;
                        a_s.Relevance = length/ad.Address.Length;
                    }
                    else if (ad.Phonenumber.ToLower().Contains(str))
                    {
                        a_s.Rank = 2;
                        a_s.Relevance = length/ad.Phonenumber.Length;
                    }
                    else if (ad.City.ToLower().Contains(str))
                    {
                        a_s.Rank = 1;
                        a_s.Relevance = length/ad.City.Length;
                    }

                    // Add AccountSetup if its rank has been set
                    if (a_s.Rank > 0)
                    {
                        returnedAccounts.Add(a_s);
                    }
                }

                // Sort the VraagSetup list
                returnedQuestions = returnedQuestions.OrderByDescending(i => i.Rank).ThenBy(i => i.Relevance).ToList();
                returnedAccounts = returnedAccounts.OrderByDescending(i => i.Rank).ThenBy(i => i.Relevance).ToList();

                // Cast returnedQuestions to a string
                foreach (QuestionSetup vs in returnedQuestions)
                {
                    result += string.Format("1,{0},{1},{2},{3}:", vs.Title, vs.PostID, vs.OwnerID, vs.Owner);
                }

                // Cast returnedAccounts to a string
                foreach (AccountSetup a_s in returnedAccounts)
                {
                    result += string.Format("2,{0},{1}:", a_s.AccName, a_s.AccId);
                }

                // Remove the last :
                if (result.Length > 0)
                {
                    result = result.Substring(0, result.Length - 1);
                }

            }

            return result;
        }

        [System.Web.Services.WebMethod]
        public static string GaNaarVraag(int id)
        {
            // Set session variable
            HttpContext.Current.Session["QuestionDetails_id"] = id;

            // Path to url has to be send back because asp doesnt allow routing from webmethods
            return "vraag.aspx";
        }

        [System.Web.Services.WebMethod]
        public static string GaNaarProfiel(int id)
        {
            // Set session variable
            HttpContext.Current.Session["UserProfile_ID"] = id;

            // Path to url has to be send back because asp doesnt allow routing from webmethods
            return "gebruikerprofiel.aspx";
        }
    }
}
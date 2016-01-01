using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer.Pages
{
    public partial class vragen : System.Web.UI.Page
    {
        private GUIHandler GUIHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if GUIHandler exists
            if (Session["GUIHandler_obj"] == null)
            {
                // Go back if no GUIhandler can be found
                Response.Redirect("inloggen.aspx", false);
                return;
            }

            // Retrieve GUIHandler object from session
            GUIHandler = (GUIHandler)Session["GUIHandler_obj"];
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

        private struct VraagSetup
        {
            public string Title { get; set; }
            public string Owner { get; set; }
            public int PostID { get; set; }
            public int OwnerID { get; set; }
            public int Rank { get; set; }
            public int Relevance { get; set; }
        }

        [System.Web.Services.WebMethod]
        public static string SearchQuestions(string str)
        {
            string result = string.Empty;

            if (str.Trim().Length > 0)
            {
                GUIHandler tempGUIHandler = new GUIHandler();

                List<Questiondetails> questions = tempGUIHandler.GetAll(true);

                List<VraagSetup> returnlist = new List<VraagSetup>();

                foreach (Questiondetails qd in questions)
                {
                    // SCORING SYSTEM:
                    // qd.Title = 3
                    // qd.Description = 2
                    // qd.Location = 1
                    // Higher point values get a higher priority
                    // Questions are then rated by their relevance

                    List<Accountdetails> ad_list = tempGUIHandler.GetAll();

                    Accountdetails ad = ad_list.Find(i => i.ID == qd.PosterID);

                    VraagSetup vs = new VraagSetup();
                    vs.Title = qd.Title;
                    vs.Owner = ad.Name;
                    vs.OwnerID = qd.PosterID;
                    vs.PostID = qd.PostID;

                    // Add a question to the list if one of the details matches the input string
                    if (qd.Title.ToLower().Contains(str.ToLower()))
                    {
                        vs.Rank = 3;
                        vs.Relevance = str.Length / qd.Title.Length;
                    }
                    else if (qd.Description.ToLower().Contains(str.ToLower()))
                    {
                        vs.Rank = 2;
                        vs.Relevance = str.Length / qd.Description.Length;
                    }
                    else if (qd.Location.ToLower().Contains(str.ToLower()))
                    {
                        vs.Rank = 1;
                        vs.Relevance = str.Length / qd.Location.Length;
                    }

                    // Add VraagSetup if its rank has been set
                    if (vs.Rank > 0)
                    {
                        returnlist.Add(vs);
                    }
                }

                // Sort the VraagSetup list
                returnlist = returnlist.OrderByDescending(i => i.Rank).OrderByDescending(i => i.Relevance).ToList();

                // Cast returnlist to a string
                foreach (VraagSetup vs in returnlist)
                {
                    result += string.Format("{0},{1},{2},{3}:", vs.Title, vs.PostID, vs.OwnerID, vs.Owner);
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

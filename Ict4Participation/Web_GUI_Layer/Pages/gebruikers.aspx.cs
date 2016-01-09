using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Admin_Layer;

namespace Web_GUI_Layer
{
    public partial class gebruikers : System.Web.UI.Page
    {
        private static int mainuserID;
        static List<Accountdetails> accounts;
        static GUIHandler GUIHandler;

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

            // Set mainuserID to be used in static methods
            GUIHandler = ((GUIHandler)Session["GUIHandler_obj"]);
            mainuserID = GUIHandler.GetMainuserInfo().ID;
            accounts = GUIHandler.GetAll();
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("profiel.aspx", false);
        }

        [System.Web.Services.WebMethod]
        public static string SearchUsers(string str, string fvolunteers, string fhelpreq)
        {
            if (accounts == null)
            {
                accounts = new List<Accountdetails>();
            }
            if (accounts.Count == 0 && GUIHandler != null)
            {
                accounts = GUIHandler.GetAll();
            }

            string result = string.Empty;
            List<Accountdetails> accTemp = accounts;
            if (fhelpreq == "false")
            {
                accTemp = accTemp.Where(a => a.VOGPath != "").ToList();
            }
            if (fvolunteers == "false")
            {
                accTemp = accTemp.Where(a => a.VOGPath == "").ToList();
            }

            foreach (Accountdetails user in accTemp)
            {
                if (user.ID != mainuserID)
                {
                    if (user.Name.ToLower().Contains(str.ToLower()))
                    {
                        result += user.Name + "," + user.ID + ":";
                    }
                }
            }

            if (result.Length > 0)
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }

        protected void ShowErrorMessage(string message)
        {
            error_message.Text = message;
            error_message.CssClass = error_message.CssClass.Replace("error-hidden", "");
        }

        [System.Web.Services.WebMethod]
        public static string GetUserInfo(string id)
        {
            return "Testnaam|Hulpverlener-test|TestDescription|test/profiel/foto.png";
        }

        [System.Web.Services.WebMethod]
        public static string GaNaarProfiel(string id)
        {
            // Set session variable
            HttpContext.Current.Session["UserProfile_ID"] = id;

            // Path to url has to be send back because asp doesnt allow routing from webmethods
            return "gebruikerprofiel.aspx";
        }
    }
}
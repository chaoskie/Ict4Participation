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
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if GUIHandler exists
            if (Session["GUIHandler_obj"] == null)
            {
                // Go back if no GUIhandler can be found
                Response.Redirect("inloggen.aspx", false);
                return;
            }
        }

        protected void btnTerug_Click(object sender, EventArgs e)
        {
            Response.Redirect("profiel.aspx", false);
        }

        [System.Web.Services.WebMethod]
        public static string SearchUsers(string str)
        {
            string result = string.Empty;
            GUIHandler tempGUIHandler = new GUIHandler();

            List<Accountdetails> users = tempGUIHandler.GetAll();

            foreach (Accountdetails user in users)
            {
                if (user.Name.ToLower().Contains(str.ToLower()))
                {
                    result += user.Name + "," + user.ID + ":";
                }
            }

            if (result.Length > 0)
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
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
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
        private GUIHandler GUIHandler;

        protected void Page_Load(object sender, EventArgs e)
        {
            GUIHandler = new GUIHandler();
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
    }
}